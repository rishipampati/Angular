using ToDoListApplication.Models;

namespace ToDoListApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ToDoListApplication.Models.ToDoListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ToDoListApplication.Models.ToDoListContext context)
        {
            context.ToDoListItems.AddOrUpdate(x => x.Id,
                new ToDoListItems() { Id = 1, Text = "Wake up at 6:00 AM" },
                new ToDoListItems() { Id = 2, Text = "Get Ready by 8:00 AM" },
                new ToDoListItems() { Id = 3, Text = "Be at Axio by 10:30" }
                );
        }
    }
}
