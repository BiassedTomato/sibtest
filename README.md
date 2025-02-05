# Тестовое задание

## Описание стека
- Для веб-приложения используется ASP.Net Core MVC
- Десктоп сделан на базе WPF
- Бэкенд на ASP.Net Core WebAPI

Используется .Net 5.

## Запуск
Необходимы .net 5 Runtime и SDK. Проверена работоспособность под Windows 10, работоспособность под линуксом ожидается, но не гарантирована (WPF не кроссплатформен).
Разработка велась с использованием Visual Studio 2022 и ее интегрированных инструментов - это рекомендуемый способ. 
Альтернативно, dotnet CLI должен сработать тоже:

`dotnet run`

## Использование

Веб-интерфейс хостится на https://localhost:5007

Отчеты по магазинам: https://localhost:5007/reports/shop

Ответы по клиентам: https://localhost:5007/reports/client

Отчеты по ТС: https://localhost:5007/reports/vehicle

Отчеты по услугам: https://localhost:5007/reports/repairs


## Исправление возмодных проблем
В случае, если возникнет проблема с HTTPS сертификатами, следующая команда должна исправить ее:

В директории test:

`dotnet dev-certs https`

Команда установит валидные HTTPS сертификаты.
