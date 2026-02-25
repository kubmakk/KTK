import * as THREE from 'three';
import { GLTFLoader } from 'three/addons/loaders/GLTFLoader.js';
import * as SkeletonUtils from 'three/addons/utils/SkeletonUtils.js';

// --- CONFIGURATION ---
const CONFIG = {
    LANES: [-3.0, 0, 3.0],
    SPEED_INITIAL: 15.0, // World moves towards Z+
    SPEED_MAX: 40.0,
    GRAVITY: 40.0,
    JUMP_FORCE: 14.0,
    LANE_SPEED: 10.0,
    FOG_DIST: 60,
    CHUNK_LENGTH: 40,
    ASSETS: {
        player: { 
            url: 'https://raw.githubusercontent.com/mrdoob/three.js/master/examples/models/gltf/Soldier.glb',
            scale: 1.5,
            fallbackColor: 0x00ff00
        },
        train: { 
            url: 'https://raw.githubusercontent.com/mrdoob/three.js/master/examples/models/gltf/BoxVertexColors.glb', 
            scale: { x: 3, y: 3, z: 10 },
            fallbackColor: 0xff0000 
        },
        coin: { 
            url: 'https://raw.githubusercontent.com/mrdoob/three.js/master/examples/models/gltf/BoomBox.glb', 
            scale: 15.0, // Boombox is tiny, needs scale
            fallbackColor: 0xffd700 
        }
    }
};

// --- CLASS: ASSET MANAGER ---
class AssetManager {
    constructor() {
        this.loader = new GLTFLoader();
        this.assets = new Map();
        this.loadingManager = new THREE.LoadingManager();
    }

    async loadAll(onProgress) {
        this.loadingManager.onProgress = (url, itemsLoaded, itemsTotal) => {
            const percentage = (itemsLoaded / itemsTotal) * 100;
            if (onProgress) onProgress(percentage);
        };

        const loadPromises = Object.entries(CONFIG.ASSETS).map(([key, data]) => {
            return this.loadAsset(key, data);
        });

        await Promise.all(loadPromises);
    }

    loadAsset(key, data) {
        return new Promise((resolve) => {
            this.loader.load(
                data.url,
                (gltf) => {
                    // Success
                    const model = gltf.scene;
                    
                    // Apply config transforms
                    if (typeof data.scale === 'number') {
                        model.scale.setScalar(data.scale);
                    } else if (data.scale) {
                        model.scale.set(data.scale.x, data.scale.y, data.scale.z);
                    }

                    // Shadow properties
                    model.traverse(c => {
                        if (c.isMesh) {
                            c.castShadow = true;
                            c.receiveShadow = true;
                        }
                    });

                    // Store animations if present
                    const animations = gltf.animations || [];
                    this.assets.set(key, { model, animations });
                    resolve();
                },
                undefined, // Progress handled by manager
                (err) => {
                    // CRITICAL FALLBACK SYSTEM
                    console.warn(`Failed to load ${key}. Using Fallback.`, err);
                    const fallback = this.createFallback(key, data);
                    this.assets.set(key, { model: fallback, animations: [] });
                    resolve(); // Resolve anyway so game starts
                }
            );
        });
    }

    createFallback(key, data) {
        let geometry, material;
        const color = data.fallbackColor || 0xcccccc;
        material = new THREE.MeshStandardMaterial({ color: color });

        if (key === 'coin') {
            geometry = new THREE.CylinderGeometry(0.5, 0.5, 0.1, 16);
            geometry.rotateX(Math.PI / 2);
        } else if (key === 'train') {
            geometry = new THREE.BoxGeometry(2.5, 3, 10);
        } else {
            // Player or generic
            geometry = new THREE.BoxGeometry(1, 2, 1);
        }

        const mesh = new THREE.Mesh(geometry, material);
        mesh.castShadow = true;
        const group = new THREE.Group();
        group.add(mesh);
        
        // Lift box so origin is at bottom
        if (key !== 'coin') mesh.position.y = 1;
        
        return group;
    }

    getModel(name) {
        return this.assets.get(name);
    }
}

