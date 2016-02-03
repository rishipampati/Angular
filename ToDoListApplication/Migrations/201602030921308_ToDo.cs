namespace ToDoListApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ToDo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoListItems", "ToDo", c => c.String());
            DropColumn("dbo.ToDoListItems", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ToDoListItems", "Text", c => c.String());
            DropColumn("dbo.ToDoListItems", "ToDo");
        }
    }
}
