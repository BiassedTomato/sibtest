# Тестовое задание

## Описание стека
- Для веб-приложения используется ASP.Net Core MVC
- Десктоп сделан на базе WPF
- Бэкенд на ASP.Net Core WebAPI
- СУБД PostgreSQL, развернутая в Docker, официальный образ. Запуск с портом 5432; пользователь, пароль, название базы - "postgres".

Используется .Net 5.

## Запуск
Необходимы .net 5 Runtime и SDK. Проверена работоспособность под Windows 10, работоспособность под линуксом ожидается, но не гарантирована (WPF не кроссплатформен).
Разработка велась с использованием Visual Studio 2022 и ее интегрированных инструментов - это рекомендуемый способ. 
Альтернативно, dotnet CLI должен сработать тоже:

`dotnet run`

Для работы с десктопом в файл App.config нужно добавить ИНН сервиса (параметр `shopId`). При запуске бэкенда в базу данных сидится тестовый сервис с ИНН `1234567890`.

Перед запуском бэкенда (`/test`) необходимо применить миграции: `dotnet ef database update`. Строка подключения в `AppContext.cs` редактируется по мере необходимости с необходимыми параметрами подключения. 

От бэкенда зависят оба приложения, потому он должен быть запущен в первую очередь.

## Использование
### Десктоп (`/desktop/ShopDesktop`)
Последовательность работы с десктоп-приложением такая:
- Человек, работающий с приложением (администратор) регистрирует клиента (если он не зарегистрирован)
- Клиенту добавляется новое ТС, в случае если оно ранее не было зарегистрировано
- Создается новая услуга. Выбирается ТС и тип услуги
- При изменении статуса услуги он меняется в отдельной вкладке. При изменении статуса на Завершена или Отменена услуга автоматически закрывается
- Идентификация пользователя проводится по ИНН, с которым пользователь был зарегистрирован

### Веб-интерфейс (`CompanyWebApp`)

Следующие эндпоинты используются управляющей компанией:

Веб-интерфейс хостится на https://localhost:5007

Отчеты по магазинам: https://localhost:5007/reports/shop

Ответы по клиентам: https://localhost:5007/reports/client

Отчеты по ТС: https://localhost:5007/reports/vehicle

Отчеты по услугам: https://localhost:5007/reports/repairs


Клиент использует эндпоинт:

https://localhost:5007/client/report

Сервис использует эндпоинт:

https://localhost:5007/shop/report


## Исправление возможных проблем
В случае, если возникнет проблема с HTTPS сертификатами, следующая команда должна исправить ее:

В директории test:

`dotnet dev-certs https`

Команда установит валидные HTTPS сертификаты.


## Прочее
Отладка проводилась силами DBeaver, дебаггера VS22 и Postman.
