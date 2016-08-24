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
                    body: @"ASP.NET MVC � ���������, ��������� �� Microsoft, ����� ����� �� ����������� �� ��� ����������, ����������� ������ Model-View-Controller (MVC). ����������� �������� C#, HTML, CSS, JavaScript � ���� �����. ASP.NET MVC � ���������� �������� �� ���������� �� ��� ����������, ����� �� �������� ������ ��� �������. ����������� ������� ���� ��������� � ������������ �� ��� ����������, ��������� ����� ����� ������� ����� HTML � ���� ���������� �� ��������� �� �������� ����������. ASP.NET MVC ���� �� ���� ����� ����� �������� � ���������, ������ � ��������� �� ������� ������, ����� �� ������ ���������� ���� �� �����. ���� ����������� �� �������� �������� ����������, ����� �� ���������, � �� �������� ��������� (���� ��� PHP ��������).",
                    date: new DateTime(2016, 08, 11, 08, 22, 03),
                    authorUsername: "mariika@gmail.com"
                );

                CreatePost(context,
                    title: "MVC ������",
                    body: @"������� ������������ ���� �� ������������, ����� ��������� ������ ��������, ���� �������� ���� ������ ������. ������ �������� ��������� �������, ����� �� �������� ����� ������ ����� � �������������� ���������. ��������, � ���� ������� �� ��������������, ������� �������� �� ���� ���� ������� �� ������ � �������. ������� ���� �� ���� ���� �� �����������, ����� ����������� ������ ����� ������ ����� ������� � �������� ��� �������� � ������. ����� ������� ��������� � ������� ��������� ���������� � ������ �����.",
                    date: new DateTime(2016, 07, 27, 17, 53, 48),
                    authorUsername: "pesho@gmail.com"
                );

                CreatePost(context,
                    title: "����������",
                    body: @"������������ �� �������, ����� �� �������� � MVC ������������. ������� �� � ����� Controllers. ����� ���� ���� ,����� � �� ���� ���, ������ �� ��� ��� ���������� � �������� ""Controller"". ������������ ���������� ������������ ������, �������� �� ����������� � ���������� ����������� ������ �� ���������� �� ������������. ������ ��������� � ��������� �� �������� ����� �� ���������:

    �������� � ��������� �� ���-���������� ����� �� �������� (action method) � ����������, �� ���� �� ���� �������.
    ��������� �� ���������, ����� �� �� ��������� ���� ��������� � ������ �� ��������.
    ������������ �� ������ ������, ����� ����� �� ��������� �� ����� �� ������������ ������ �� ��������.
    ����������� �� ���� WebFormViewEngine �� ������������ �� �������� �� �������� � ������ �� ��� ASP.NET.

�� �� �������� ��������� ��������� ������� ����� �� ������� ����� ������� ""controllers"" � ��������� ""solution explorer"" �� Visual Studio, �������� ""add"" � ���� ���� ""controller"".",
                    date: new DateTime(2016, 02, 18, 22, 14, 38),
                    authorUsername: "admin@gmail.com"
                );

                CreatePost(context,
                    title: "������ ��������� �� �������",
                    body: @"Action Results

    View():- ������������ ASP.NET MVC ������ �.�., ������ ����� ������� ����� HTML. ���� � ���-�������������� ""ActionResult"" ,����� ���� �� ����� ���� ���������.

    PartialView():- ������� ���� �� ASP.NET MVC �������.

    RedirectToAction():- ���������� �� ���� ��������� �������� � �����. ��������� � ����� ���� �� �� ������� ���� �������� ��:

-actionName: ����� �� ����������.
-controllerName: ����� �� ����������.
-routeValues: ����������� ����� �� ��������� �� ����������.

������ RedirectToAction() ����� ""302 found HTTP"" ������ ��� �� ��������, �� �� ���� �� ������� �������������� ��� ������ ��������. ���� �� ������������ �� ���� �������� �, �� ������ �� ����� ������������ � �������� � ������ �� ������ �� �������� � ����� URL ����. ���������� �, �� ������ �� �� ������� �������� ������ �� �������� ��� �������.

    Redirect():- ���������� ��� ���� ��������� ��� URL ����.
    Content():- ����� ����� ��������� ��� ��������. �����������, ����� ����� �� �� ��������� ���� ���������, ��:

-string: ���������� string �� ��������.
-contentype: ����� MIME �� ������� (�� ������������ �� text/html).
-contentEncoding: ���������� �������� �� ������� (��������:-Unicode ��� ASCII)

    Json():- JavaScript object Notation (JSON) e ��������� �� Douglas Crockford ���� ��-���� ����������� �� XML �� ������� �� ����� �� �������� � Ajax ����������. ������ Json() �������� ���� � .NET framework ������� JavaScriptSerializer �� �� ����������� ����� � JSON �������������.

    File():- ������� �� ���� �� ��������. ���� ����� ������ �������� ���������:

-filename, contentType, fileDownloadName, fileContents, fileStream.

    JavaScript():- ������������ JavaScript ����.

    HandleUnknownAction():- ���� ����� �� ������� ����������� ������ ���������� �� ���� �� ������ ������. �� ������������ ������ ������� ������ ""404 resource Not Found"". ����������� �� ������ ���� �� ���� ������� � �����, ���� ����� ������� �� �� ��������� ��������� �����.
",
                    date: new DateTime(2016, 01, 11, 19, 02, 05),
                    authorUsername: "admin@gmail.com"
                );

                CreatePost(context,
                    title: "������ �� ��������",
                    body: @"� ASP.NET ����������, ����� �� ������� MVC Framework, ���������������� � ����������� �� ������������ � ������������ ���� ��������. �� ������� �� ���� � ���������� � MVC framework ���������������� � ����������� �� ������������ ���� ���������� � ������ �� ��������. ����������� �������� ������ �� �������� � ���� �� ������� ������� ������ �� ��������,������� �� ����������.

������ �� �������� ���������� ���� �������, ����� �� ����� �������� � ���������������� � �����������. ������� �� �������������� � ������������� �� ��������� �� URL ����� � ��������, �������� ����� ����, � ���������� �� ��������. ����� ���� �� ���� ������������� �������������� ������� ������ ��� �������. ��� ����� ���� �� ���� ������, URL ������ �� �������� ������� ����������, ����� MVC Framework �������� �� �� ������ ����� �� ��������.",
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
