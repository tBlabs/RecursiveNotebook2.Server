namespace NotesApi.Data.Migrations
{
    using WebHydra.Framework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Newtonsoft.Json;

    internal sealed class Configuration : DbMigrationsConfiguration<NotesApi.Data.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NotesApi.Data.MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            Claims claims = new Claims()
            {
                CanAddNote = false,
                CanChangeNote = false,
                CanDeleteNote = false,
                CanReadNote = true
            };
            string claimsAsJson = JsonConvert.SerializeObject(claims);
            UserEntity user = new UserEntity() { Email = "demo", Password = "demo", Claims = claimsAsJson };
            context.Users.AddOrUpdate(user);
            context.SaveChanges(); // This is required to attach user.Id

            Note firstNote = new Note()
            {
                ParentId = Guid.Empty,
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Title = "Hello!",
                Content = "This is Recursive Notebook. Welcome."
            };
            context.Notes.AddOrUpdate(firstNote);
            context.SaveChanges();
        }
    }
}
