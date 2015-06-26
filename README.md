# SmartVillage-Online <br>
test deploy on http://deploy-test.apphb.com/ <br>
**І. What is Smart Village?** <br>
Система «Розумне село» є єдиною, здатною до масштабування та  адаптації, інформаційною системою, що призначена для автоматизації  діяльності   сільських  і  селищних  рад  по  веденню погосподарських книг,  статистичного  обліку  землі, нерухомості, транспорту,  свійських  тварин  і  худоби  у  відповідності  до норм  законодавства України, а саме [Наказу Держкомстату від 08.12.10 р. № 491 про затвердження нової Інструкції з ведення погосподарського обліку в сільських, селищних та міських радах.](http://zakon.rada.gov.ua/cgi-bin/laws/main.cgi?nreg=z0009-11) <br>
Більше інофрмації на офсайті: http://sisoftware.biz/products/smart-village/

**II. What is Smart Village - Online?** <br>

Система “SmartVillage-Online” є [веб-додатком](https://en.wikipedia.org/wiki/Web_application) який побудований на основі нових технологій за концепцією [SaaS](https://en.wikipedia.org/wiki/Software_as_a_service) і є аналогом desktop-версії програми Smart Village 

**IIІ. Аrchitecture** <br>
![Image of Yaktocat](https://lh3.googleusercontent.com/L6jusrjFIXwCCUnFfekIbESPfdysu6X5kGPxhwnIoXn1nDA0HeUVzfAM4BUSh-Jc3Q5aihkb_ix-jS4=w1576-h611)

**IV. Instruments** <br>
Перелік інструментів які використовуються:
- [Microsoft Visual Studio 2013](https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx) 
- [Microsoft SQL Server 2014](https://www.microsoft.com/ru-ru/download/details.aspx?id=42299)
- [.NET Framework 4.5.1](https://www.microsoft.com/ru-ru/download/details.aspx?id=40779)
- [Entity Framework 5.0](https://msdn.microsoft.com/ru-ru/data/ef.aspx)
- [ASP.NET 4](http://www.asp.net/)
- [IIS 7.0](https://en.wikipedia.org/wiki/Internet_Information_Services)
- [IB Expert](http://www.ibexpert.net/ibe/)
- [GIT](https://git-scm.com/)
- Delphi 7 and Components
- [Firebird server](http://www.firebirdsql.org/)
- SmartVillage source code

**V. Subversion** <br>
Існує 2 Git-репозиторія на GitHub:<br>
__*SmartVillageOnline*__ - source code <br>
Містить у собі Visual Studio Solution який складається з трьох проектів:
* *Domain* - це бібліотека (Class Library) яка містить доменні об’єкти і логіку; підтримує механізм збереження за домогою патернів [Repository](https://msdn.microsoft.com/en-us/library/ff649690.aspx) та [UnitOfWork](http://www.codeproject.com/Articles/581487/Unit-of-Work-Design-Pattern), створених використовуючи Entity Framework. Реалізує Data Layer архітектури.<br>
* *WebUI* - є проектом ASP.NET [MVC](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller) 4 Web Application і містить  контролери і представлення; є інтерфейсом додатку і реалізує Presentation layer і Business layer архітектури.<br>
* *UnitTests* - (Unit Test Project) містить модульні тести для 2-х проектів<br>

__*SmartVillageOnlineDB*__ - скрипти бази даних, має наступну структуру:

 ![Image of Yaktocat](https://lh3.googleusercontent.com/tYQoHadSJwjk_4GYiAPG4sgUlZZyQWAEuJ10BmfL-Mm1e-8ztTC3TQc_hPdIXeTXUmhpIfVGt6fQnXg=w1576-h611)

**VI. Domain**
Бібліотека для роботи з даними реалізована на основі [generic](https://en.wikipedia.org/wiki/Generic_programming)-патерну [Repository](https://msdn.microsoft.com/en-us/library/ff649690.aspx) і патерну [UnitOfWork](http://www.codeproject.com/Articles/581487/Unit-of-Work-Design-Pattern) <br>.
Використовується [MS SQL Server 2014](http://www.microsoft.com/ru-ru/server-cloud/products/sql-server/) та [Entity Framework (EF)](https://msdn.microsoft.com/ru-ru/data/ef.aspx), який є [ORM-платформою](https://en.wikipedia.org/wiki/Object-relational_mapping) .NET. Платформа ORM дозволяє працювати
з таблицями, стовпцями і рядками в реляційній базі даних за  допомогою звичайних об’єктів C#.

 ![Image of Yaktocat](https://lh3.googleusercontent.com/CwuKjt0MJgsQSABPq0Db49zxRhUItPCTzneCctw0-NoNRNrm5FPWbAgX8VODaJOrNr7IvPiDd_T4224=w1576-h611)
 
Має таку структуру файлів:

 ![Image of Yaktocat](https://lh6.googleusercontent.com/-W9c2SaOQX-IimIp0MIqctI0Q_qWdTROcBXkP4aVy65I0iWHfXQ6CgOkqCRhRE0DHkAbXr9FOk-ruuc=w1576-h611)
 
* *Abstract* - містить generic-інтерфейс IRepository який описує загальну структуру репозиторію і абстрактний базовий клас BaseEntity для всіх таблиць бази даних.  
* *Concrete* - клас EFDbContext реалізує клас DbContext  який відповідає за підключення до бази даних. EFRepository реалізує інтерфейс IRepository та описує основні операції для роботи з даними. 
* *Entities* - опис таблиць бази даних
* *Mapping*  - конфігурація таблиць
* *Migrations*  - Параметри міграції бази.

 ![Image of Yaktocat](https://lh5.googleusercontent.com/_2MidbjNnHesVy83OP2YCwvqaPfQT7nh1MpEZABR4rsM4dSTQzbZYfyTe3ts0Xc6ww5ZjX5REL8p9bg=w1576-h611)
 
**VI. UnitTests**<br>
Проект призначений для створення [юніт-тестів](https://en.wikipedia.org/wiki/Unit_testing). Ми збираємося слідувати підходу [Test-driven development (TDD).](https://en.wikipedia.org/wiki/Test-driven_development)
<br>
Для створення тестів за технологією TDD слід дотримуватися таких пунктів:
* Визначаємо, що нам потрібно додати нову функцію або метод в додаток.
* Пишемо тест, який буде перевіряти поведінку нової функції, до того як вона буде написана.
* Запускаємо тест і отримуємо негативний результат.
* Пишемо код, який реалізує функцію.
* Знову запускаємо тест і коригуємо код, поки тест не виконається успішно.
* Якщо потрібно, оптимізуємо код (проводимо рефакторинг), наприклад, реорганізація виразів, перейменування змінних і так далі.
* Запускаємо тест, щоб підтвердити, що зміни не вплинули на поведінку доповнень
<br>
В методах модульного тестування потрібно дотримуватися патерну [arrange/act/assert(A/A/A)](http://www.arrangeactassert.com/why-and-what-is-arrange-act-assert/)<br>
Одним з хороших підходів полягає в використанні [mock-об’єктів](https://en.wikipedia.org/wiki/Mock_object), які симулюють
функціональність реальних об’єктів проекту. Mock-об’єкти дозволяють звузити фокус тестів, так щоб можна було перевірити тільки той функціонал в якому ми зацікавлені.

 ![Image of Yaktocat](https://lh5.googleusercontent.com/MgXSxH4UsVKKelk2WRAiKFbbCNg2KVj7M73CGj3fC3o_2hlc89tznd3ODQ2mUUhhiLtudCSiTmAZ4K8=w1576-h611)

**VII. WebUI** <br>
WebUI - є проектом [ASP.NET MVC.](http://www.asp.net/mvc)<br>

 ![Image of Yaktocat](https://lh5.googleusercontent.com/jiledPjPGFatuWuyjBlkK3FMXaS1qJk9MPxnzOC0jTTo1Yuus6gIB2Lz-hDfpb9090vImN9KePiyfYI=w1576-h611)
 
 Але в першу чергу реалізує програний інтерфейс [WebAPI](https://en.wikipedia.org/wiki/Web_API), який дозволяє легко створювати служби [HTTP](https://en.wikipedia.org/wiki/Hypertext_Transfer_Protocol) для широкого діапазону клієнтів, включаючи браузери і мобільні пристрої. WebUI - є [RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer) додатком на платформі [.NET Framework](https://en.wikipedia.org/wiki/.NET_Framework).
 <br>
 Реалізація клієнтської частини:
 
  ![Image of Yaktocat](https://lh3.googleusercontent.com/vXNPmP1cpNwol618C9I5agoICu7IlUxGzKZalUuU5rluzkcPXlUfSBBfZPDDspbjQXsAoFT910PESNk=w1576-h611)
  
Додаткові інструменти:
* [Ninject - DI(Dependency Injection)](https://en.wikipedia.org/wiki/Dependency_injection) контейнер для побудови слабо-зв’язаних компонентів
* [Moq](https://en.wikipedia.org/wiki/Mock_object) - фреймворк для модульного тестування. Це набір мокінг інструментів
* [Twitter Bootstrap](http://getbootstrap.com/)(+/-)
* [jQuery](https://jquery.com/)
* [knockoutjs](http://knockoutjs.com/)

