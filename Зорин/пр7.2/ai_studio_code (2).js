import * as THREE from 'three';
import { GLTFLoader } from 'three/addons/loaders/GLTFLoader.js';
import * as SkeletonUtils from 'three/addons/utils/SkeletonUtils.js';

/**
 * CONFIGURATION & CONSTANTS
 */
const CONFIG = {
    LANE_WIDTH: 3.0,
    GRAVITY: 40.0,
    JUMP_FORCE: 12.0,
    SPEED_INITIAL: 20.0,
    SPEED_MAX: 50.0,
    SPEED_INC: 0.5, // per second
    FOG_NEAR: 30,
    FOG_FAR: 120,
    CHUNK_LENGTH: 40, // Length of one floor segment
};

const ASSET_URLS = {
    player: 'https://raw.githubusercontent.com/mrdoob/three.js/master/examples/models/gltf/Soldier.glb',
    train: 'https://raw.githubusercontent.com/KhronosGroup/glTF-Sample-Models/master/2.0/BoxTextured/glTF-Binary/BoxTextured.glb',
    coin: 'https://raw.githubusercontent.com/KhronosGroup/glTF-Sample-Models/master/2.0/BoomBox/glTF-Binary/BoomBox.glb'
    // Fallbacks handled in AssetManager if direct URLs fail
};

/**
 * ------------------------------------------------------------------
 * CLASS: AssetManager
 * Handles loading GLBs, CORS errors, and generating Procedural Fallbacks
 * ------------------------------------------------------------------
 */
class AssetManager {
    constructor() {
        this.loader = new GLTFLoader();
        this.assets = new Map();
    }

    async loadAll(onProgress) {
        const keys = Object.keys(ASSET_URLS);
        let loadedCount = 0;

        const promises = keys.map(async (key) => {
            try {
                const gltf = await this.loadOne(ASSET_URLS[key]);
                this.prepareAsset(key, gltf);
                this.assets.set(key, { type: 'gltf', scene: gltf.scene, animations: gltf.animations });
            } catch (err) {
                console.warn(`Failed to load ${key}, creating fallback. Error:`, err);
                const fallback = this.createFallback(key);
                this.assets.set(key, { type: 'mesh', scene: fallback, animations: [] });
            }
            
            loadedCount++;
            if (onProgress) onProgress(loadedCount / keys.length);
        });

        await Promise.all(promises);
    }

    loadOne(url) {
        return new Promise((resolve, reject) => {
            this.loader.load(url, resolve, undefined, reject);
        });
    }

    /** Pre-process specific models (scaling, rotation) */
    prepareAsset(key, gltf) {
        const model = gltf.scene;
        model.traverse(c => {
            if (c.isMesh) {
                c.castShadow = true;
                c.receiveShadow = true;
            }
        });

        if (key === 'train') {
            // BoxTextured is a cube, scale it to look like a train
            model.scale.set(3, 3, 10); 
            // Center the pivot
            model.position.y = 1.5; 
        } else if (key === 'coin') {
            // BoomBox is huge, scale down
            model.scale.set(10, 10, 10);
            model.position.y = 1.0;
        } else if (key === 'player') {
            // Soldier model
            model.scale.set(1.5, 1.5, 1.5);
        }
    }

    createFallback(key) {
        let geometry, material, mesh;

        if (key === 'player') {
            geometry = new THREE.CapsuleGeometry(0.5, 1.5, 4, 8);
            material = new THREE.MeshStandardMaterial({ color: 0x00ff00 });
            mesh = new THREE.Mesh(geometry, material);
            mesh.position.y = 1.0; // Pivot at feet
        } else if (key === 'train') {
            geometry = new THREE.BoxGeometry(2.5, 3, 10);
            material = new THREE.MeshStandardMaterial({ color: 0xff0000 });
            mesh = new THREE.Mesh(geometry, material);
            mesh.position.y = 1.5;
        } else if (key === 'coin') {
            geometry = new THREE.CylinderGeometry(0.5, 0.5, 0.1, 16);
            geometry.rotateX(Math.PI / 2); // Face camera
            material = new THREE.MeshStandardMaterial({ color: 0xffd700, metalness: 0.8, roughness: 0.2 });
            mesh = new THREE.Mesh(geometry, material);
            mesh.position.y = 1.0;
        }

        const group = new THREE.Group();
        group.add(mesh);
        return group;
    }

