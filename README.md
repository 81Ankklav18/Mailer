# Mailer

# Описание
Десктопная программа позволяет обмениваться сообщениями с помощью базы данных и веб-сервиса для взаимодействия с ней

# Стек технологий
1. C# WPF
2. C# Web Service asmx
3. MS SQL Server

# Основной функционал
1. Регистрация пользователей в базе данных
2. Авторизация пользователя+создание подключения к БД (пароли хранятся в открытом виде)
3. Обновление списка входящих сообщений
4. Создание нового сообщения
5. Завершение сессии
6. Просмотр текста сообщения

# Ограничения
1. Отсутствует многопоточная реализация
2. Отсутствуют обработчики ошибок
3. Удаление писем как из пользовательского клиента, так и из базы

Ограничения не считаются критичными, или сложными в реализации, потому были допущены в данной программе.