// --- CLASS: PLAYER CONTROLLER ---
class PlayerController {
    constructor(scene, assetManager) {
        this.scene = scene;
        
        const asset = assetManager.getModel('player');
        this.mesh = SkeletonUtils.clone(asset.model); // Use clone for safety
        this.scene.add(this.mesh);

        // Animation
        this.mixer = new THREE.AnimationMixer(this.mesh);
        this.animations = asset.animations;
        this.actions = {};
        
        // Initialize Animations (Mapping Soldier inputs to Game Logic)
        if (this.animations.length > 0) {
            // Soldier.glb has: 'Idle', 'Run', 'TPose', 'Walk'
            const runClip = THREE.AnimationClip.findByName(this.animations, 'Run');
            const jumpClip = THREE.AnimationClip.findByName(this.animations, 'Walk'); // Fallback for jump
            const idleClip = THREE.AnimationClip.findByName(this.animations, 'Idle');

            if(runClip) this.actions['Run'] = this.mixer.clipAction(runClip);
            if(jumpClip) this.actions['Jump'] = this.mixer.clipAction(jumpClip);
            if(idleClip) this.actions['Idle'] = this.mixer.clipAction(idleClip);

            this.switchAnimation('Run');
        }

        // Physics State
        this.laneIndex = 1; // Middle lane
        this.targetX = CONFIG.LANES[1];
        this.mesh.position.set(0, 0, 0);
        this.velocity = new THREE.Vector3();
        this.isJumping = false;
        
        // Collision Box
        this.box = new THREE.Box3();
        this.colliderHelper = new THREE.Box3Helper(this.box, 0xffff00);
        this.colliderHelper.visible = false; // Debug
        this.scene.add(this.colliderHelper);
    }

    switchAnimation(name) {
        if (!this.actions[name]) return;
        if (this.currentAction === this.actions[name]) return;

        const prevAction = this.currentAction;
        this.currentAction = this.actions[name];

        if (prevAction) {
            this.currentAction.reset().play();
            prevAction.crossFadeTo(this.currentAction, 0.2, true);
        } else {
            this.currentAction.play();
        }
    }

    update(dt) {
        // Horizontal Movement (Lerp)
        this.mesh.position.x = THREE.MathUtils.lerp(this.mesh.position.x, this.targetX, dt * CONFIG.LANE_SPEED);

        // Vertical Movement (Gravity)
        if (this.isJumping) {
            this.velocity.y -= CONFIG.GRAVITY * dt;
            this.mesh.position.y += this.velocity.y * dt;

            // Ground Check
            if (this.mesh.position.y <= 0) {
                this.mesh.position.y = 0;
                this.velocity.y = 0;
                this.isJumping = false;
                this.switchAnimation('Run');
            }
        }

        // Update Animation Mixer
        if (this.mixer) this.mixer.update(dt);

        // Update Bounding Box (shrink slightly for fairness)
        this.box.setFromObject(this.mesh);
        this.box.expandByScalar(-0.3); 
    }

    moveLane(direction) {
        const newIndex = this.laneIndex + direction;
        if (newIndex >= 0 && newIndex < CONFIG.LANES.length) {
            this.laneIndex = newIndex;
            this.targetX = CONFIG.LANES[this.laneIndex];
        }
    }

    jump() {
        if (!this.isJumping) {
            this.velocity.y = CONFIG.JUMP_FORCE;
            this.isJumping = true;
            this.switchAnimation('Jump');
        }
    }
}

// --- CLASS: LEVEL GENERATOR ---
class LevelGenerator {
    constructor(scene, assetManager) {
        this.scene = scene;
        this.assetManager = assetManager;
        this.chunks = [];
        this.obstacles = [];
        this.coins = [];
        this.speed = CONFIG.SPEED_INITIAL;
        
        // Materials
        this.floorMat = new THREE.MeshStandardMaterial({ 
            color: 0x444444, 
            roughness: 0.8 
        });

        // Initialize pool
        this.initChunks();
    }

    initChunks() {
        // Create 5 chunks covering visible area + buffer
        for (let i = 0; i < 5; i++) {
            const chunk = this.createChunk(-i * CONFIG.CHUNK_LENGTH);
            this.chunks.push(chunk);
        }
    }

    createChunk(zPos) {
        const geometry = new THREE.PlaneGeometry(12, CONFIG.CHUNK_LENGTH);
        const mesh = new THREE.Mesh(geometry, this.floorMat);
        mesh.rotation.x = -Math.PI / 2;
        mesh.position.z = zPos;
        mesh.receiveShadow = true;
        this.scene.add(mesh);
        
        // Add lane markings (visual only)
        const lineGeo = new THREE.PlaneGeometry(0.2, CONFIG.CHUNK_LENGTH);
        const lineMat = new THREE.MeshBasicMaterial({ color: 0xffffff });
        const leftLine = new THREE.Mesh(lineGeo, lineMat);
        leftLine.position.x = -1.5;
        leftLine.position.z = 0.01; // Avoid z-fight
        const rightLine = new THREE.Mesh(lineGeo, lineMat);
        rightLine.position.x = 1.5;
        rightLine.position.z = 0.01;
        mesh.add(leftLine);
        mesh.add(rightLine);

        return mesh;
    }

