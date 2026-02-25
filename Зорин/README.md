Часть 1: Игровой процесс и наблюдение
Вот заполненная таблица с анализом основных элементов игры, как и требуется в задании:
| Категория | Описание | Примеры |
|---|---|---|
| Игровые механики | Основные правила взаимодействия. | Swipe влево/вправо, прыжок, кувырок. |
| Объекты | Предметы в игровом мире. | Поезда, барьеры, монеты, бонусы (джетпак, магнит). |
| Система прокачки | Развитие персонажа. | Уровни множителя очков (Multiplier), прокачка длительности бонусов. |
| Препятствия | Преграды на пути. | Стоящие и движущиеся вагоны, баррикады, туннели. |
| Монеты и бонусы | Собираемые предметы. | Золотые монеты, буквы (Word Hunt), ключи, супер-кроссовки. |
| Скины | Внешний вид персонажа. | Jake, Tricky, Fresh и сезонные персонажи. |
| Скейтборды | Транспорт персонажа. | Базовый борд, доски с особыми способностями (например, суперскорость). |
| Ключи | Донатная валюта. | Валюта для воскрешения или покупки премиальных скинов. |
| Меню | Интерфейс игры. | Главное меню, магазин, миссии, экран паузы. |
----
Часть 2: Алгоритмическая структура
Логика работы бесконечного раннера (infinite runner) строится на процедурной генерации и постоянном просчете коллизий:
 * Старт: Игра начинается с загрузки начального уровня — прямой дорожки с базовыми препятствиями и монетами.
 * Бесконечный цикл: По мере движения запускается цикл генерации новых сегментов (чанков) пути. Каждый чанк содержит случайно сгенерированные, но проходимые комбинации вагонов и барьеров. Старые сегменты позади игрока удаляются из памяти для оптимизации.
 * Управление и физика: Движок непрерывно обрабатывает ввод от свайпов для перемещения между тремя линиями. Параллельно просчитывается пересечение хитбокса персонажа с препятствиями (коллизии).
 * Кривая сложности: Со временем глобальная переменная скорости персонажа постепенно возрастает. Это оставляет игроку всё меньше времени на реакцию, усложняя геймплей.
 * Окончание забега: При столкновении с преградой скрипт движения останавливается, и на экран выводится меню продолжения. Игрок может потратить ключи, чтобы побежать дальше, или вернуться в главное меню.
----
Часть 3: Детальный анализ
3.1 Механика персонажа
 * Управление: Свайпы (вверх — прыжок, вниз — кувырок, влево/вправо — смена линии).
 * Анимации движения: Плавные переходы между состояниями (бег, спотыкание при легком касании препятствия, прыжок, группировка в воздухе).
 * Состояния: Обычный бег, полет (джетпак), езда на скейтборде, падение/поимка инспектором.
3.2 Система препятствий
 * Типы препятствий: Статичные барьеры (низкие и высокие), стоящие вагоны, движущиеся навстречу поезда, тоннели.
 * Предупреждающие знаки: Светофоры загораются красным/зеленым, если на линии едет поезд.
 * Способы обхода: Перепрыгнуть (низкий барьер), прокатиться под ним (высокий барьер), сменить линию.
3.3 Внутренний маркетплейс
 * Структура магазина: Разделен на вкладки: бусты (одноразовые), апгрейды (прокачка длительности), персонажи, доски.
 * Виды товаров: Mystery Box, Score Booster, Headstart.
 * Система цен: Базовые предметы за монеты, премиальные за ключи или реальные деньги.
3.4 Система скинов
 * Базовые скины: Открываются за сбор специальных предметов в коробках (например, гитары для Fresh).
 * Премиум скины: Покупаются за ключи или реальные деньги.
 * Эффектные наборы (Outfits): Дополнительные стили для открытых персонажей (покупаются за ключи).
3.5 Скейтборды
 * Функционал: Дает временную неуязвимость (одну дополнительную жизнь) на 30 секунд. При столкновении доска ломается, но персонаж продолжает бег.
 * Виды и стоимость: От бесплатных базовых до дорогих досок с уникальными способностями.
 * Специальные эффекты: Суперпрыжок, плавное парение (Smooth Drift), телепортация, ускорение.
3.6 Донатная система
 * Ключи (Keys): Премиум-валюта.
 * Способы получения: Покупка за реальные деньги, редкий дроп в забеге, награда за миссии, просмотр рекламы.
 * Механика «продолжить игру»: Цена воскрешения растет в геометрической прогрессии (1 ключ, затем 2, 4, 8 и т.д.).
