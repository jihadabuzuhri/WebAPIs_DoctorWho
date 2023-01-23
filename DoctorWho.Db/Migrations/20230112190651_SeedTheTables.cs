using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class SeedTheTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 1, "Sydney Newman" },
                    { 2, "Donald Wilson" },
                    { 3, "Brian Hayles" },
                    { 4, "Robert Holmes" },
                    { 5, "Terrance Dicks" }
                });

            migrationBuilder.InsertData(
                table: "Companions",
                columns: new[] { "CompanionId", "CompanionName", "WhoPlayed" },
                values: new object[,]
                {
                    { 1, "Susan Foreman", "Carole Ann Ford" },
                    { 2, "Vicki", "Maureen O'Brien" },
                    { 3, "Steven Taylor", "Peter Purves" },
                    { 4, "Katarina", "Adrienne Hill" },
                    { 5, "Ace", "Sophie Aldred" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "BirthDate", "DoctorName", "DoctorNumber", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1908, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "William Hartnell", 1, new DateTime(1963, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1966, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1920, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patrick Troughton", 2, new DateTime(1966, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1969, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1919, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jon Pertwee", 3, new DateTime(1970, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1974, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1934, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom Baker", 4, new DateTime(1974, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1981, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1951, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peter Davison", 5, new DateTime(1982, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1984, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "EnemyId", "Description", "EnemyName" },
                values: new object[,]
                {
                    { 1, "A race of mutants from the planet Skaro", "Daleks" },
                    { 2, "A race of cybernetically augmented humanoids", "Cybermen" },
                    { 3, "A warrior race of clones", "Sontarans" },
                    { 4, "An intelligent reptilian species", "Silurians" },
                    { 5, "A species of quantum-locked humanoids", "Weeping Angels" }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodeDate", "EpisodeNumber", "EpisodeType", "Notes", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(1963, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TV", "First episode of Doctor Who", 1, "An Unearthly Child" },
                    { 2, 2, 1, new DateTime(1963, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "TV", "First appearance of the Daleks", 1, "The Daleks" },
                    { 3, 3, 2, new DateTime(1966, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TV", "", 2, "The Power of the Daleks" },
                    { 4, 4, 3, new DateTime(1970, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TV", "", 3, "Spearhead from Space" },
                    { 5, 5, 4, new DateTime(1974, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TV", "", 4, "Robot" }
                });

            migrationBuilder.InsertData(
                table: "EpisodeCompanions",
                columns: new[] { "EpisodeCompanionId", "CompanionId", "EpisodeId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 4, 3, 4 },
                    { 5, 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "EpisodeEnemies",
                columns: new[] { "EpisodeEnemyId", "EnemyId", "EpisodeId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 4, 3, 4 },
                    { 5, 4, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4);
        }
    }
}