    getModel(name) {
        return this.assets.get(name);
    }
}

/**
 * ------------------------------------------------------------------
 * CLASS: PlayerController
 * Handles Physics, Inputs, and Animation Mixing
 * ------------------------------------------------------------------
 */
class PlayerController {
    constructor(game) {
        this.game = game;
        this.scene = game.scene;
        
        // Logic
        this.lane = 0; // -1, 0, 1
        this.targetX = 0;
        this.currentVelocityY = 0;
        this.isGrounded = true;
        this.isDead = false;

        // Visuals
        const asset = game.assetManager.getModel('player');
        
        // Check if we have a skinned mesh (GLTF) or fallback (Group)
        if (asset.type === 'gltf') {
            this.mesh = SkeletonUtils.clone(asset.scene);
            this.mixer = new THREE.AnimationMixer(this.mesh);
            this.animations = asset.animations;
        } else {
            this.mesh = asset.scene.clone();
            this.mixer = null;
        }

        this.scene.add(this.mesh);
        
        // Start animation
        this.currentAction = null;
        this.playAnimation('Run');

        // Collision Box
        this.box = new THREE.Box3();
    }

    playAnimation(name) {
        if (!this.mixer || !this.animations) return;

        // Map generic names to specific Soldier.glb clip names
        // Soldier clips: 'Idle', 'Run', 'Walk', 'TPose'
        let clipName = name;
        if (name === 'Jump' || name === 'Roll') clipName = 'Walk'; // Fallback mapping

        const clip = THREE.AnimationClip.findByName(this.animations, clipName);
        if (!clip) return;

        const newAction = this.mixer.clipAction(clip);
        
        if (this.currentAction && this.currentAction !== newAction) {
            this.currentAction.crossFadeTo(newAction, 0.2, true);
        }
        
        newAction.reset().fadeIn(0.1).play();
        this.currentAction = newAction;
    }

    handleInput(input) {
        if (this.isDead) return;

        if (input === 'left' && this.lane > -1) {
            this.lane--;
        } else if (input === 'right' && this.lane < 1) {
            this.lane++;
        } else if (input === 'up' && this.isGrounded) {
            this.jump();
        }
    }

    jump() {
        this.currentVelocityY = CONFIG.JUMP_FORCE;
        this.isGrounded = false;
        this.playAnimation('Jump');
    }

    update(dt) {
        // Lateral Movement (Lerp)
        this.targetX = this.lane * CONFIG.LANE_WIDTH;
        this.mesh.position.x = THREE.MathUtils.lerp(this.mesh.position.x, this.targetX, 10 * dt);

        // Vertical Movement (Gravity)
        this.currentVelocityY -= CONFIG.GRAVITY * dt;
        this.mesh.position.y += this.currentVelocityY * dt;

        // Ground Collision
        if (this.mesh.position.y <= 0) {
            this.mesh.position.y = 0;
            this.currentVelocityY = 0;
            if (!this.isGrounded) {
                this.isGrounded = true;
                this.playAnimation('Run');
            }
        }

        // Animation Mixer
        if (this.mixer) this.mixer.update(dt);

        // Update Collision Box (shrink slightly for fairness)
        this.box.setFromObject(this.mesh);
        this.box.expandByScalar(-0.3); 
    }
}

/**
 * ------------------------------------------------------------------
 * CLASS: LevelGenerator
 * "Treadmill" Logic - Moves world towards player
 * ------------------------------------------------------------------
 */
class LevelGenerator {
    constructor(game) {
        this.game = game;
        this.scene = game.scene;
        this.chunks = []; // Stores objects: { mesh, box, type, active }
        this.speed = CONFIG.SPEED_INITIAL;
        
        // Materials for the floor
        this.floorMat = new THREE.MeshStandardMaterial({ color: 0x333333, roughness: 0.8 });
        
        // Initial spawning
        this.spawnZ = -10; // Start slightly behind
        for(let i=0; i<6; i++) {
            this.spawnChunk(i > 2); // Only spawn obstacles after 2 chunks
        }
    }