3.7 Интерфейс
 * Главное меню: Анимированный персонаж на путях, кнопки магазина, миссий, топ-игроков, кнопка "Tap to Play".
 * Меню паузы: Текущий счет, множитель, кнопки продолжения, выхода в меню и настроек.
 * Экран окончания: Подсчет очков, анимация побития рекорда, награды и кнопка рестарта.
----
Часть 4: Создание промпта для AI
Вот готовые структурированные запросы, которые можно скормить в Claude, GPT-4 или любую другую мощную модель.
4.2 Docstring Prompt
Этот формат отлично подойдет, например, на Python.

Project Overview:
Создание ядра бесконечного 3D-раннера (аналог Subway Surfers).
Жанр: Endless Runner.
Целевая платформа: Мобильные устройства.

Main Mechanics:
- Трехполосная система движения (Lane -1, Lane 0, Lane 1).
- Непрерывное движение вперед с постепенно увеличивающейся скоростью (Difficulty Curve).
- Управление свайпами: 
  * Влево/Вправо — смена полосы;
  * Вверх — прыжок (преодоление низких барьеров);
  * Вниз — кувырок (прохождение под высокими барьерами).
- Система столкновений: касание препятствия завершает игру, если не активирован Hoverboard.
- Сбор монет для увеличения счета.

Technical Requirements:
- Реализация пулинга объектов (Object Pooling) для генерации чанков уровня, препятствий и монет.
- Паттерн State Machine для управления состояниями игрока (Run, Jump, Roll, Hoverboard, Dead).
- Разделение логики на GameManager, PlayerController и LevelManager.

Visual Style and Art Direction:
- Яркая, мультяшная Voxel/Low-Poly графика.
- Динамичная камера от третьего лица (расположена позади и чуть сверху).
- Цветовая палитра: насыщенные цвета (Cyan для игрока, Red для поездов, Gold для монет).

System Interfaces:
def generate_level_chunk(difficulty: float) -> Chunk:
    '''Генерирует новый сегмент пути с паттернами препятствий и монет.'''
    pass

def process_input(swipe_direction: str, player_state: State) -> Action:
    '''Обрабатывает жест пользователя и инициирует движение, прыжок или кувырок.'''
    pass

def check_collisions(player_hitbox: Collider, objects: List[Collider]) -> InteractionType:
    '''Просчитывает коллизии. Возвращает тип взаимодействия (Сбор монеты, Смерть, Поломка доски).'''
    pass

----

4.3 Enhanced Prompt
адаптированный Enhanced Prompt для генерации HTML5-версии:

TECHNICAL DESIGN DOCUMENT: "Urban Sprinter Web 3D"
WebGL Endless Runner — One-Shot Generation Prompt
> Project Type: WebGL Browser Game (Three.js)
> Visual Style: Modern 3D Arcade (Low-Poly / Stylized)
> Target: Production-Ready Core Gameplay Loop Prototype with External Asset Loading
> Constraint: Use Vanilla JavaScript (ES6+) and Three.js. The code must be structured cleanly, assuming a standard web project folder hierarchy (index.html, style.css, main.js, and an /assets/ folder). Use GLTFLoader to import .glb models.
> 
0. EXTERNAL ASSETS & RESOURCES
The game relies entirely on external .glb models (e.g., from Kenney.nl). Do not use primitive geometries for game entities. Assume the following paths and animations exist in the project structure.

| Entity | File Path | Required Skeletal Animations |
|---|---|---|
| Player | ./assets/models/player.glb | Run, Jump, Roll, Idle, Stumble |
| Train (Obstacle) | ./assets/models/train.glb | None |
| Low Barrier | ./assets/models/barrier_low.glb | None |
| High Barrier | ./assets/models/barrier_high.glb | None |
| Coin | ./assets/models/coin.glb | Spin (or rotate via code) |
| Hoverboard | ./assets/models/hoverboard.glb | None |


0.1 Direct Asset URLs (CORS-Friendly)
Use THREE.GLTFLoader to load these exact URLs directly in your JavaScript code. These URLs are publicly accessible.

| Entity | Direct URL | Animation Instructions |
|---|---|---|
| Player | https://raw.githubusercontent.com/mrdoob/three.js/master/examples/models/gltf/Soldier.glb | Use Run for normal state. Map Walk for the roll/jump states if specific animations are missing. |
| Train/Obstacle | https://raw.githubusercontent.com/mrdoob/three.js/master/examples/models/gltf/BoxVertexColors.glb | Scale it horizontally (e.g., scale.set(3, 3, 10)) to resemble a train car. |
| Coin | https://raw.githubusercontent.com/mrdoob/three.js/master/examples/models/gltf/BoomBox.glb | Scale it down significantly (scale.set(10, 10, 10)) and rotate it continuously, OR fallback to a procedural golden CylinderGeometry. |

