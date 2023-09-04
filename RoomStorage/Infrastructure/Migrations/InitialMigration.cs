using FluentMigrator;

namespace Infrastructure.Migrations;

[Migration(1)]
public class InitialMigration : Migration
{
    public override void Up()
    {
        Create.Table("users")
            .WithColumn("id").AsGuid().PrimaryKey()
            .WithColumn("name").AsString()
            .WithColumn("email").AsString()
            .WithColumn("secretkey").AsString()
            .WithColumn("refreshtoken").AsString().Nullable()
            .WithColumn("role").AsString();

    }

    public override void Down()
    {
        Delete.Table("users");
    }
}