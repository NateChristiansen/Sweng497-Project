using System.Data.Entity.Migrations;

namespace ErieGarbageOnline.Migrations
{
    public partial class Update2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Date", c => c.DateTime(false));
        }
    }
}