    spawnObstacle(parentChunk) {
        // Chance to spawn
        if (Math.random() > 0.6) return; 

        const lane = CONFIG.LANES[Math.floor(Math.random() * CONFIG.LANES.length)];
        
        // Decide Type: Train or Coin Pattern
        const type = Math.random() > 0.3 ? 'train' : 'coin';

        if (type === 'train') {
            const asset = this.assetManager.getModel('train');
            // Use clone for static meshes, SkeletonUtils for skinned
            const mesh = asset.model.clone(); 
            mesh.position.set(lane, 0, parentChunk.position.z); // Local to chunk? No, World space easier
            mesh.position.z = parentChunk.position.z; 
            
            this.scene.add(mesh);
            
            // Hitbox
            const box = new THREE.Box3();
            this.obstacles.push({ mesh, box, active: true });
        } else {
            // Spawn Coins
            const asset = this.assetManager.getModel('coin');
            for(let i=0; i<3; i++) {
                const mesh = asset.model.clone();
                mesh.position.set(lane, 1.0, parentChunk.position.z + (i * 3));
                
                this.scene.add(mesh);
                const box = new THREE.Box3();
                this.coins.push({ mesh, box, active: true });
            }
        }
    }

    update(dt) {
        // Speed scaling
        this.speed = Math.min(CONFIG.SPEED_MAX, this.speed + dt * 0.1);

        // Move Everything towards Z+ (Camera is at Z positive looking -Z? 
        // Wait, standard setup: Player at 0, Camera at +Z looking at 0.
        // Prompt says: "LevelGenerator moves all environmental chunks towards the camera on the Z-axis."
        // So objects move from -Z to +Z.
        
        const moveDist = this.speed * dt;

        // Move Chunks
        this.chunks.forEach(chunk => {
            chunk.position.z += moveDist;
            
            // Recycle logic
            if (chunk.position.z > 20) { // Behind camera
                chunk.position.z -= (this.chunks.length * CONFIG.CHUNK_LENGTH);
                this.spawnObstacle(chunk);
            }
        });

        // Move & Clean Obstacles
        this.obstacles.forEach(obs => {
            if (!obs.active) return;
            obs.mesh.position.z += moveDist;
            obs.box.setFromObject(obs.mesh); // Update hit box
            obs.box.expandByScalar(-0.5); // Forgiveness

            if (obs.mesh.position.z > 10) {
                this.scene.remove(obs.mesh);
                obs.active = false;
            }
        });

        // Move & Spin Coins
        this.coins.forEach(c => {
            if (!c.active) return;
            c.mesh.position.z += moveDist;
            c.mesh.rotation.y += 5 * dt; // Spin
            c.box.setFromObject(c.mesh);

            if (c.mesh.position.z > 10) {
                this.scene.remove(c.mesh);
                c.active = false;
            }
        });

        // Cleanup arrays
        this.obstacles = this.obstacles.filter(o => o.active);
        this.coins = this.coins.filter(c => c.active);
    }
    
    reset() {
        this.speed = CONFIG.SPEED_INITIAL;
        // Clear obstacles
        this.obstacles.forEach(o => this.scene.remove(o.mesh));
        this.coins.forEach(c => this.scene.remove(c.mesh));
        this.obstacles = [];
        this.coins = [];
        
        // Reset chunks
        this.chunks.forEach((chunk, i) => {
            chunk.position.z = -i * CONFIG.CHUNK_LENGTH;
        });
    }
}

// --- CLASS: GAME MANAGER ---
class GameManager {
    constructor() {
        this.container = document.getElementById('game-container');
        this.state = 'LOADING'; // LOADING, MENU, PLAYING, GAMEOVER
        this.score = 0;
        this.coinsCollected = 0;
        
        // Three.js Setup
        this.scene = new THREE.Scene();
        this.scene.background = new THREE.Color(0x87CEEB);
        this.scene.fog = new THREE.Fog(0x87CEEB, 20, CONFIG.FOG_DIST);

        this.camera = new THREE.PerspectiveCamera(60, window.innerWidth / window.innerHeight, 0.1, 100);
        this.camera.position.set(0, 5, 8);
        this.camera.lookAt(0, 1, -5);

        this.renderer = new THREE.WebGLRenderer({ antialias: true });
        this.renderer.setSize(window.innerWidth, window.innerHeight);
        this.renderer.shadowMap.enabled = true;
        this.renderer.shadowMap.type = THREE.PCFSoftShadowMap;
        this.container.appendChild(this.renderer.domElement);

        // Lighting
        const hemiLight = new THREE.HemisphereLight(0xffffff, 0x444444, 1.2);
        this.scene.add(hemiLight);

        const dirLight = new THREE.DirectionalLight(0xffffff, 1.5);
        dirLight.position.set(10, 20, 10);
        dirLight.castShadow = true;
        dirLight.shadow.camera.top = 20;
        dirLight.shadow.camera.bottom = -20;
        dirLight.shadow.camera.left = -20;
        dirLight.shadow.camera.right = 20;
        this.scene.add(dirLight);

        // Subsystems
        this.clock = new THREE.Clock();
        this.assetManager = new AssetManager();
        
        // Bindings
        window.addEventListener('resize', this.onWindowResize.bind(this));
        document.addEventListener('keydown', this.handleInput.bind(this));
        document.getElementById('restart-btn').addEventListener('click', () => this.restartGame());

        this.init();
    }

