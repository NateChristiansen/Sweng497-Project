using System.Data.Entity.Migrations;

namespace ErieGarbageOnline.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(false, true),
                        Email = c.String(),
                        Password = c.String(),
                        Firstname = c.String(),
                        Lastname = c.String()
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillId = c.Int(false, true)
                    })
                .PrimaryKey(t => t.BillId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(false, true),
                        Email = c.String(),
                        Password = c.String(),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        State = c.String(),
                        PostalCode = c.String()
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(false, true)
                    })
                .PrimaryKey(t => t.MessageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
            DropTable("dbo.Customers");
            DropTable("dbo.Bills");
            DropTable("dbo.Admins");
        }
    }
}
