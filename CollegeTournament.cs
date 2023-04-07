using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConn
{
    internal class CollegeTournament
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Enter the choice: \n1. Add Sports\n2. Remove Sports\n3. Add Tournament\n4. Remove Tournament\n5. Add Scoreboard");
            int choice=int.Parse(Console.ReadLine()!);
            if (choice == 1)
                AddSports();
            if (choice == 2)
                DeleteSports();
            if(choice == 3)
                AddTournament();
            if(choice == 4)
                DeleteTournament();
            if (choice == 5)
                AddPlayer();
            if (choice == 6)
                DeletePlayer();
            if (choice == 7)
                AddScoreBoard();
            if (choice == 8)
                ChangeScoreBoard();


        }
        public static void AddSports()
        {
            //we are providing connection to the SQL server where our Database present
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();

            //Inserting the record intot he DB
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
            //we are providing connection to the SQL server where our Database present
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();

            //Inserting the record intot he DB
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
            //Reading the input from the db 
            cmd.CommandText = "SELECT * FROM SPORTS";
            SqlDataReader reader1 = cmd.ExecuteReader();
            Console.WriteLine("SportsId \t SportsName");
            while (reader1.Read())
            {
                Console.Write(reader1.GetInt32(0) + "\t");// We have the integer as the 1st column so we give it as Integer i.e., DeptId
                Console.Write(reader1.GetString(1) + "\t");// We have string in the 2nd column so we give getstring i.e., Dept Name
                Console.WriteLine();
            }
            //Closing the reader
            reader1.Close();
            connect.Close() ;
        }
        public static void AddPlayer()
        {
            //we are providing connection to the SQL server where our Database present
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();

            //Inserting the record intot he DB
            Console.WriteLine("Enter the Player ID ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the TournamentID");
            int TourID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Sport ID ");
            int SportsId = Convert.ToInt32(Console.ReadLine());
            cmd.CommandText = $"INSERT INTO PLAYER Values ({Id},{TourID},{SportsId})";
            //closing this execute reader
            cmd.ExecuteReader().Close();

        }
        public static void AddTournament()
        {
            //we are providing connection to the SQL server where our Database present
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();

            //Inserting the record intot he DB
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
            //we are providing connection to the SQL server where our Database present
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();

            //Inserting the record intot he DB
            Console.WriteLine("Enter the Tournament ID to delete");
            int Id = Convert.ToInt32(Console.ReadLine());
            cmd.CommandText = $"DELETE FROM TOURNAMENT WHERE {Id}= TournamentId";
            DeleteTournamentList(Id);
            cmd.ExecuteReader().Close();

            Retrivetournament();

            connect.Close();
        }
        public static void DeleteTournamentList(int Id)
        {
            //we are providing connection to the SQL server where our Database present
            string CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=CollegeSportsManagement;Integrated Security=True; ";
            SqlConnection connect = new SqlConnection(CONN_STRING);
            //opening the server connection
            connect.Open();
            //creting a Sqlcommand to run the command we give in it
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandText = $"DELETE FROM TOURNAMENTLIST WHERE {Id}= TournamentId";
            cmd.ExecuteReader().Close();
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
                Console.Write(reader1.GetInt32(0) + "\t");
                Console.Write(reader1.GetString(1) + "\t");
                Console.Write(reader1.GetInt32(2) + "\t");
                Console.WriteLine();
            }
            //Closing the reader
            reader1.Close();
            connect.Close();
        }
        public static void AddScoreBoard() {
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
        }
    }
}
