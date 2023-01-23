using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Services
{
    public class CallService
    {
        private readonly DoctorWhoCoreDbContext _context;

        public CallService(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }

        public void CallSummariseEpisodesProcedure()
        {
            Console.Write("\nSummarise Episodes: \n");

            var connection = _context.Database.GetDbConnection();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "dbo.spSummariseEpisodes";
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            for (int i = 0; i < reader.FieldCount; i++)
                            {

                                if (reader.GetFieldType(i) == typeof(int))
                                {
                                    var columnValue = reader.GetInt32(i);
                                    Console.Write($"{columnValue}  ");
                                }
                                else if (reader.GetFieldType(i) == typeof(string))
                                {
                                    var columnValue = reader.GetString(i);
                                    Console.Write($"{columnValue}  ");
                                }

                            }
                            Console.WriteLine();

                        }
                        reader.NextResult();
                    }
                }
            }
            connection.Close();

        }

        public void CallCompanionsFunction( int Id)
        {
            Console.Write("\nCompanions : ");
            var companions = _context.Companions.Select(c => _context.CallFnCompanions(Id)).FirstOrDefault();
            Console.WriteLine(companions);

        }

        public void CallEnemiesFunction( int Id)
        {
            Console.Write("\nEnemies : ");

            var enemies = _context.Enemies.Select(e => _context.CallFnEnemies(Id)).FirstOrDefault();
            Console.WriteLine(enemies);
        }

        public void CallEpisodesView()
        {
            Console.WriteLine("\nEpisodes View : ");


            var Query = _context.viewEpisodes.ToList();


            foreach (var item in Query)
            {

                Console.WriteLine($"EpisodeId {item.EpisodeId} :");
                Console.WriteLine(item.AuthorName);
                Console.WriteLine(item.Companions);
                Console.WriteLine(item.DoctorName);
                Console.WriteLine(item.Enemies);
                Console.WriteLine();


            };


        }


    }
}
