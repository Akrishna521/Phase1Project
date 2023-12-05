using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    //CricketTeam.cs
    public class CricketTeam
    {
        private List<Player> players = new List<Player>();

        public void AddPlayer(int playerId, string playerName, int playerAge)
        {
            if (players.Count < 11)
            {
                Player player = new Player(playerId, playerName, playerAge);
                players.Add(player);
                Console.WriteLine($"Player {playerName} added to the team.");
            }
            else
            {
                Console.WriteLine("Cannot add more than 11 players to the team.");
            }
        }

        public void RemovePlayer(int playerId)
        {
            Player playerToRemove = players.Find(player => player.PlayerId == playerId);

            if (playerToRemove != null)
            {
                players.Remove(playerToRemove);
                Console.WriteLine($"Player with ID {playerId} ({playerToRemove.PlayerName}) removed from the team.");
            }
            else
            {
                Console.WriteLine($"Player with ID {playerId} not found in the team.");
            }
        }

        public Player GetPlayerDetailsById(int playerId)
        {
            return players.Find(player => player.PlayerId == playerId);
        }

        public Player GetPlayerDetailsByName(string playerName)
        {
            return players.Find(player => player.PlayerName.Equals(playerName, StringComparison.OrdinalIgnoreCase));
        }

        public List<Player> GetAllPlayerDetails()
        {
            return players;
        }
    }
    //Player.cs
    public class Player
    {
        public int PlayerId { get; }
        public string PlayerName { get; }
        public int PlayerAge { get; }

        public Player(int playerId, string playerName, int playerAge)
        {
            PlayerId = playerId;
            PlayerName = playerName;
            PlayerAge = playerAge;
        }
        public override string ToString()
        {
            return $"ID: {PlayerId}, Name: {PlayerName}, Age: {PlayerAge}";
        }
    }

    //Program.cs
    public class Program
    {
        static void Main(string[] args)
        {
            CricketTeam team = new CricketTeam();

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add Player");
                Console.WriteLine("2. Remove Player");
                Console.WriteLine("3. Get Player Details by ID");
                Console.WriteLine("4. Get Player Details by Name");
                Console.WriteLine("5. Get All Player Details");
                Console.WriteLine("6. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Player ID:");
                        int playerId = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Player Name:");
                        string playerName = Console.ReadLine();

                        Console.WriteLine("Enter Player Age:");
                        int playerAge = int.Parse(Console.ReadLine());

                        team.AddPlayer(playerId, playerName, playerAge);
                        break;

                    case 2:
                        Console.WriteLine("Enter Player ID to remove:");
                        int playerToRemove = int.Parse(Console.ReadLine());
                        team.RemovePlayer(playerToRemove);
                        break;

                    case 3:
                        Console.WriteLine("Enter Player ID to get details:");
                        int playerIdToGet = int.Parse(Console.ReadLine());
                        Console.WriteLine(team.GetPlayerDetailsById(playerIdToGet));
                        break;

                    case 4:
                        Console.WriteLine("Enter Player Name to get details:");
                        string playerNameToGet = Console.ReadLine();
                        Console.WriteLine(team.GetPlayerDetailsByName(playerNameToGet));
                        break;

                    case 5:
                        foreach (var player in team.GetAllPlayerDetails())
                        {
                            Console.WriteLine(player);
                        }
                        break;

                    case 6:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}