    spawnChunk(withObstacles) {
        // 1. Create Floor
        const floorGeo = new THREE.PlaneGeometry(CONFIG.LANE_WIDTH * 3 + 4, CONFIG.CHUNK_LENGTH);
        const floor = new THREE.Mesh(floorGeo, this.floorMat);
        floor.rotation.x = -Math.PI / 2;
        floor.receiveShadow = true;
        
        // Position floor center. 
        // Logic: Chunks are spawned at this.spawnZ, then we increment spawnZ.
        // The floor's center is spawnZ + length/2
        const centerZ = this.spawnZ + CONFIG.CHUNK_LENGTH / 2;
        floor.position.set(0, 0, centerZ); 

        this.scene.add(floor);
        
        const chunkObj = {
            floor: floor,
            obstacles: [],
            coins: []
        };

        // 2. Spawn Obstacles
        if (withObstacles) {
            // Pick a random lane for a train
            const lanes = [-1, 0, 1];
            const blockedLane = lanes[Math.floor(Math.random() * lanes.length)];
            
            this.spawnTrain(blockedLane, centerZ, chunkObj);

            // 3. Spawn Coins in other lanes
            lanes.forEach(l => {
                if (l !== blockedLane && Math.random() > 0.5) {
                    this.spawnCoin(l, centerZ, chunkObj);
                }
            });
        }

        this.chunks.push(chunkObj);
        this.spawnZ += CONFIG.CHUNK_LENGTH;
    }

    spawnTrain(lane, zPos, chunkObj) {
        const asset = this.game.assetManager.getModel('train');
        let mesh;
        if(asset.type === 'gltf') {
            mesh = SkeletonUtils.clone(asset.scene);
        } else {
            mesh = asset.scene.clone();
        }

        mesh.position.set(lane * CONFIG.LANE_WIDTH, 0, zPos);
        this.scene.add(mesh);

        // Collision box
        const box = new THREE.Box3().setFromObject(mesh);
        // Box needs to be updated every frame, but since train is rigid child of scene,
        // we can just store the mesh and compute box in checkCollisions
        
        chunkObj.obstacles.push({ mesh: mesh, hit: false });
    }

    spawnCoin(lane, zPos, chunkObj) {
        const asset = this.game.assetManager.getModel('coin');
        let mesh;
        if(asset.type === 'gltf') {
            mesh = SkeletonUtils.clone(asset.scene);
        } else {
            mesh = asset.scene.clone();
        }
        
        mesh.position.set(lane * CONFIG.LANE_WIDTH, 1.5, zPos); // Float
        this.scene.add(mesh);
        
        chunkObj.coins.push({ mesh: mesh, active: true });
    }

