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

> Project Overview:
A 3D infinite runner game mechanics engine (similar to Subway Surfers).

Main Mechanics:
- 3-lane continuous forward movement system.
- Procedural generation of track chunks (obstacles, coins, power-ups).
- Input handling: Left/Right swipe (lane change), Up swipe (jump), Down swipe (roll).
- Collision detection: Hitbox intersection ending the run or consuming a hoverboard.
- Difficulty curve: Gradual increase of base forward speed over time.

Technical Requirements:
- Language/Framework agnostic logic structure (adaptable for Unity/C# or iOS/Swift/SceneKit).
- Object pooling for memory-efficient chunk and coin generation.
- State machine for character animations (Run, Jump, Roll, Hoverboard, Stumble, Caught).

Visual & Style Specs:
- Vibrant, colorful, cartoonish aesthetics.
- Dynamic camera following the player character from a third-person rear perspective.

Functions to implement:
- generate_chunk(difficulty_level) -> ChunkData
- handle_swipe_input(direction) -> PlayerState
- check_collisions(player_hitbox, obstacle_colliders) -> GameEvent
- update_game_loop(delta_time) -> Void
"""

4.3 Enhanced Prompt
Это развернутый запрос для LLM, чтобы она написала полноценный и готовый к работе код (one-shot generation).
Промпт для копирования:
> "Act as a Senior Game Developer. I need you to write the core gameplay loop and logic for a 3-lane infinite runner mobile game similar to Subway Surfers.
> Context: The game features a character running forward automatically. The player swipes left, right, up, or down to dodge trains and barriers while collecting coins.
> Specific Requirements:
>  * Movement System: Implement a 3-lane system where the player interpolates smoothly between lanes (-1, 0, 1). Include jump logic with gravity and a roll logic that temporarily reduces the player's collider height.
>  * Procedural Generation: Create an Object Pooling system for level chunks. A chunk should randomly spawn coins in patterns and obstacles (static barriers or moving trains).
>  * Difficulty Logic: The forward speed variable must gradually increase based on the distance traveled.
>  * Power-ups & Items: Include logic for a 'Hoverboard' state that grants 1 extra life (prevents game over on next collision, but breaks the board).
>  * Game State: Implement a basic Game Manager handling 'Start', 'Playing', 'Paused', and 'Game Over' states.
> Output: Provide clean, well-commented, modular code. Please use [укажи нужный язык, например Swift/SpriteKit или C#/Unity]. Separate the logic into at least three classes/structures: PlayerController, LevelManager, and GameManager."