0.2 Critical Fallback System
The LLM MUST implement a fallback logic in the AssetManager.
 * Wrap the GLTFLoader.load() calls with an onError callback.
 * If any URL fails to load (due to CORS, 404, or network issues), the code MUST NOT CRASH.
 * It must automatically substitute the missing .glb with a procedurally generated THREE.Mesh (e.g., BoxGeometry for trains/barriers, CylinderGeometry for coins) with an appropriate MeshStandardMaterial color so the game remains fully playable.

Asset Loading Strategy
Implement a central AssetManager class that preloads all .glb files using THREE.GLTFLoader before starting the game loop. Show a loading screen/progress bar while assets are being fetched.
1. RENDERING & LIGHTING PIPELINE
To make MeshStandardMaterial look good on imported models, the lighting setup must be robust.
 * Renderer: Enable shadow maps: renderer.shadowMap.enabled = true; renderer.shadowMap.type = THREE.PCFSoftShadowMap;
 * Lighting: - HemisphereLight(0xffffff, 0x444444, 1.0) for global illumination.
   * DirectionalLight(0xffffff, 1.5) acting as the sun. Must cast shadows (castShadow = true). The shadow camera bounds must cover the visible track area dynamically.
 * Environment:
   * Sky color: #87CEEB (set as scene background).
   * Fog: scene.fog = new THREE.Fog(0x87CEEB, 40, 120) to hide chunk spawning.
2. TECHNOLOGY STACK & ARCHITECTURE
Class Architecture (Strict OOP)
GameManager
├── Properties: scene, camera, renderer, clock, state (LOADING, MENU, PLAYING, GAMEOVER)
├── Methods: init(), startLoop(), handleStateChange()

AssetManager
├── Properties: loaders, loadedModels (Map), loadingProgress
├── Methods: loadAll(paths), getModel(name)

PlayerController
├── Properties: model (THREE.Group), mixer (THREE.AnimationMixer), currentAction
├── Methods: update(dt), switchAnimation(name, crossfadeTime), moveLeft(), moveRight(), jump(), roll()

LevelGenerator
├── Properties: trackPool [], obstaclePool [], currentZ
├── Methods: spawnChunk(), recycleChunk(), updateMovement(dt, speed)

3. ANIMATION & MOVEMENT PHYSICS
3.1 Skeletal Animation Mixer
The player character has skeletal animations. Use THREE.AnimationMixer.
// When switching from RUN to JUMP:
const runAction = mixer.clipAction(animations.find(a => a.name === 'Run'));
const jumpAction = mixer.clipAction(animations.find(a => a.name === 'Jump'));
jumpAction.reset();
jumpAction.play();
runAction.crossFadeTo(jumpAction, 0.2, false);

3.2 Movement Physics
The Player stays fixed on the Z-axis, while the LevelGenerator moves all environmental chunks towards the camera on the Z-axis.
 * Lanes (X-axis): Lane -1 (X: -3.0), Lane 0 (X: 0.0), Lane 1 (X: 3.0). Use MathUtils.lerp for smooth lane switching.
 * Jump/Gravity: Manually apply vertical velocity. velocityY -= GRAVITY * dt; model.position.y += velocityY * dt;. Reset to 0 when hitting the floor.
 * Global Speed: let speed = 25.0; speed += dt * 0.2; (gradual difficulty increase).
4. OBSTACLES & GENERATION
Procedural Chunks with Instances/Clones
When spawning obstacles and coins, use SkeletonUtils.clone() from Three.js examples (or standard object cloning if no skeleton) to create multiple instances of the preloaded .glb models.
 * Bounding Boxes: Compute new THREE.Box3().setFromObject(mesh) after scaling to ensure accurate hitboxes for complex models. Update the Box3 every frame for moving objects or the jumping player.
5. UI & UX (HTML Overlay)
Create a DOM-based UI overlay with position: absolute; pointer-events: none; (except for buttons).
 * Loading Screen: A progress bar showing % of .glb files loaded.
 * HUD: Score (distance traveled) and Coin count in the top right.
 * Game Over: Blur the canvas filter via CSS (filter: blur(4px);), show a "Restart" button.
INSTRUCTIONS FOR LLM:
Provide the complete codebase divided into logical files (index.html, style.css, and main.js).
 * Use ES6 modules to import Three.js, GLTFLoader, and SkeletonUtils from https://unpkg.com/three@... CDNs.
 * Implement the AssetManager loading logic properly.
 * Implement the THREE.AnimationMixer logic for seamless transitions between 'Run', 'Jump', and 'Roll'.
 * Ensure accurate Box3 intersection logic for collision detection between the player model and obstacle models.
