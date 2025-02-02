# PaytureApi

# О проекте

Для работы с внешним API **Payture** было выбрано **ASP.NET Core Web API**, построенное по шаблону **Clean Architecture**. В проекте изначально добавлены классы для обработки ошибок и стандартизации ответа от бэкенда (`Error`, `ErrorList`, `Envelope`, расширения для ответа). Используется **Result pattern** из библиотеки **CSharpFunctionalExtensions**.

## Взаимодействие с внешним API

1. **HttpClientFactory**: Взаимодействие реализовано через `HttpClientFactory`. Основная логика находится в слое **Infrastructure**, см. [`ApiProvider.cs`](./Infrastructure/ApiProvider.cs).

2. **ApiRequest/Response**: В **Domain** расположены классы `...ApiRequest/Response`, которые служат для взаимодействия с внешним API. Также есть DTO без части `Api` — это обычные контракты для слоя **Presentation** (здесь — Web).

3. **Просмотр результатов**: Результаты можно посмотреть в консоли, через **Swagger**, а также в **unit-тестах**.
