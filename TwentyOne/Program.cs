using System;
using Casino;
using Casino.TwentyOne;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace TwentyOne
{
    class Program
    {
        static void Main()
        {
            const string casinoName = "Grand Hotel and Casino";

            Console.WriteLine("Welcome to the {0}.\nLet's start by you telling me your name.", casinoName);
            string playerName = Console.ReadLine();

            //admin controls
            if (playerName.ToLower() == "admin")
            {

                List<ExceptionEntity> Exceptions = ReadExceptions();
                foreach (var exception in Exceptions)
                {
                    Console.Write(exception.Id + " | ");
                    Console.Write(exception.ExceptionType + " | ");
                    Console.Write(exception.ExceptionMessage + " | ");
                    Console.Write(exception.TimeStamp + " | \n");

                }
                Console.Read();
                return;
            }

            bool validAnswer = false;
            int bank = 0;
            while (!validAnswer)
            {
                Console.WriteLine("How much money did you bring with you today?");
                validAnswer = int.TryParse(Console.ReadLine(), out bank);
                if (!validAnswer)
                {
                    Console.WriteLine("Please enter digits only (no decimals).");
                }
            }


            Console.WriteLine("Alrighty there {0}. Would you like to play a game of 21?", playerName);
            string answer = Console.ReadLine().ToLower();

            if (answer == "yes" || answer == "y" || answer == "yeah" || answer == "ya")
            {
                Player player = new Player(playerName, bank);
                player.Id = Guid.NewGuid();

                Game game = new TwentyOneGame();
                game += player;

                using (StreamWriter file = new StreamWriter(@"C:\Users\rober\CS\advanced\TwentyOne\Logs\log.txt", append: true))
                {
                    file.WriteLine(player.Id);
                }

                player.isActivelyPlaying = true;
                while (player.isActivelyPlaying && player.Balance > 0)
                {
                    try
                    {
                        game.Play();
                    }
                    //specific catch
                    catch (FraudException ex)
                    {
                        Console.WriteLine(ex.Message);
                        UpdateDbWithException(ex);
                        Console.ReadLine();
                        return;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Something you entered was incorrect.");
                        UpdateDbWithException(ex);
                        Console.ReadLine();
                        return;
                    }
                    //general one
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occured.  Please contact your System Administrator.");
                        UpdateDbWithException(ex);
                        Console.ReadLine();
                        return;
                    }
                }
                game -= player;
                Console.WriteLine("Thank you for playing!");
            }

            Console.WriteLine("Feel free to look around the casino. Bye for now!");
            Console.ReadLine();
        }


        /* -----------------------------------
         * WRITING EXCEPTION LOGS TO DATABASE
         * --------------------------------- */

        private static void UpdateDbWithException(Exception ex)
        //able to evaluate FraudException due to polymorphism
        {
            //connection string
            string connectionString = 
                @"
                    Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = TwentyOneGame; 
                    Integrated Security = True; Connect Timeout = 30; Encrypt = False; 
                    TrustServerCertificate = False; ApplicationIntent = ReadWrite; 
                    MultiSubnetFailover = False
                ";

            //second part of a command, the querey
            string queryString = 
                                
                @"
                    INSERT INTO Exceptions (ExceptionType, ExceptionMessage, TimeStamp) 
                    VALUES
                    (
                        @ExceptionType, @ExceptionMessage, @TimeStamp        
                    )
                ";
            //use using to open and close external interface before/after use
            using (var connection = new SqlConnection(connectionString))
            {
                //load the Program -> Db command
                var command = new SqlCommand(queryString, connection);


                command.Parameters.Add("@ExceptionType", SqlDbType.VarChar);
                command.Parameters.Add("@ExceptionMessage", SqlDbType.VarChar);
                command.Parameters.Add("@TimeStamp", SqlDbType.DateTime);

                command.Parameters["@ExceptionType"].Value = ex.GetType().ToString();
                command.Parameters["@ExceptionMessage"].Value = ex.Message;
                command.Parameters["@TimeStamp"].Value = DateTime.Now;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        /* -----------------------------------
        * READING FROM DB TO CONSOLE (admin)
        * --------------------------------- */

        private static List<ExceptionEntity> ReadExceptions()
        {
            //establish connection credentials
            string connectionString =
                @"
                    Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = TwentyOneGame; 
                    Integrated Security = True; Connect Timeout = 30; Encrypt = False; 
                    TrustServerCertificate = False; ApplicationIntent = ReadWrite; 
                    MultiSubnetFailover = False
                ";
            //select * from exception inside connection
            string queryString =
                @"
                    SELECT Id, ExceptionType, ExceptionMessage, TimeStamp FROM Exceptions
                ";
            //init empty list of object type (to be filled w/ "rows"/"objects"
            var Exceptions = new List<ExceptionEntity>();

            using (var connection = new SqlConnection(connectionString))
            {
                //build the command and open the connection 
                var command = new SqlCommand(queryString, connection);
                connection.Open();

                //init data reader obj, to loop through each record
                SqlDataReader reader = command.ExecuteReader();
                
                //enters loop to exctract, record by record (access columns w/ reader[columnX]
                while (reader.Read())
                {
                    var exception = new ExceptionEntity();
                    exception.Id = Convert.ToInt32(reader["Id"]);
                    exception.ExceptionType = reader["ExceptionType"].ToString();
                    exception.ExceptionMessage = reader["ExceptionMessage"].ToString();
                    exception.TimeStamp = Convert.ToDateTime(reader["TimeStamp"]);
                    Exceptions.Add(exception);
                }
                connection.Close();
            }
            return Exceptions;
        }
    }
}
