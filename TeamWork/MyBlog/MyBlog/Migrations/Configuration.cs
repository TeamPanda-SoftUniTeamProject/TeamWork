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
                CreateUser(context, "gery@gmail.com", "123", "Gergana Icheva");
                CreateUser(context, "stoyan@gmail.com", "123", "Stoyan Stoyanov");
                CreateUser(context, "valeri@gmail.com", "123", "Valeri Vasilev");
                CreateUser(context, "borislav@gmail.com", "123", "Borislav Georgiev");
                CreateUser(context, "danzo@gmail.com", "123", "Danzo Balkanski");
                CreateUser(context, "ivan@gmail.com", "123", "Ivan Iliev");
                CreateUser(context, "kiricho@gmail.com", "123", "Kirilcho Mitrev");
                CreateUser(context, "nady@gmail.com", "123", "Nadya Nadence");

                CreateRole(context, "Administrators");
                AddUserToRole(context, "admin@gmail.com", "Administrators");

                CreatePost(context,
                    title: "ASP.NET MVC",
                    body: @"The ASP.NET MVC is a web application framework developed by Microsoft, which implements the model–view–controller (MVC) pattern. It is open-source software, apart from the ASP.NET Web Forms component which is proprietary.

In the later versions of ASP.NET, ASP.NET MVC, ASP.NET Web API, and ASP.NET Web Pages (a platform using only Razor pages) will merge into a unified MVC 6.[3] The project was initially called ASP.NET vNext and was later renamed to ASP.NET Core",
                    date: new DateTime(2016, 08, 15, 17, 53, 48),
                    authorUsername: "mariika@gmail.com"
                );

                CreatePost(context,
                    title: "Model–view–viewmodel",
                    body: @"Model–view–viewmodel (MVVM) is a software architectural pattern.

MVVM facilitates a separation of development of the graphical user interface – be it via a markup language or GUI code – from development of the business logic or back-end logic (the data model). The view model of MVVM is a value converter;[1] meaning the view model is responsible for exposing (converting) the data objects from the model in such a way that objects are easily managed and presented. In this respect, the view model is more model than view, and handles most if not all of the view's display logic.[1] The view model may implement a mediator pattern, organizing access to the back-end logic around the set of use cases supported by the view.

MVVM is a variation of Martin Fowler's Presentation Model design pattern.[2][3][4] MVVM abstracts a view's state and behavior in the same way,[3] but a Presentation Model abstracts a view (creates a view model) in a manner not dependent on a specific user-interface platform.
MVVM and Presentation Model both derive from the model–view–controller pattern (MVC).

MVVM was developed by Microsoft architects Ken Cooper and Ted Peters specifically to simplify event-driven programming of user interfaces—by exploiting features of Windows Presentation Foundation (WPF) (Microsoft's .NET graphics system) and Silverlight (WPF's Internet application derivative).[3] John Gossman, one of Microsoft's WPF and Silverlight architects, announced MVVM on his blog in 2005.

Model–view–viewmodel is also referred to as model–view–binder, especially in implementations not involving the .NET platform. ZK (a web application framework written in Java) and KnockoutJS (a JavaScript library) use model–view–binder.[",
                    date: new DateTime(2016, 08, 11, 08, 22, 03),
                    authorUsername: "mariika@gmail.com"
                );

                CreatePost(context,
                    title: "Components of MVVM pattern",
                    body: @"
Model
    Model refers either to a domain model, which represents real state content (an object-oriented approach), or to the data access layer, which represents content (a data-centric approach).[citation needed]

View
    As in the MVC and MVP patterns, the view is the user interface (UI).[further explanation needed]

View model
    The view model is an abstraction of the view exposing public properties and commands. Instead of the controller of the MVC pattern, or the presenter of the MVP pattern, MVVM has a binder. In the view model, the binder mediates communication between the view and the data binder.[clarification needed] The view model has been described as a state of the data in the model.[7]

Binder
    Declarative data- and command-binding are implicit in the MVVM pattern. In the Microsoft solution stack, the binder is a markup language called XAML.[8] The binder frees the developer from being obliged to write boiler-plate logic to synchronize the view model and view. When implemented outside of the Microsoft stack the presence of a declarative databinding technology is a key enabler of the pattern.",
                    date: new DateTime(2016, 07, 27, 17, 53, 48),
                    authorUsername: "pesho@gmail.com"
                );

                CreatePost(context,
                    title: "Rationale",
                    body: @"MVVM was designed to make use of data binding functions in WPF (Windows Presentation Foundation) to better facilitate the separation of view layer development from the rest of the pattern, by removing virtually all GUI code (""code-behind"") from the view layer.[10] Instead of requiring user experience (UX) developers to write GUI code, they can use the framework markup language (e.g., XAML) and create data bindings to the view model, which is written and maintained by application developers. The separation of roles allows interactive designers to focus on UX needs rather than programming of business logic. The layers of an application can thus be developed in multiple work streams for higher productivity. Even when a single developer works on the entire code base a proper separation of the view from the model is more productive as user interface typically changes frequently and late in the development cycle based on end-user feedback.

The MVVM pattern attempts to gain both advantages of separation of functional development provided by MVC, while leveraging the advantages of data bindings and the framework by binding data as close to the pure application model as possible.[10][11][12][clarification needed] It uses the binder, view model, and any business layers' data-checking features to validate incoming data. The result is the model and framework drive as much of the operations as possible, eliminating or minimizing application logic which directly manipulates the view (e.g., code-behind).",
                    date: new DateTime(2016, 02, 18, 22, 14, 38),
                    authorUsername: "admin@gmail.com"
                );

                CreatePost(context,
                    title: "Criticism",
                    body: @"A criticism of the pattern comes from MVVM creator John Gossman himself,[13] who points out overhead in implementing MVVM is ""overkill"" for simple UI operations. He states for larger applications, generalizing the ViewModel becomes more difficult. Moreover, he illustrates data binding in very large applications can result in considerable memory consumption.",
                    date: new DateTime(2016, 01, 11, 19, 02, 05),
                    authorUsername: "admin@gmail.com"
                );

                CreatePost(context,
                    title: "Model–view–adapter",
                    body: @"Model–view–adapter (MVA) or mediating-controller MVC is a software architectural pattern and multitier architecture. In complex computer applications that present large amounts of data to users, developers often wish to separate data (model) and user interface (view) concerns so that changes to the user interface will not affect data handling and that the data can be reorganized without changing the user interface. MVA and traditional MVC both attempt to solve this same problem, but with two different styles of solution. Traditional MVC arranges model (e.g., data structures and storage), view (e.g., user interface), and controller (e.g., business logic) in a triangle, with model, view, and controller as vertices, so that some information flows between the model and views outside of the controller's direct control. The model–view–adapter solves this rather differently from the model–view–controller by arranging model, adapter or mediating controller and view linearly without any connections whatsoever directly between model and view.",
                    date: new DateTime(2016, 07, 19, 17, 36, 52),
                    authorUsername: "pesho@gmail.com"
                );
                CreatePost(context,
                    title: "View and model do not communicate directly",
                    body: @"The view is completely decoupled from the model such that view and the model can interact only via the mediating controller or adapter between the view and the model.[1] Via this arrangement, only the adapter or mediating controller has knowledge of both the model and the view, because it is the responsibility of solely the adapter or mediating controller to adapt or mediate between the model and the view—hence the names adapter and mediator. The model and view are kept intentionally oblivious of each other. In traditional MVC, the model and view are made aware of each other, which might permit disadvantageous coupling of view (e.g., user interface) concerns into the model (e.g., database) and vice versa, when the architecture might have been better served by the schema of the database and the presentation of information in the user-interface are divorced entirely from each other and allowed to diverge from each other radically. For example, in a text editor, the model might best be a piece table (instead of, say, a gap buffer or a linked list of lines). But, the user interface should present the final resting state of the edits on the file, not some direct information-overload presentation of the piece-table's meticulous raw undo-redo deltas and incremental operations on that file since the current editing session began.",
                    date: new DateTime(2016, 08, 24, 13, 24, 33),
                    authorUsername: "gery@gmail.com"
                );
                CreatePost(context,
                    title: "Model is intentionally oblivious of views",
                    body: @"This separation of concerns permits a wide variety of different views to indirectly access the same model either via exactly the same adapter or via the same class of adapters. For example, one underlying data-storage model and schema and technology could be accessed via a wide variety multiple different views—e.g., Qt GUI, Microsoft MFC GUI, GTK+ GUI, Microsoft .NET GUI, Java Swing GUI, Silverlight website, and AJAX website—where (unlike traditional MVC) the model is kept completely oblivious of what information flows toward these user interfaces. The adapter or class of adapters keeps the model completely oblivious that it is supporting multiple of the user interfaces and perhaps even supporting this variety concurrently. To the model, these multiple types of user interface would look like multiple instances of a generic user oblivious of type of technology.",
                    date: new DateTime(2016, 05, 20, 11, 53, 06),
                    authorUsername: "gery@gmail.com"
                );
                CreatePost(context,
                    title: "View is intentionally oblivious of models",
                    body: @"Likewise, any one user interface can be kept intentionally oblivious of a wide variety of different models that may underlie the mediating controller or adapter. For example, the same website can be kept oblivious of the fact that it can be served by an SQL database server such as PostgreSQL, Sybase SQL Server, or Microsoft SQL Server that has business logic built into the database server via stored procedures and that has transactions that the server may roll back or B) by an SQL database server such as MySQL that lacks one or more of these capabilities, or C) by a nonSQL RDF database, because the website interacts only with the mediating controller or adapter and never directly with the model.",
                    date: new DateTime(2016, 06, 06, 18, 30, 02),
                    authorUsername: "danzo@gmail.com"
                );
                CreatePost(context,
                    title: "Multiple adapters between the same model-view pair",
                    body: @"Additionally, multiple adapters may be created to change the way one view presents data for a given model. For example, different governments (either among different states of the USA or different nation-states internationally) may impose different codes of law, that in turn impose different business logic for the same underlying database and for the same outwardly presented website. In this scenario, a class of various adapters or mediating controllers can represent the variations in business logic among these jurisdictions in between the same database model and the same website view.",
                    date: new DateTime(2016, 06, 04, 19, 13, 44),
                    authorUsername: "danzo@gmail.com"
                );
                CreatePost(context,
                    title: "Model–view–presenter",
                    body: @"Model–view–presenter (MVP) is a derivation of the model–view–controller (MVC) architectural pattern, and is used mostly for building user interfaces.

In MVP the presenter assumes the functionality of the ""middle-man"". In MVP, all presentation logic is pushed to the presenter.",
                    date: new DateTime(2016, 06, 05, 19, 20, 24),
                    authorUsername: "danzo@gmail.com"
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
