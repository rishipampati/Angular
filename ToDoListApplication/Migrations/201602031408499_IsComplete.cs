namespace ToDoListApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsComplete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoListItems", "IsComplete", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDoListItems", "IsComplete");
        }
    }
}
