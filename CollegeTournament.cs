using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SQLConn
{
    internal class CollegeTournament
    {
        public static void Main(string[] args)
        {
            int con= 0;
            Console.WriteLine("Enter the choice: \n1. Add Sports\n2. Remove Sports\n3. Add Tournament\n4. Remove Tournament\n5. Add Player \n6. Remove Player \n7. Add Scoreboard\n8. Change Scoreboard\t9. Team registration\t10. Payment");
            
            do {
                int choice = int.Parse(Console.ReadLine()!);
                if (choice == 1)
                    AddSports();
                if (choice == 2)
                    DeleteSports();
                if (choice == 3)
                    AddTournament();
                if (choice == 4)
                    DeleteTournament();
                if (choice == 5)
                    AddPlayer();
                if (choice == 6)
                    DeletePlayer();
                if (choice == 7)
                    AddScoreBoard();
                if (choice == 8)
                    ChangeScoreBoard();
                if (choice == 9)
                    TeamRegistration();
                if (choice == 10)
                    Payment();
                Console.WriteLine("Enter 1 to Continue");
                con=Convert.ToInt32(Console.ReadLine());
            }while(con==1);
        }
        public static void AddSports()
        {
            RetriveSports();
            //we are providing connection to the SQL server where our Database present
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();

            //Inserting the record into the Sports DB
            Console.WriteLine("Enter the Sports ID ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Sport Name");
            string Name = Console.ReadLine()!;
            cmd.CommandText = $"INSERT INTO SPORTS Values ({Id},'{Name}')";
            //closing this execute reader
            cmd.ExecuteReader().Close();

            RetriveSports();

            connect.Close();
        }
        public static void DeleteSports()
        {
            RetriveSports();
            //we are providing connection to the SQL server where our Database present
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();

            //Deleting the record from SPorts DB
            Console.WriteLine("Enter the Sports ID ");
            int Id = Convert.ToInt32(Console.ReadLine());
            cmd.CommandText = $"DELETE FROM SPORTS WHERE {Id}= SportsId";
            //closing this execute reader
            cmd.ExecuteReader().Close();

            RetriveSports();

            connect.Close();
        }
        public static void RetriveSports()
        {
            //we are providing connection to the SQL server where our Database present
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();
            //Reading the input from the Sports db 
            cmd.CommandText = "SELECT * FROM SPORTS ORDER BY SportsId";
            SqlDataReader reader1 = cmd.ExecuteReader();
            Console.WriteLine("SportsId \t SportsName");
            while (reader1.Read())
            {
                Console.Write(reader1.GetInt32(0) + "\t");// We have the integer as the 1st column so we give it as Integer 
                Console.Write(reader1.GetString(1) + "\t");// We have string in the 2nd column so we give getstring 
                Console.WriteLine();
            }
            //Closing the reader
            reader1.Close();
            connect.Close() ;
        }
        public static void AddPlayer()
        {
            RetrivePlayer();
            //we are providing connection to the SQL server where our Database present
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();

            //Inserting the Player record into the DB
            Console.WriteLine("Enter the Player ID ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the TournamentID");
            int TourID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Sport ID ");
            int SportsId = Convert.ToInt32(Console.ReadLine());
            cmd.CommandText = $"INSERT INTO PLAYER Values ({Id},{TourID},{SportsId})";
            //closing this execute reader
            cmd.ExecuteReader().Close();

            RetrivePlayer();

            connect.Close();

        }
        public static void DeletePlayer()
        {
            RetrivePlayer();
            //we are providing connection to the SQL server where our Database present
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();

            //Deleting the player record from the PLayer DB
            Console.WriteLine("Enter the Player ID ");
            int Id = Convert.ToInt32(Console.ReadLine());
            cmd.CommandText = $"DELETE FROM PLAYER WHERE {Id}= PlayerId";
            //closing this execute reader
            cmd.ExecuteReader().Close();

            RetrivePlayer();

            connect.Close();
        }
        public static void RetrivePlayer()
        {
            //we are providing connection to the SQL server where our Database present
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();
            //Reading the input from the Player db 
            cmd.CommandText = "SELECT * FROM Player";
            SqlDataReader reader1 = cmd.ExecuteReader();
            Console.WriteLine("PlayerId \t TournamentId \t SportsID");
            while (reader1.Read())
            {
                Console.Write(reader1.GetInt32(0) + "\t");// We have the integer as the 1st column so we give it as Integer 
                Console.Write(reader1.GetInt32(1) + "\t");// We have the integer as the 1st column so we give it as Integer 
                Console.Write(reader1.GetInt32(2) + "\t");// We have the integer as the 1st column so we give it as Integer 
                Console.WriteLine();
            }
            //Closing the reader
            reader1.Close();
            connect.Close();
        }
        public static void AddTournament()
        {
            Retrivetournament();
            //we are providing connection to the SQL server where our Database present
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();

            //Inserting the Tournament details onto the DB
            Console.WriteLine("Enter the Tournament ID ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Tournament Name");
            string Name = Console.ReadLine()!;
            Console.WriteLine("Enter the Sports ID ");
            int SportId = Convert.ToInt32(Console.ReadLine());
            cmd.CommandText = $"INSERT INTO TOURNAMENT Values ({Id},'{Name}',{SportId})";
            //closing this execute reader
            cmd.ExecuteReader().Close();

            cmd.CommandText = $"INSERT INTO TOURNAMENTLIST Values ({Id},'{Name}')";
            //closing this execute reader
            cmd.ExecuteReader().Close();

            Retrivetournament();

            connect.Close();
        }
        public static void DeleteTournament()
        {
            Retrivetournament();
            //we are providing connection to the SQL server where our Database present
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();

            //Deleting the touranment details on 2 DB Touranment and TouranemntList based on the Tournament ID
            Console.WriteLine("Enter the Tournament ID to delete");
            int Id = Convert.ToInt32(Console.ReadLine());
            cmd.CommandText = $"DELETE FROM TOURNAMENT WHERE TournamentId={Id}";
            cmd.ExecuteReader().Close();
            cmd.CommandText = $"DELETE FROM TOURNAMENTLIST WHERE TournamentId={Id}";
            cmd.ExecuteReader().Close();

            Retrivetournament();

            connect.Close();
        }
        public static void Retrivetournament()
        {
            //we are providing connection to the SQL server where our Database present
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();
            //Reading the input from the db 
            cmd.CommandText = "SELECT * FROM TOURNAMENT";
            SqlDataReader reader1 = cmd.ExecuteReader();
            Console.WriteLine("TournamentId \t TournamentName\t SportId");

            while (reader1.Read())
            {
                Console.Write(reader1.GetInt32(0) + "\t");// We have the integer as the 1st column so we give it as Integer 
                Console.Write(reader1.GetString(1) + "\t");// We have the string as the 2nd column so we give it as string
                Console.Write(reader1.GetInt32(2) + "\t");// We have the integer as the 3rd column so we give it as Integer 
                Console.WriteLine();
            }
            //Closing the reader
            reader1.Close();
            connect.Close();
        }
        public static void AddScoreBoard() {
            retriveScoreBoard();
            //we are providing connection to the SQL server where our Database present
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();

            //Inserting the record into the DB
            Console.WriteLine("Enter the Tournament ID ");
            int TournamentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Sports ID ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Player1 ID");
            int playerId1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Player1 Score");
            int player1Score = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Player2 ID");
            int playerId2= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Player2 score");
            int player2Score = Convert.ToInt32(Console.ReadLine());
            cmd.CommandText = $"INSERT INTO TOURNAMENT Values ({TournamentId},{Id},{playerId1},{player1Score},{playerId2},{player2Score})";
            //closing this execute reader
            cmd.ExecuteReader().Close();

        }
        public static void ChangeScoreBoard() {
            retriveScoreBoard();
            //we are providing connection to the SQL server where our Database present
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();
            Console.WriteLine("Enter the Tournament Id:");
            int tournamentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Sports Id: ");
            int sportsId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Player 1 Score ");
            int Player1Score= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Player 1 Score ");
            int Player2Score = Convert.ToInt32(Console.ReadLine());
            cmd.CommandText = $"UPDATE SCOREBOARD SET Player1Score={Player1Score}, Player2Score={Player2Score} WHERE TournamentId={tournamentId} AND SportsId={sportsId}";
            cmd.ExecuteReader().Close();
        }
        public static void retriveScoreBoard()
        {
            //we are providing connection to the SQL server where our Database present
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandText = "SELECT * FROM SCOREBOARD";
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("TournamentId\tSportsID\tPlayer1Id\tPlayer1Score\tPlayer2Id\tPLayer2Score");
            while(reader.Read())
            {
                Console.WriteLine(reader.GetInt32(0));
                Console.WriteLine(reader.GetInt32(1));
                Console.WriteLine(reader.GetInt32(2));
                Console.WriteLine(reader.GetInt32(3));
                Console.WriteLine(reader.GetInt32(4));
                Console.WriteLine(reader.GetInt32(5));
            }
            reader.Close();
            connect.Close();
        }
        public static void TeamRegistration()
        {
            //we are providing connection to the SQL server where our Database present
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();
            Console.WriteLine("Enter the team id:");
            int teamId= int.Parse(Console.ReadLine()!);
            Console.WriteLine("Enter the tournamentId");
            int tournamentId = int.Parse(Console.ReadLine()!);
            cmd.CommandText = $"INSERT team VALUES ({teamId},{tournamentId})";
            cmd.ExecuteReader().Close();
        }
        public static void Payment()
        {
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();

            //Inserting the record intot he DB
            Console.WriteLine("Enter the Payment ID ");
            string paymentId = Console.ReadLine()!;
            Console.WriteLine("Enter the Player ID");
            int playerId = Convert.ToInt32(Console.ReadLine());
            cmd.CommandText = $"INSERT INTO PaymentDetails Values ('{paymentId}',{playerId})";
            //closing this execute reader
            cmd.ExecuteReader().Close();
            connect.Close() ;
        }
    }
}
