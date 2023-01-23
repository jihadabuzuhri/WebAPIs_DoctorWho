using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class CreatefunctionsSprocsViews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION fnCompanions(@EpisodeId INT)
                                    RETURNS VARCHAR(MAX)
                                    AS
                                    BEGIN
                                        DECLARE @CompanionList VARCHAR(MAX)

                                        SELECT @CompanionList = CONCAT(@CompanionList,CompanionName,',')
                                        FROM Companions c
                                        INNER JOIN EpisodeCompanions ec ON c.CompanionId = ec.CompanionId
                                        WHERE ec.EpisodeId = @EpisodeId
                                        RETURN @CompanionList
                                    END");


            migrationBuilder.Sql(@"CREATE FUNCTION fnEnemies(@EpisodeId INT)
                                    RETURNS VARCHAR(MAX)
                                    AS
                                    BEGIN
                                        DECLARE @EnemyList VARCHAR(MAX)

                                        SELECT @EnemyList = CONCAT(@EnemyList,EnemyName,',')
                                        FROM Enemies e
                                            INNER JOIN EpisodeEnemies ee ON e.EnemyId = ee.EnemyId
                                        WHERE ee.EpisodeId = @EpisodeId
                                        RETURN @EnemyList

                                    END");


            migrationBuilder.Sql(@"CREATE PROCEDURE spSummariseEpisodes
                                    AS
                                    BEGIN
                                        -- Find the 3 most frequently-appearing companions
                                        SELECT TOP 3 CompanionName, COUNT(*) AS NumAppearances
                                        FROM Companions c
                                        INNER JOIN EpisodeCompanions ec ON c.CompanionId = ec.CompanionId
                                        GROUP BY CompanionName
                                        ORDER BY NumAppearances DESC

                                        -- Find the 3 most frequently-appearing enemies
                                        SELECT TOP 3 EnemyName, COUNT(*) AS NumAppearances
                                        FROM Enemies e
                                        INNER JOIN EpisodeEnemies ee ON e.EnemyId = ee.EnemyId
                                        GROUP BY EnemyName
                                        ORDER BY NumAppearances DESC
                                    END");


            migrationBuilder.Sql(@"CREATE VIEW viewEpisodes
                                    AS
                                        SELECT e.EpisodeId, a.AuthorName, d.DoctorName,
                                            dbo.fnCompanions(e.EpisodeId) AS Companions,
                                            dbo.fnEnemies(e.EpisodeId) AS Enemies
                                        FROM Episodes e
                                            INNER JOIN Authors a ON e.AuthorId = a.AuthorId
                                            INNER JOIN Doctors d ON e.DoctorId = d.DoctorId");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS fnCompanions;");

            migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS fnEnemies;");

            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS spSummariseEpisodes;");

            migrationBuilder.Sql(@"DROP VIEW IF EXISTS viewEpisodes;");

        }
    }
}