    update(dt, playerBox) {
        // Increase speed
        if (this.speed < CONFIG.SPEED_MAX) this.speed += CONFIG.SPEED_INC * dt;
        
        const moveDist = this.speed * dt;

        // Move all chunks towards -Z (camera is roughly at +Z looking -Z, wait...)
        // Correction: Player is at Z=0. Standard endless runner:
        // Player at 0. Objects spawn at negative Z (far away)? No, usually +Z is towards camera.
        // Let's standard: Camera at +Z looking at 0. Objects spawn at -FarZ and move +Z.
        // Or: Player fixed, Objects spawn at -Far and move to +Far.
        // Let's use: Player at 0. Horizon is negative Z.
        // Objects spawn at -100 and move towards +100.
        
        // Wait, the prompt says "moves all environmental chunks towards the camera".
        // Camera is usually behind player (+Z).
        // So objects come from -Z (horizon) to +Z? No, that's backwards.
        // Standard: Objects appear at Horizon (negative Z) and move towards camera (+Z)? 
        // NO. In ThreeJS default: Camera is at +Z. Looking at -Z.
        // If Player runs "forward", they run towards -Z.
        // If Player is FIXED, the world must move +Z (towards the camera/player).
        
        // My Logic used above: `spawnZ` increments. This implies spawnZ is getting larger (+).
        // If camera is at +Z looking -Z, and Player is at 0...
        // We should spawn at -Z (far away) and move objects +Z.
        
        // Let's reset the logic to be robust:
        // Player Z = 0.
        // Camera Z = +5.
        // Spawning needs to happen at Z = -100 (Horizon).
        // Objects move +Z. 
        
        // FIXING SPAWN LOGIC:
        // Currently my spawnZ started at -10 and added +40. That goes -10, 30, 70... behind camera.
        // I need to spawn deep in negative Z.
        if (this.spawnZ > -120) {
            // Initialize spawnZ deeper
             this.spawnZ = -200;
             this.chunks = []; // clear initial garbage
        }

        // Iterate backwards to allow removal
        for (let i = this.chunks.length - 1; i >= 0; i--) {
            const chunk = this.chunks[i];
            
            // Move Floor
            chunk.floor.position.z += moveDist;
            
            // Move Obstacles
            chunk.obstacles.forEach(ob => ob.mesh.position.z += moveDist);
            
            // Move and Rotate Coins
            chunk.coins.forEach(c => {
                c.mesh.position.z += moveDist;
                c.mesh.rotation.y += 3 * dt; // Spin
            });

            // Remove logic: if passed camera (Z > 10)
            if (chunk.floor.position.z > 20) {
                this.scene.remove(chunk.floor);
                chunk.obstacles.forEach(o => this.scene.remove(o.mesh));
                chunk.coins.forEach(c => this.scene.remove(c.mesh));
                this.chunks.splice(i, 1);
            }
        }

        // Spawn new chunks if needed
        // Find the most distant chunk
        let minZ = 0;
        if(this.chunks.length > 0) {
             // chunk position is center. tail is center - length/2
             minZ = this.chunks[this.chunks.length-1].floor.position.z - CONFIG.CHUNK_LENGTH/2;
        }

        if (minZ > -150) {
            // If the furthest chunk is too close, spawn another behind it
            this.spawnZ = minZ - CONFIG.CHUNK_LENGTH/2; // Center of new chunk
            this.spawnChunk(true);
        }
        
        // Collision Detection
        return this.checkCollisions(playerBox);
    }

    checkCollisions(playerBox) {
        let hitObstacle = false;
        let coinsCollected = 0;

        // Optimization: Only check chunks near Z=0
        for (const chunk of this.chunks) {
            const z = chunk.floor.position.z;
            if (z < -30 || z > 10) continue; 

            // Check Obstacles
            for (const ob of chunk.obstacles) {
                const obBox = new THREE.Box3().setFromObject(ob.mesh);
                // Shrink obstacle box slightly to be forgiving
                obBox.expandByScalar(-0.2);

                if (obBox.intersectsBox(playerBox)) {
                    hitObstacle = true;
                }
            }

            // Check Coins
            for (const coin of chunk.coins) {
                if (coin.active) {
                    const coinBox = new THREE.Box3().setFromObject(coin.mesh);
                    if (coinBox.intersectsBox(playerBox)) {
                        coin.active = false;
                        coin.mesh.visible = false; // Hide immediately
                        coinsCollected++;
                    }
                }
            }
        }

        return { hit: hitObstacle, coins: coinsCollected };
    }
}

/**
 * ------------------------------------------------------------------
 * CLASS: GameManager
 * Orchestrates the Loop and States
 * ------------------------------------------------------------------
 */
