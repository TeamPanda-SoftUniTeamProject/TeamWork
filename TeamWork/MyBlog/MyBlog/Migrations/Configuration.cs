using MyBlog.Models;

namespace MyBlog.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MyBlog.Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                CreateUser(context, "admin@gmail.com", "123", "System Administrator");
                CreateUser(context, "pesho@gmail.com", "123", "Peter Petrov");
                CreateUser(context, "mariika@gmail.com", "123", "Mariya Ivanova");
                CreateUser(context, "gosho@gmail.com", "123", "Georgi Georgiev");

                CreateRole(context, "Administrators");
                AddUserToRole(context, "admin@gmail.com", "Administrators");

                CreatePost(context,
                    title: "Some title",
                    body: @"Let's writing some text in my post body",
                    date: new DateTime(2016, 08, 15, 17, 53, 48),
                    authorUsername: "mariika@gmail.com"
                );

                CreatePost(context,
                    title: "ASP.NET MVC",
                    body: @"ASP.NET MVC е платформа, създадена от Microsoft, която служи за изработване на уеб приложения, използвайки модела Model-View-Controller (MVC). Платформата използва C#, HTML, CSS, JavaScript и бази данни. ASP.NET MVC е съвременно средство за изграждане на уеб приложения, което не замества изцяло уеб формите. Платформата включва нови тенденции в разработката на уеб приложения, притежава много добър контрол върху HTML и дава възможност за създаване на всякакви приложения. ASP.NET MVC може да бъде много лесно тествана и допълвана, защото е изградена от отделни модули, които са изцяло независими едни от други. Чрез платформата се създават цялостни приложения, които се стартират, а не единични скриптове (като при PHP например).",
                    date: new DateTime(2016, 08, 11, 08, 22, 03),
                    authorUsername: "mariika@gmail.com"
                );

                CreatePost(context,
                    title: "MVC модели",
                    body: @"Моделът представлява част от приложението, което реализира домейн логиката, също известна като бизнес логика. Домейн логиката обработва данните, които се предават между базата данни и потребителския интерфейс. Например, в една система за инвентаризация, моделът отговаря за това дали елемент от склада е наличен. Моделът може да бъде част от заявлението, което актуализира базата данни когато даден елемент е продаден или доставен в склада. Често моделът съхранява и извлича официална информация в базата данни.",
                    date: new DateTime(2016, 07, 27, 17, 53, 48),
                    authorUsername: "pesho@gmail.com"
                );

                CreatePost(context,
                    title: "Контролери",
                    body: @"Контролерите са класове, които се създават в MVC приложението. Намират се в папка Controllers. Всеки един клас ,който е от този тип, трябва да има име завършващо с наставка ""Controller"". Контролерите обработват постъпващите заявки, въведени от потребителя и изпълняват подходящата логика за изпълнение на приложението. Класът контролер е отговорен за следните етапи на обработка:

    Намиране и извикване на най-подходящия метод за действие (action method) и валидиране, че може да бъде извикан.
    Взимането на стойности, които да се използват като аргументи в метода за действие.
    Отстраняване на всички грешки, които могат да възникнат по време на изпълнението метода за действие.
    Осигуряване на клас WebFormViewEngine по подразбиране за отваряне на страници с изглет от тип ASP.NET.

За да създадем контролер натискаме дясното копче на мишката върху папката ""controllers"" в прозореца ""solution explorer"" на Visual Studio, избираме ""add"" и след това ""controller"".",
                    date: new DateTime(2016, 02, 18, 22, 14, 38),
                    authorUsername: "admin@gmail.com"
                );

                CreatePost(context,
                    title: "Списък резултати от дейстия",
                    body: @"Action Results

    View():- Представлява ASP.NET MVC изглед т.е., когато вашия браузър връща HTML. Това е най-рапространения ""ActionResult"" ,който може да върне един контролер.

    PartialView():- Извиква част от ASP.NET MVC изгледа.

    RedirectToAction():- Пренасочва от едно контролер действие в друго. Параметри с които може да се изполва това действие са:

-actionName: Името на действието.
-controllerName: Името на контролера.
-routeValues: Стойностите които са предадени на действието.

Метода RedirectToAction() връща ""302 found HTTP"" статус код на браузъра, за да може да направи пренасочването към новото действие. Едно от предимствата на това действие е, че когато се прави пренасочване в браузъра — полето за адреси се обновява с новия URL линк. Недостатък е, че трябва да се направи повторна заявка от браузъра към сървъра.

    Redirect():- Пренасочва към друг контролер или URL линк.
    Content():- Данни които постъпват към браузъра. Параметрите, които могат да се използват като аргументи, са:

-string: Изобразява string на браузъра.
-contentype: Типът MIME на данните (по подразбиране за text/html).
-contentEncoding: Текстовото кодиране на данните (например:-Unicode или ASCII)

    Json():- JavaScript object Notation (JSON) e изобретен от Douglas Crockford като по-лека алтернатива на XML за пращане на данни по интернет в Ajax приложения. Метода Json() използва клас в .NET framework наречен JavaScriptSerializer за да преобразува обект в JSON репрезентация.

    File():- Връщане на фаил от действие. Този метод приема следните параметри:

-filename, contentType, fileDownloadName, fileContents, fileStream.

    JavaScript():- Представлява JavaScript фаил.

    HandleUnknownAction():- Този метод се извиква автоматично когато контролера не може да намери ресурс. По подразбиране метода изкарва грешка ""404 resource Not Found"". Съобщението за грашка може да бъде сменено с друго, това обаче изисква да се пренапише контролер класа.
",
                    date: new DateTime(2016, 01, 11, 19, 02, 05),
                    authorUsername: "admin@gmail.com"
                );

                CreatePost(context,
                    title: "Методи за действие",
                    body: @"В ASP.NET приложения, които не ползват MVC Framework, взаимодействията с потребителя са организирани и контролирани чрез страници. За разлика от това в приложения с MVC framework взаимодействията с потребителя са организирани чрез контролери и методи за действие. Контролерът определя метода за действие и може да включва толкова методи за действие,колкото са необходими.

Методи за действие обикновено имат функции, които са пряко свързани с взаимодействието с потребителя. Примери за взаимодействие с потребителите са въвеждане на URL адрес в браузъра, кликване върху линк, и подаването на формуляр. Всяко едно от тези потребителски взаимодействия изпраща заявка към сървъра. Във всеки един от тези случаи, URL адреса от заявката съдържа информация, която MVC Framework използва за да включи метод за действие.",
                    date: new DateTime(2016, 07, 19, 17, 36, 52),
                    authorUsername: "pesho@gmail.com"
                );

                context.SaveChanges();
            }
        }

        private void CreateUser(ApplicationDbContext context,
            string email, string password, string fullName)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FullName = fullName
            };

            var userCreateResult = userManager.Create(user, password);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }
        }

        private void CreateRole(ApplicationDbContext context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(roleName));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }
        }

        private void AddUserToRole(ApplicationDbContext context, string userName, string roleName)
        {
            var user = context.Users.First(u => u.UserName == userName);
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var addAdminRoleResult = userManager.AddToRole(user.Id, roleName);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
        }

        private void CreatePost(ApplicationDbContext context,
            string title, string body, DateTime date, string authorUsername)
        {
            var post = new Post();
            post.Title = title;
            post.Body = body;
            post.Date = date;
           
            post.Author = context.Users.Where(u => u.UserName == authorUsername).FirstOrDefault();
            context.Posts.Add(post);
        }
    }
}
