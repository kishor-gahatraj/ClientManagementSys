using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientManagementSys.Migrations
{
    public partial class seedvalueforcounter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8276479-8acc-4277-a20f-be5abba58f75", "AQAAAAEAACcQAAAAECb+3rzOJx788Odej4t1zHy/tTu5Zh0Y0HdVBpJ7pRgnRTQMwSz0Z8ydxt+C9wcVHg==", "18cf8c48-cb30-4900-b8f3-d4d35e72ac10" });

            migrationBuilder.InsertData(
                table: "Counter_Tables",
                columns: new[] { "Counter_Id", "Product_Quantity", "Total_Organization", "Total_User" },
                values: new object[] { 1, 0, 0, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Counter_Tables",
                keyColumn: "Counter_Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e4432ba-d856-465d-b0a5-c0db00efee34", "AQAAAAEAACcQAAAAEMHnlN26bPVFQ2LMjeP1vxjp6Xa/f/uYgTxc+2wNLPz9QPbGv6EIQdPWTTnWWcCRIg==", "d4cd9439-6c94-4dc3-9038-e6415e6d414a" });
        }
    }
}