class GameManager {
    constructor() {
        this.state = 'LOADING';
        this.score = 0;
        this.coins = 0;
        
        // Three.js Setup
        this.scene = new THREE.Scene();
        this.scene.background = new THREE.Color(0x87CEEB);
        this.scene.fog = new THREE.Fog(0x87CEEB, CONFIG.FOG_NEAR, CONFIG.FOG_FAR);

        this.camera = new THREE.PerspectiveCamera(60, window.innerWidth / window.innerHeight, 0.1, 200);
        this.camera.position.set(0, 3, 6);
        this.camera.lookAt(0, 1, 0);

        this.renderer = new THREE.WebGLRenderer({ antialias: true });
        this.renderer.setSize(window.innerWidth, window.innerHeight);
        this.renderer.shadowMap.enabled = true;
        this.renderer.shadowMap.type = THREE.PCFSoftShadowMap;
        document.getElementById('game-container').appendChild(this.renderer.domElement);

        // Lighting
        const hemiLight = new THREE.HemisphereLight(0xffffff, 0x444444, 1.0);
        this.scene.add(hemiLight);

        const dirLight = new THREE.DirectionalLight(0xffffff, 1.5);
        dirLight.position.set(10, 20, 10);
        dirLight.castShadow = true;
        dirLight.shadow.camera.top = 20;
        dirLight.shadow.camera.bottom = -20;
        dirLight.shadow.camera.left = -20;
        dirLight.shadow.camera.right = 20;
        dirLight.shadow.mapSize.width = 2048;
        dirLight.shadow.mapSize.height = 2048;
        this.scene.add(dirLight);

        // Managers
        this.assetManager = new AssetManager();
        this.clock = new THREE.Clock();

        // UI Binding
        this.ui = {
            loading: document.getElementById('loading-screen'),
            bar: document.getElementById('loader-bar'),
            hud: document.getElementById('hud'),
            score: document.getElementById('score-val'),
            coins: document.getElementById('coin-val'),
            gameOver: document.getElementById('game-over-screen'),
            finalScore: document.getElementById('final-score'),
            restartBtn: document.getElementById('restart-btn')
        };

        this.ui.restartBtn.addEventListener('click', () => this.restartGame());
        
        // Window Resize
        window.addEventListener('resize', () => {
            this.camera.aspect = window.innerWidth / window.innerHeight;
            this.camera.updateProjectionMatrix();
            this.renderer.setSize(window.innerWidth, window.innerHeight);
        });

        // Input Handling
        window.addEventListener('keydown', (e) => {
            if (this.state !== 'PLAYING') return;
            if (e.key === 'ArrowLeft' || e.key === 'a') this.player.handleInput('left');
            if (e.key === 'ArrowRight' || e.key === 'd') this.player.handleInput('right');
            if (e.key === 'ArrowUp' || e.key === 'w' || e.key === ' ') this.player.handleInput('up');
        });

        // Start Loading
        this.init();
    }

    async init() {
        await this.assetManager.loadAll((progress) => {
            this.ui.bar.style.width = `${progress * 100}%`;
        });

        // Loading Complete
        setTimeout(() => {
            this.ui.loading.classList.add('hidden');
            this.startGame();
        }, 500);
    }

    startGame() {
        this.state = 'PLAYING';
        this.score = 0;
        this.coins = 0;
        this.updateUI();
        this.ui.hud.classList.remove('hidden');
        this.ui.gameOver.classList.add('hidden');

        // Reset Scene Entities
        // Remove old if exists
        if (this.player) this.scene.remove(this.player.mesh);
        
        // Level Generator manages its own cleanup on reset usually, 
        // but for simplicity we assume full reload or reconstruct.
        // Let's just create new instances.
        
        // Important: LevelGenerator needs to clear old chunks from scene if restarting
        if(this.levelGen) {
            this.levelGen.chunks.forEach(c => {
                this.scene.remove(c.floor);
                c.obstacles.forEach(o => this.scene.remove(o.mesh));
                c.coins.forEach(co => this.scene.remove(co.mesh));
            });
        }

        this.player = new PlayerController(this);
        this.levelGen = new LevelGenerator(this);

        if (!this.loopRunning) {
            this.loopRunning = true;
            this.renderer.setAnimationLoop(() => this.render());
        }
    }

    restartGame() {
        this.startGame();
    }

    gameOver() {
        this.state = 'GAMEOVER';
        this.ui.gameOver.classList.remove('hidden');
        this.ui.finalScore.innerText = Math.floor(this.score);
        this.player.isDead = true;
        // Optional: Play stumble animation
    }

    updateUI() {
        this.ui.score.innerText = Math.floor(this.score);
        this.ui.coins.innerText = this.coins;
    }

    render() {
        if (this.state === 'PLAYING') {
            const dt = this.clock.getDelta();
            
            // Logic
            this.player.update(dt);
            
            const collisionResult = this.levelGen.update(dt, this.player.box);
            
            // Handle Collisions
            if (collisionResult.hit) {
                this.gameOver();
            }
            if (collisionResult.coins > 0) {
                this.coins += collisionResult.coins;
            }

            // Score Logic (based on speed/distance)
            this.score += this.levelGen.speed * dt * 0.1;
            this.updateUI();
        }

        this.renderer.render(this.scene, this.camera);
    }
}

// Entry Point
window.onload = () => {
    new GameManager();
};