Тестовое задание - сервис по сбору заявок.

Используемый стек:
Entity Framework Core, Postgresql, Npgsql.

Для запуска приложения необходимо:
1. В файле appsettings.json необходимо поменять строку подключения к базе данных.
2. Запустить проект.

UPD: 
В BAL\Services\ApplicationService.cs
прошу заменить строки 162-164

            application.Name = updatedApplication.Name ?? application.Name;
            application.Description = updatedApplication.Description ?? application.Description;
            application.Outline = updatedApplication.Outline ?? application.Outline;
            application.ActivityType = updatedApplication.ActvityTypeName;
На
            application.Name = updatedApplication.Name;
            application.Description = updatedApplication.Description;
            application.Outline = updatedApplication.Outline;

Поняла условия корректно только за несколько часов до делайна (будет урок, что надо задавать больше уточняющих вопросов).
Из-за спешки пропустла этот момент в сервисе. Большое спасибо!

Согласно полученным правкам, были внесены изменения:

- изменились маршруты, согласно описанию в задаче (Activity => activities; Application => applications);

- В отдельный контроллер был вынесен метод получения текущей не поданной заявки для указанного пользователя, 
а также изменён входящий параметр (Id заявки => Id пользователя);

- При попытке выполнить некорректное действие или при ошибке валидации возвращается понятное сообщение об ошибке,
в том числе проверка на длину входящих параметров;

- Устранена возможность отправки на рассмотрение заявки с обязательными параметрами, равными пустой строке;

- SubmitDate заполняется, отправленные заявки выводятся в /applications?submittedAfter;

- классы, не связанные логически, не наследуются друг от друга (например, ApplicationDto от ApplicationCreateDto);

- устранены проблемы, связанные с nullable reference types (например, метод ApplicationRepository.GetApplicationByApplicationIdAsync);

- исправлена проблема nullable и nonNullable полей;

- выделены отдельные сборки: слой с бизнес-логикой и слой доступа к данным. В контроллере должен остался только вызов класса бизнес-логики;

Также были внесены изменения:

- СУБД изменилась (SQL server => PostgreSQL);

- Добавились библиотеки для валидации данных:
 Fluent Validation и Fluent Result;

- Изменилась схема базы данных: 
1. В таблице Activities изменён PK (Guid => ActivityType).
2. В таблицу Applications добавлено навигационное свойство на таблицу Activities;
3. Таблица Authors удалена, так как содержала только одно поле Id.

- Атрибуты классов сущностей были заменены на fluen API;

- Добавлена асинхронность в методы, где она отсутствовала;

- Добавлен CancellationToken. 

Не смотря на срок в 7 дней, ещё есть что улучшить и поправить.

Поскольку условий относительно нейминга слоёв не было, я использовала следующую схему:

1. CallForPaperService_DAL: Data Access Layer для доступа к базе данных, миграциям, репозиторию.
2. CallForPaperService_BAL: Buisness Access Layer для доступа к логике приложения - сервисы, валидация, модели ДТО;
3. CallForPaperService_PL: Presentation Layer с контроллерами 

Пользуясь случаем, я хочу отметить
прекрасное оформление задания - всё наглядно, доступно, понятно.
Настолько подробный фидбек - все правки обоснованы, лаконичны, конструктивны.
Вами была проделана большая работа и я хочу поблагодарить вашу команду за возможность участия.
Большое спасибо за интересный опыт!