    async init() {
        // Load Assets
        await this.assetManager.loadAll((percent) => {
            document.getElementById('loader-bar').style.width = `${percent}%`;
        });

        // Setup Game Objects
        this.player = new PlayerController(this.scene, this.assetManager);
        this.level = new LevelGenerator(this.scene, this.assetManager);

        // Transition UI
        document.getElementById('loading-screen').classList.add('hidden');
        document.getElementById('hud').classList.remove('hidden');
        document.getElementById('controls-hint').classList.remove('hidden');
        
        this.state = 'PLAYING';
        this.startLoop();
    }

    startLoop() {
        this.renderer.setAnimationLoop(this.update.bind(this));
    }

    update() {
        if (this.state !== 'PLAYING') return;

        const dt = this.clock.getDelta();

        // Update Logic
        this.player.update(dt);
        this.level.update(dt);

        // Score
        this.score += this.level.speed * dt * 0.1;
        this.updateHUD();

        // Collisions
        this.checkCollisions();

        // Render
        this.renderer.render(this.scene, this.camera);
    }

    checkCollisions() {
        const playerBox = this.player.box;

        // Obstacles (Game Over)
        for (const obs of this.level.obstacles) {
            if (playerBox.intersectsBox(obs.box)) {
                this.gameOver();
                return;
            }
        }

        // Coins (Collect)
        this.level.coins.forEach(coin => {
            if (coin.active && playerBox.intersectsBox(coin.box)) {
                coin.active = false;
                this.scene.remove(coin.mesh);
                this.coinsCollected++;
                
                // Simple feedback (flash color or something) could go here
            }
        });
    }

    gameOver() {
        this.state = 'GAMEOVER';
        this.player.switchAnimation('Idle'); // Or Stumble/Die if available
        document.getElementById('game-over-screen').classList.remove('hidden');
        document.getElementById('final-score').innerText = Math.floor(this.score);
        document.getElementById('game-container').style.filter = "blur(5px)";
    }

    restartGame() {
        this.state = 'PLAYING';
        this.score = 0;
        this.coinsCollected = 0;
        
        this.level.reset();
        
        // Reset Player
        this.player.laneIndex = 1;
        this.player.targetX = 0;
        this.player.mesh.position.set(0, 0, 0);
        this.player.velocity.set(0,0,0);
        this.player.switchAnimation('Run');

        // UI
        document.getElementById('game-over-screen').classList.add('hidden');
        document.getElementById('game-container').style.filter = "none";
        this.clock.start(); // Reset dt
    }

    handleInput(e) {
        if (this.state !== 'PLAYING') return;

        switch(e.code) {
            case 'ArrowLeft':
            case 'KeyA':
                this.player.moveLane(1); // Camera faces -Z, so Right is Left? 
                // Wait, standard view: +X is Right.
                // If camera is at (0, 5, 8) looking at (0, 1, -5):
                // Right on screen is +X.
                // Left on screen is -X.
                // Lane logic: 0(-3), 1(0), 2(+3).
                // Left Key should decrease index.
                this.player.moveLane(-1);
                break;
            case 'ArrowRight':
            case 'KeyD':
                this.player.moveLane(1);
                break;
            case 'ArrowUp':
            case 'KeyW':
            case 'Space':
                this.player.jump();
                break;
        }
    }

    updateHUD() {
        document.getElementById('score-val').innerText = Math.floor(this.score);
        document.getElementById('coin-val').innerText = this.coinsCollected;
    }

    onWindowResize() {
        this.camera.aspect = window.innerWidth / window.innerHeight;
        this.camera.updateProjectionMatrix();
        this.renderer.setSize(window.innerWidth, window.innerHeight);
    }
}

// Start
new GameManager();