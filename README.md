# TehnoTestVK

***Необходимо реализовать API приложение на ASP.NET Core (5 или более поздняя версия).***
**Требования бизнес-логики и ограничения:**
- [x] Формат запроса/ответа должен быть JSON.
- [x] Методы API должны быть асинхронными.
- [x] В качестве СУБД необходимо использовать PostgreSQL.
- [x] В качестве ORM необходимо использовать EntityFrameworkCore.
- [x] В качестве моделей данных должны использоваться следующие сущности:
  - [x] user (id, login, password, created_date, user_group_id, user_state_id)
  - [x] user_group (id, code, description) Возможные значения для code (Admin, User)
  - [x] user_state (id, code, description) Возможные значения для code (Active, Blocked).

- [x] Приложение должно позволять добавлять/удалять/получать пользователей. Получить можно
как одного, так и всех пользователей (добавление/удаление только по одному). При получении
пользователей должна возвращаться полная информация о них (c user_group и user_state).
- [x] Система должна не позволять иметь более одного пользователя с user_group.code = "Admin".
- [x] После успешной регистрации нового пользователя, ему должен быть выставлен статус "Active".
Добавление нового пользователя должно занимать 5 сек. За это время при попытке добавления
пользователя с таким же login должна возвращаться ошибка.
- [x] Удаление пользователя должно осуществляться не путём физического удаления из таблицы, а
путём выставления статуса "Blocked" у пользователя.
- Допускается добавлять вспомогательные данные в существующие таблицы.

**ОПЦИОНАЛЬНО**
- В качестве способа авторизации следует использовать Basic-авторизацию.
- Реализовать пагинацию для получения нескольких пользователей.
- Написать unit-тесты с помощью xUnit.
