# Starfall Arena

Starfall Arena is a small console game prototype where a hero explores a dangerous arena and fights enemies. This repository is used to practice project initialization, branching, and manual merge conflict resolution.

## Архитектура

Проект разделен по папкам и зонам ответственности:

- `Core` — базовая логика игры и компоненты состояния.
- `Entities` — игровые сущности, включая игрока и базовые объекты мира.
- `Enemies` и `Factories` — враги и их создание через фабрики.
- `Weapons` — оружие и модификаторы, построенные через декораторы.
- `Facades` — упрощенный запуск и подготовка игровой сессии.
- `StarfallArena.Tests` — unit-тесты для логики без привязки к консольному UI.

## Используемые паттерны

- `Singleton` — [GameManager](//wsl.localhost/Ubuntu-22.04/home/xrtp/project/Agile/StarfallArena/GameManager.cs)
- `Factory Method` — [EnemyFactory](//wsl.localhost/Ubuntu-22.04/home/xrtp/project/Agile/StarfallArena/Factories/EnemyFactory.cs), [OrcFactory](//wsl.localhost/Ubuntu-22.04/home/xrtp/project/Agile/StarfallArena/Factories/OrcFactory.cs), [GhostFactory](//wsl.localhost/Ubuntu-22.04/home/xrtp/project/Agile/StarfallArena/Factories/GhostFactory.cs)
- `Builder` — [CharacterBuilder](//wsl.localhost/Ubuntu-22.04/home/xrtp/project/Agile/StarfallArena/Builders/CharacterBuilder.cs)
- `Decorator` — [WeaponDecorator](//wsl.localhost/Ubuntu-22.04/home/xrtp/project/Agile/StarfallArena/Weapons/WeaponDecorator.cs) и модификаторы оружия
- `Facade` — [GameSessionFacade](//wsl.localhost/Ubuntu-22.04/home/xrtp/project/Agile/StarfallArena/Facades/GameSessionFacade.cs)
