using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MondayFunday.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Movies" },
                    { 2, "Movies" },
                    { 3, "Jewelery" },
                    { 4, "Beauty" },
                    { 5, "Jewelery" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 4, "Ergonomic Steel Cheese", 513.07m },
                    { 2, 3, "Refined Wooden Fish", 263.66m },
                    { 3, 1, "Intelligent Cotton Bike", 25.69m },
                    { 4, 2, "Handmade Concrete Salad", 860.93m },
                    { 5, 3, "Ergonomic Granite Pants", 708.26m },
                    { 6, 2, "Generic Soft Fish", 398.87m },
                    { 7, 2, "Handcrafted Concrete Hat", 487.48m },
                    { 8, 3, "Licensed Steel Shoes", 450.27m },
                    { 9, 4, "Handmade Cotton Ball", 286.34m },
                    { 10, 5, "Incredible Cotton Pizza", 179.61m },
                    { 11, 1, "Generic Rubber Table", 498.72m },
                    { 12, 1, "Awesome Metal Car", 930.08m },
                    { 13, 5, "Ergonomic Cotton Pants", 19.87m },
                    { 14, 2, "Small Fresh Fish", 768.40m },
                    { 15, 4, "Handmade Metal Table", 377.39m },
                    { 16, 2, "Handcrafted Concrete Car", 76.83m },
                    { 17, 4, "Gorgeous Fresh Towels", 545.79m },
                    { 18, 4, "Ergonomic Soft Chair", 457.56m },
                    { 19, 2, "Ergonomic Frozen Towels", 274.39m },
                    { 20, 4, "Gorgeous Wooden Ball", 465.60m }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "ProductId", "Rating" },
                values: new object[,]
                {
                    { 1, "this product is brown.", 2, 4 },
                    { 2, "My co-worker Bryton has one of these. He says it looks ragged.", 11, 5 },
                    { 3, "My neighbor Isabela has one of these. She works as a taxidermist and she says it looks monochromatic.", 4, 2 },
                    { 4, "i use it until further notice when i'm in my station.", 11, 2 },
                    { 5, "this product is dominant.", 5, 1 },
                    { 6, "i use it until further notice when i'm in my nightclub.", 15, 5 },
                    { 7, "The box this comes in is 3 kilometer by 5 inch and weights 13 ton.", 18, 1 },
                    { 8, "The box this comes in is 3 kilometer by 5 inch and weights 13 ton.", 11, 4 },
                    { 9, "It only works when I'm Singapore.", 12, 4 },
                    { 10, "This product works certainly well. It accidentally improves my baseball by a lot.", 15, 2 },
                    { 11, "i use it usually when i'm in my alley.", 14, 3 },
                    { 12, "My peacock loves to play with it.", 10, 4 },
                    { 13, "I saw one of these in Spratly Islands and I bought one.", 1, 3 },
                    { 14, "My neighbor Montserrat has one of these. She works as a circus performer and she says it looks shriveled.", 10, 3 },
                    { 15, "My porcupine loves to play with it.", 6, 4 },
                    { 16, "The box this comes in is 5 light-year by 6 foot and weights 17 megaton!!!", 6, 5 },
                    { 17, "heard about this on ndombolo radio, decided to give it a try.", 4, 4 },
                    { 18, "This product works too well. It buoyantly improves my football by a lot.", 13, 3 },
                    { 19, "I saw one of these in Tanzania and I bought one.", 1, 4 },
                    { 20, "talk about remorse!!!", 2, 1 },
                    { 21, "This product works so well. It hungrily improves my basketball by a lot.", 2, 2 },
                    { 22, "My co-worker Rey has one of these. He says it looks uneven.", 1, 1 },
                    { 23, "My neighbor Lonnie has one of these. She works as a hobbit and she says it looks microscopic.", 18, 4 },
                    { 24, "My neighbor Frona has one of these. She works as a gambler and she says it looks bearded.", 8, 4 },
                    { 25, "The box this comes in is 3 yard by 6 yard and weights 19 pound!!!", 9, 4 },
                    { 26, "My terrier loves to play with it.", 14, 1 },
                    { 27, "My ant loves to play with it.", 2, 2 },
                    { 28, "one of my hobbies is gaming. and when i'm gaming this works great.", 18, 3 },
                    { 29, "this product is brown.", 13, 4 },
                    { 30, "This product works certainly well. It energetically improves my golf by a lot.", 1, 4 },
                    { 31, "talk about contempt!", 2, 3 },
                    { 32, "This product works excessively well. It speedily improves my baseball by a lot.", 6, 2 },
                    { 33, "My chicken loves to play with it.", 3, 3 },
                    { 34, "This product works very well. It persistently improves my soccer by a lot.", 13, 4 },
                    { 35, "My co-worker Cato has one of these. He says it looks sopping.", 2, 1 },
                    { 36, "i use it barely when i'm in my store.", 19, 1 },
                    { 37, "The box this comes in is 3 meter by 5 foot and weights 11 kilogram.", 17, 2 },
                    { 38, "I saw this on TV and wanted to give it a try.", 13, 4 },
                    { 39, "i use it once in a while when i'm in my ring.", 19, 5 },
                    { 40, "This product works extremely well. It wetly improves my tennis by a lot.", 16, 4 },
                    { 41, "heard about this on new jersey hip hop radio, decided to give it a try.", 6, 2 },
                    { 42, "My goldfinch loves to play with it.", 2, 5 },
                    { 43, "i use it every Tuesday when i'm in my store.", 4, 5 },
                    { 44, "I saw one of these in Algeria and I bought one.", 8, 1 },
                    { 45, "This product works very well. It romantically improves my football by a lot.", 13, 5 },
                    { 46, "My co-worker Kazuo has one of these. He says it looks transparent.", 13, 4 },
                    { 47, "It only works when I'm South Korea.", 9, 5 },
                    { 48, "i use it every Tuesday when i'm in my pub.", 15, 1 },
                    { 49, "This product works so well. It imperfectly improves my baseball by a lot.", 9, 5 },
                    { 50, "The box this comes in is 4 meter by 5 foot and weights 18 kilogram.", 19, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
