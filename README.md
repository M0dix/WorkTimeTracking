# WorkTimeTracking

WorkTimeTracking - это .NET приложение, которое позволяет пользователям управлять отчетами о рабочем времени. В этом проекте реализованы шаблон CQRS с использованием MediatR, паттерн Repository и паттерн Unit Of Work.

## Содержание

- [Необходимые компоненты](#необходимые-компоненты)
- [Установка](#установка)
- [Запуск приложения](#запуск-приложения)
- [Структура проекта](#структура-проекта)


## Необходимые компоненты

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [PostgeSQL](https://www.postgresql.org/download/)

## Установка

1. Клонировать репозиторий:
   ```sh
   git clone https://github.com/M0dix/WorkTimeTracking.git
   cd WorkTimeTracking
   ```

2. Восстановить зависимости:
   ```sh
   dotnet restore
   ```

3. Обновить строку подключения к базе данных в `appsettings.json`.

4. Применить миграции базы данных:
   ```sh
   dotnet ef database update
   ```

## Запуск приложения

1. Запуск приложения:
   ```sh
   dotnet run --project WorkTimeTracking
   ```

2. Приложение будет доступно по адресам `https://localhost:7040` и `http://localhost:5017`.

## Структура проекта

- **Commands**: Содержит обработчики команд и связанную с ними логику.
- **Queries**: Содержит обработчики запросов и связанную с ними логику.
- **Controllers**: Содержит API контроллеры.
- **Persistence**: Содержит файлы и классы, отвечающие за взаимодействие с базой данных: конфигурации контекста данных, фабрика контекста, интерфейсы репозиториев (IUnitOfWork, IUserRepository, IWorkRepository) и их реализации, а также реализацию UnitOfWork для управления транзакциями.
- **Models**: Содержит доменные модели.
- **Middlewares**: Cодержит классы, реализующие middleware для обработки HTTP-запросов.
- **Migrations**: Содержит миграции базы данных. 
