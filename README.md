# Utis_Test
Приложение позволяет работать с задачами (Название, Описание, Дата исполнения и Статус): создавать, изменять, удалять или просматривать задачи с фильтрацией по статусу и пагинацией. Все задачи сохраняются в PostgreSQL. Приложение представляет из себя REST-сервис, написанный на языке программирования C# с использованием EntityFramework.

## Технологии
- REST API
- ASP.NET, .NET 8.0
- Entity Framework Core 9.0.7
- Npgsql 9.0.4
- PostgreSQL 17

## Установка
1. Склонировать проект.
2. Проверить, что локально установлен Postgres.
3. Открыть файл ```<проект>/Utis_test/appsettings.json``` и для параметра ```"DefaultConnection"``` прописать свои данные для подключения к Postgres вместо ```***```.
4. Сбилдить и запустить приложение
   - ВАЖНО! При первом запуске приложения в консоли появится ошибка: ```Microsoft.EntityFrameworkCore.Database.Connection[20004] An error occurred using the connection to database '<db_name>' on server 'tcp://localhost:<db_port>.```. На текущий момент не обращаем на неё внимания. Несмотря на ошибку, БД создалась, приложение запустилось и работает. В будущем постараюсь ошибку исправить.
5. После выполнения всех шагов в Postgres появится новая БД с таблицами ```Tasks(Id, Title, Description, DueDate, StatusId)```, ```TaskStatuses(Id, Name)```, заполненная данными ```[(1, "New"), (2, "InProgress"), (3, "Completed"), (4, "Overdue")]```, и вспомогательная таблица ```__EFMigrationsHistory``` для истории миграций. Таблица Tasks на момент запуска приожения будет пустой. 

## Тестирование
Тестировать работу приложения удобнее всего через Postman (или любой аналог), используя следующие запросы:
- GET: ```/api/tasks``` - Получить все задачи. Для пагинации в параметры запроса можно добавить ```page``` и ```pageSize```, которые по умолчанию равны 1 и 10 соответственно.
- GET: ```/api/tasks/filter?status={название_статуса}``` - Получить все задачи, отфильтрованные по статусу (регистр не учитывается). Дополнительно можно использовать параметры для пагинации, как в предыдущем примере.
- GET: ```/api/tasks/{id}``` - Получить задачу по ```id```.
- UPDATE: ```/api/tasks/{id}``` - Изменить задачу с ```id``` в соответствии с новыми полями, указанными в теле запроса. Пример тела запроса в формате JSON:
  ```sh
  {
    "Title": "New Title",
    "Description": "New Description",
    "DueDate": "2025-02-05T13:43:36.993825Z",
    "StatusName": "Completed"
  }
  ```
  Важно! Метод UPDATE в текущей реализации принимает именно объект задачи, поэтому нужно, чтобы все поля объекта в теле запроса были заполнены соответсвующими значениями (новыми или старыми).
- POST: ```/api/tasks``` - Добавить задачу, которая указана в теле запроса. Пример тела запроса как в предыдущем примере.
- DELETE: ```/api/tasks/{id}``` - Удалить задачу с заданным ```id```.

## Что нужно улучшить
- Добавить Docker (запуск в контейнере, использование docker-compose) 
- Добавить асинхронность
- Доделать логирование
- Исправить ошибку при первом запуске от ```DbContext.Database.Migrate()```
