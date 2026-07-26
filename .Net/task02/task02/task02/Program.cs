using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TODO: Create your complete football application

            Console.WriteLine(" FOOTBALL MANAGEMENT SYSTEM");
            Console.WriteLine("================================\n");
            #region TODO1:
            // 1. Create a team
            // 2. Add players of different positions

            // ============================================
            // 1. OOP - Creating Players (Encapsulation)
            // ============================================
            Console.WriteLine("--- 1. CREATING PLAYERS (OOP) ---\n");

            var salah = new Forward("Mohamed Salah", 10, 31, 32);
            var trezeguet = new Forward("Trezeguet", 7, 29, 15);
            var hegazi = new Defender("Ahmed Hegazi", 6, 32, 45, 30);
            var marmoush = new Forward("Omar Marmoush", 14, 24, 12);
            var elShenawy = new Goalkeeper("Mohamed El-Shenawy", 1, 34, 12);

            // ============================================
            // 2. OOP - Inheritance & Polymorphism
            // ============================================
            Console.WriteLine("--- 2. POLYMORPHISM ---\n");

            List<FootballPlayer> players = new List<FootballPlayer> { salah, trezeguet, hegazi, marmoush, elShenawy };

            foreach (var player in players)
            {
                player.Play();  // Different behavior for each!
                player.Train(); // Different behavior for each!
                Console.WriteLine();
            }

            // ============================================
            // 3. TEAM CREATION
            // ============================================
            Console.WriteLine("--- 3. CREATING TEAM ---\n");

            var team = new Team("Al Ahly SC", "Marcel Koller");
            team.AddPlayer(salah);
            team.AddPlayer(trezeguet);
            team.AddPlayer(hegazi);
            team.AddPlayer(marmoush);
            team.AddPlayer(elShenawy);

            team.DisplaySquad();
            #endregion

            #region TODO2:

            // 3. Use indexers to access players
            // ============================================
            //  INDEXERS - Accessing Players
            // ============================================
            Console.WriteLine("--- 4. INDEXERS ---\n");

            // By position
            Console.WriteLine($"Player at index 0: {team[0]?.Name}");

            // By jersey number
            var playerByNumber = team[10, true];
            Console.WriteLine($"Player with jersey #10: {playerByNumber?.Name}");

            // By name
            var playerByName = team["Salah"];
            Console.WriteLine($"Player named 'Salah': {playerByName?.Name}");

            // By position and stat
            int forwardGoals = team["Forward", "Goals"];
            Console.WriteLine($"Total goals by forwards: {forwardGoals}");

            // 4. Use generics for specialized collections
            // ============================================
            //  GENERICS - Squad and Stats
            // ============================================
            Console.WriteLine("\n--- 5. GENERICS ---\n");

            var forwardSquad = new Squad<Forward>();
            forwardSquad.AddPlayer(salah);
            forwardSquad.AddPlayer(trezeguet);
            forwardSquad.AddPlayer(marmoush);
            forwardSquad.DisplayAll();

            var forwardStats = new StatsCalculator<Forward>();
            var allForwards = forwardSquad.GetAll();
            Console.WriteLine($"Forward average goals: {forwardStats.CalculateAverageGoals(allForwards)}");
            #endregion
            #region TODO3:
            // 5. Use delegates for filtering and reporting
            // ============================================
            // 6. DELEGATES - Filtering
            // ============================================
            Console.WriteLine("\n--- 6. DELEGATES ---\n");

            var reportGenerator = new TeamReportGenerator();

            // Named method
            reportGenerator.GenerateReport(team.ToList(), "Star Players", player => player.Goals > 20);

            // Anonymous method
            reportGenerator.GenerateReport(team.ToList(), "Veteran Players",
                delegate (FootballPlayer p) { return p.Age >= 30; });

            // Lambda expression
            reportGenerator.GenerateReport(team.ToList(), "Injured Players",
                p => p.IsInjured);

            // ============================================
            // 7. GENERIC DELEGATES - Func, Action, Predicate
            // ============================================
            Console.WriteLine("\n--- 7. GENERIC DELEGATES ---\n");

            var analyzer = new TeamAnalyzer();

            // Func - Calculate total goals
            int totalGoals = analyzer.CalculateTeamStat(team.ToList(), p => p.Goals);
            Console.WriteLine($"Total team goals: {totalGoals}");

            // Action - Apply operation to all
            Console.WriteLine("\nApplying training to all players:");
            analyzer.ApplyToAllPlayers(team.ToList(), p => p.Train());

            // Predicate - Find players
            var youngPlayers = analyzer.FindPlayers(team.ToList(), p => p.Age < 25);
            Console.WriteLine($"\nYoung players (<25): {youngPlayers.Count}");

            // 6. Use extension methods for enhanced functionality

            // ============================================
            // 8. EXTENSION METHODS
            // ============================================
            //  Console.WriteLine("\n--- 8. EXTENSION METHODS ---\n");

            // Player extensions
            foreach (var player in team)
            {
                Console.WriteLine($"{player.Name}: {player.GetRating()}");
                if (player.IsStar())
                {
                    player.PrintStats();
                    Console.WriteLine($"Value: ${player.GetValue():F2}\n");
                }
            }

            //// Team extensions
            //team.PrintTeamReport();
            #endregion

            #region TODO4
            // 8. Simulate a match with events
            Console.WriteLine("\n--- 8. EVENTS ---\n");

            var match = new Match();
            var commentator = new MatchCommentator();
            var fans = new Fans("Al Ahly");
            var coach = new Coach("Koller");

            // Subscribe to events
            match.GoalScored += commentator.OnGoalScored;
            match.GoalScored += fans.OnGoalScored;
            match.GoalScored += coach.OnGoalScored;

            // Run the match
            match.StartMatch();
            match.ScoreGoal("Salah");
            match.InjurePlayer("Hegazi");
            match.ScoreGoal("Trezeguet");
            match.EndMatch();
            #endregion

            // All OOP principles should be demonstrated!
        }

        // TODO3: Named method used as a PlayerFilter delegate
    }
    public abstract class FootballPlayer
    {

        #region TODO1: Implement with proper encapsulation
        // - Name (string)
        // - JerseyNumber (int)
        // - Age (int)
        // - IsInjured (bool)
        // - Goals (int)
        // - Assists (int)
        public string Name { get; private set; }
        public int JerseyNumber { get; private set; }
        public int Age { get; private set; }
        public bool IsInjured { get; private set; }
        public int Goals { get; private set; }
        public int Assists { get; private set; }

        // TODO1: Add constructor
        protected FootballPlayer(string name, int jerseyNumber, int age)
        {
            Name = name;
            JerseyNumber = jerseyNumber;
            Age = age;
            IsInjured = false;
            Goals = 0;
            Assists = 0;
        }

        // TODO1: Add abstract Play() method
        public abstract void Play();

        // TODO1: Add virtual Train() method
        public virtual void Train()
        {
            Console.WriteLine(Name + " is training.");
        }

        // TODO1: Add methods for Injure(), Recover(), ScoreGoal(), MakeAssist()
        public void Injure()
        {
            IsInjured = true;
            Console.WriteLine(Name + " has been injured.");
        }

        public void Recover()
        {
            IsInjured = false;
            Console.WriteLine(Name + " has recovered from injury.");
        }

        public void ScoreGoal()
        {
            Goals++;
            Console.WriteLine(Name + " scored a goal! Total goals: " + Goals);
        }

        public void MakeAssist()
        {
            Assists++;
            Console.WriteLine(Name + " made an assist! Total assists: " + Assists);
        }
        #endregion
    }
    #region TODO1: Create Goalkeeper class

    // - Inherits from FootballPlayer
    // - Add CleanSheets property
    // - Override Play() and Train()
    public class Goalkeeper : FootballPlayer
    {
        public int CleanSheets { get; private set; }

        public Goalkeeper(string name, int jerseyNumber, int age, int cleanSheets)
            : base(name, jerseyNumber, age)
        {
            CleanSheets = cleanSheets;
        }

        public override void Play()
        {
            Console.WriteLine(Name + " is guarding the goal.");
        }

        public override void Train()
        {
            base.Train();
            Console.WriteLine(Name + "is practicing shot-stopping drills.");
        }
    }
    #endregion


    #region TODO1: Create Defender class

    // - Inherits from FootballPlayer
    // - Add Tackles, Clearances properties
    // - Override Play() and Train()
    public class Defender : FootballPlayer
    {
        public int Tackles { get; private set; }
        public int Clearances { get; private set; }

        public Defender(string name, int jerseyNumber, int age, int tackles, int clearances)
            : base(name, jerseyNumber, age)
        {
            Tackles = tackles;
            Clearances = clearances;
        }

        public override void Play()
        {
            Console.WriteLine(Name + " is marking the opposition attackers.");
        }

        public override void Train()
        {
            base.Train();
            Console.WriteLine(Name + " is practicing tackling drills.");
        }
    }
    #endregion

    #region TODO1: Create Midfielder class

    // - Inherits from FootballPlayer
    // - Add Passes, KeyPasses properties
    // - Override Play() and Train()
    public class Midfielder : FootballPlayer
    {
        public int Passes { get; private set; }
        public int KeyPasses { get; private set; }

        public Midfielder(string name, int jerseyNumber, int age, int passes, int keyPasses)
            : base(name, jerseyNumber, age)
        {
            Passes = passes;
            KeyPasses = keyPasses;
        }

        public override void Play()
        {
            Console.WriteLine(Name + " is controlling the midfield.");
        }

        public override void Train()
        {
            base.Train();
            Console.WriteLine(Name + " is practicing passing drills.");
        }
    }
    #endregion

    #region  TODO1: Create Forward class

    // - Inherits from FootballPlayer
    // - Add ShotsOnTarget property
    // - Override Play() and Train()
    public class Forward : FootballPlayer
    {
        public int ShotsOnTarget { get; private set; }

        public Forward(string name, int jerseyNumber, int age, int shotsOnTarget)
            : base(name, jerseyNumber, age)
        {
            ShotsOnTarget = shotsOnTarget;
        }

        public override void Play()
        {
            Console.WriteLine(Name + " is attacking the goal.");
        }

        public override void Train()
        {
            base.Train();
            Console.WriteLine(Name + " is practicing finishing drills.");
        }
    }
    #endregion
    //======================================+=============================================

    //======================================+=============================================

    public class Team : IEnumerable<FootballPlayer>
    {
        #region TODO1:

        // - Name (string)
        // - Players (List<FootballPlayer>)
        // - CoachName (string)
        public string Name { get; private set; }
        public List<FootballPlayer> Players { get; private set; }
        public string CoachName { get; private set; }

        public Team(string name, string coachName)
        {
            Name = name;
            CoachName = coachName;
            Players = new List<FootballPlayer>();
        }

        // TODO1: Add methods
        // - AddPlayer(FootballPlayer player)
        // - RemovePlayer(int jerseyNumber)
        // - DisplaySquad()
        // - CalculateAverageAge()
        // - GetTotalGoals()
        // - GetTopScorer()
        public void AddPlayer(FootballPlayer player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(int jerseyNumber)
        {
            Players.RemoveAll(p => p.JerseyNumber == jerseyNumber);
        }

        public void DisplaySquad()
        {
            Console.WriteLine("\nSquad for " + Name + " (Coach: " + CoachName + "):");
            foreach (var player in Players)
            {
                Console.WriteLine("#" + player.JerseyNumber + " " + player.Name + " - Age: " + player.Age + ", Goals: " + player.Goals + ", Assists: " + player.Assists);
            }
        }

        public double CalculateAverageAge()
        {
            return Players.Count == 0 ? 0 : Players.Average(p => p.Age);
        }

        public int GetTotalGoals()
        {
            return Players.Sum(p => p.Goals);
        }

        public FootballPlayer GetTopScorer()
        {
            return Players.OrderByDescending(p => p.Goals).FirstOrDefault();
        }
        #endregion

        #region TODO2: Implement indexer by position (int)

        public FootballPlayer this[int index]
        {
            get { return (index >= 0 && index < Players.Count) ? Players[index] : null; }
            set { if (index >= 0 && index < Players.Count) Players[index] = value; }
        }
        #endregion

        #region  Assignment: Implement indexer by other
        public FootballPlayer this[int jerseyNumber, bool byNumber]
        {
            get { return Players.FirstOrDefault(p => p.JerseyNumber == jerseyNumber); }
        }

        // Assignment: Implement indexer by name (string)
        public FootballPlayer this[string name]
        {
            get { return Players.FirstOrDefault(p => p.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0); }
        }

        // Assignment: Implement indexer by position and stat (bonus challenge)
        public int this[string position, string stat]
        {
            get
            {
                var filtered = Players.Where(p => p.GetType().Name.Equals(position, StringComparison.OrdinalIgnoreCase));
                if (stat.Equals("Goals", StringComparison.OrdinalIgnoreCase))
                    return filtered.Sum(p => p.Assists);
                return 0;
            }
        }
        #endregion

        #region Assignmnet: Make Team class implement IEnumerable<FootballPlayer>
        // TODO: Implement GetEnumerator with yield
        public IEnumerator<FootballPlayer> GetEnumerator()
        {
            foreach (var player in Players)
                yield return player;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // TODO: Implement custom iteration methods:
        // - GetStarPlayers() - Only star players
        // - GetInjuredPlayers() - Only injured players
        // - GetPlayersByAgeRange(int min, int max)
        // - GetPlayersSortedByGoals() - Sorted by goals
        // - GetPlayersByPosition(string position) - Filter by position
        public IEnumerable<FootballPlayer> GetStarPlayers()
        {
            foreach (var player in Players)
                if (player.IsStarPlayer())
                    yield return player;
        }

        public IEnumerable<FootballPlayer> GetInjuredPlayers()
        {
            foreach (var player in Players)
                if (player.IsInjured)
                    yield return player;
        }

        public IEnumerable<FootballPlayer> GetPlayersByAgeRange(int min, int max)
        {
            foreach (var player in Players)
                if (player.Age >= min && player.Age <= max)
                    yield return player;
        }

        public IEnumerable<FootballPlayer> GetPlayersSortedByGoals()
        {
            foreach (var player in Players.OrderByDescending(p => p.Goals))
                yield return player;
        }

        public IEnumerable<FootballPlayer> GetPlayersByPosition(string position)
        {
            foreach (var player in Players)
                if (player.GetType().Name.Equals(position, StringComparison.OrdinalIgnoreCase))
                    yield return player;
        }
        #endregion
    }

    //======================================+=============================================

    //======================================+=============================================
    // 
    #region TODO2: Create generic Squad<T> where T : FootballPlayer
    public class Squad<T> where T : FootballPlayer
    {
        // TODO3: Implement generic collection
        // - Private List<T> _players
        // - AddPlayer(T player)
        // - RemovePlayer(int jerseyNumber)
        // - GetPlayersByPosition(string position) (filter by player type)
        // - GetTopScorers(int count)
        // - GetAverageRating()
        private List<T> _players = new List<T>();

        public void AddPlayer(T player)
        {
            _players.Add(player);
        }

        public void RemovePlayer(int jerseyNumber)
        {
            _players.RemoveAll(p => p.JerseyNumber == jerseyNumber);
        }

        public List<T> GetPlayersByPosition(string position)
        {
            return _players.Where(p => p.GetType().Name.Equals(position, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<T> GetTopScorers(int count)
        {
            return _players.OrderByDescending(p => p.Goals).Take(count).ToList();
        }

        public double GetAverageRating()
        {
            return _players.Count == 0 ? 0 : _players.Average(p => p.Goals + p.Assists);
        }

        public List<T> GetAll()
        {
            return _players;
        }

        public void DisplayAll()
        {
            foreach (var player in _players)
            {
                Console.WriteLine("#" + player.JerseyNumber + " " + player.Name + " - Goals: " + player.Goals + ", Assists: " + player.Assists);
            }
        }
    }
    #endregion 

    // 
    #region Assignmnet: Create StatsCalculator<T> where T : FootballPlayer
    public class StatsCalculator<T> where T : FootballPlayer
    {
        // TODO: Implement methods
        // - CalculateAverageGoals(List<T> players)
        // - CalculateAverageAge(List<T> players)
        // - GetBestPlayer(List<T> players)
        // - GetWorstPlayer(List<T> players)
        public double CalculateAverageGoals(List<T> players)
        {
            return players.Count == 0 ? 0 : players.Average(p => p.Goals);
        }

        public double CalculateAverageAge(List<T> players)
        {
            return players.Count == 0 ? 0 : players.Average(p => p.Age);
        }

        public T GetBestPlayer(List<T> players)
        {
            return players.OrderByDescending(p => p.Goals).FirstOrDefault();
        }

        public T GetWorstPlayer(List<T> players)
        {
            return players.OrderBy(p => p.Goals).FirstOrDefault();
        }
    }

    #endregion

    // TODO3: Declare delegate for player filtering  PlayerFilter(FootballPlayer player);
    public delegate bool PlayerFilter(FootballPlayer player);



    #region TODO3: Create PlayerFilterExtensions class with methods
    public static class PlayerFilterExtensions
    {
        // TODO: Create filter methods
        // - IsStarPlayer() (Goals > 20)
        // - IsVeteran() (Age > 30)
        // - IsInjured() (IsInjured == true)
        // - IsGoalkeeper() (is Goalkeeper)
        // - HasMinimumGoals(int minGoals)
        // - ByPosition(string position)
        public static bool IsStarPlayer(this FootballPlayer player)
        {
            return player.Goals > 20;
        }

        public static bool IsVeteran(this FootballPlayer player)
        {
            return player.Age > 30;
        }

        public static bool IsInjured(this FootballPlayer player)
        {
            return player.IsInjured;
        }

        public static bool IsGoalkeeper(this FootballPlayer player)
        {
            return player is Goalkeeper;
        }

        public static bool HasMinimumGoals(this FootballPlayer player, int minGoals)
        {
            return player.Goals >= minGoals;
        }

        public static bool ByPosition(this FootballPlayer player, string position)
        {
            return player.GetType().Name.Equals(position, StringComparison.OrdinalIgnoreCase);
        }

        // TODO3 (Player extensions used in Main step 8): GetRating, IsStar, PrintStats, GetValue
        public static int GetRating(this FootballPlayer player)
        {
            int rating = player.Goals * 2 + player.Assists;
            return rating;
        }

        public static bool IsStar(this FootballPlayer player)
        {
            if (player.Goals > 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void PrintStats(this FootballPlayer player)
        {
            Console.WriteLine(player.Name + " Stats:");
            Console.WriteLine("Age: " + player.Age);
            Console.WriteLine("Goals: " + player.Goals);
            Console.WriteLine("Assists: " + player.Assists);
        }

        public static double GetValue(this FootballPlayer player)
        {
            double value = (player.Goals * 1000000) + (player.Assists * 500000) - (player.Age * 10000);
            if (value < 0)
            {
                value = 0;
            }
            return value;
        }
    }
    #endregion 

    // 
    #region TODO3: Create TeamReportGenerator class
    public class TeamReportGenerator
    {
        // TODO3: Implement GenerateReport method
        // Takes: List<FootballPlayer>, string title, PlayerFilter filter
        // Displays: Players matching the filter with their stats
        public void GenerateReport(List<FootballPlayer> players, string title, PlayerFilter filter)
        {
            Console.WriteLine($"\n--- Report: {title} ---");
            foreach (var player in players)
            {
                if (filter(player))
                {
                    Console.WriteLine("#" + player.JerseyNumber + " " + player.Name + " - Age: " + player.Age + ", Goals: " + player.Goals);
                }
            }
        }
    }
    #endregion

    //
    #region Assignment:Create methods using Func, Action, Predicate
    public class TeamAnalyzer
    {
        // TODO: Method using Func to calculate team stat
        public int CalculateTeamStat(List<FootballPlayer> players, Func<FootballPlayer, int> selector)
        {
            // Returns sum of selected stat
            return players.Sum(selector);
        }

        // TODO: Method using Action to perform operation
        public void ApplyToAllPlayers(List<FootballPlayer> players, Action<FootballPlayer> action)
        {
            // Applies operation to all players
            foreach (var player in players)
                action(player);
        }

        // TODO: Method using Predicate to filter
        public List<FootballPlayer> FindPlayers(List<FootballPlayer> players, Predicate<FootballPlayer> predicate)
        {
            // Returns players matching predicate
            return players.FindAll(predicate);
        }
    }
    #endregion
    // 
    #region Assignment: Create static class ListExtensions
    public static class ListExtensions
    {
        // TODO: Add methods:
        // - Shuffle<T>(this List<T> list)
        // - GetTop<T>(this List<T> list, int count, Func<T, int> selector)
        // - GetRandom<T>(this List<T> list, int count)
        public static void Shuffle<T>(this List<T> list)
        {
            var rng = new Random();
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
        public static List<T> GetTop<T>(this List<T> list, int count, Func<T, int> selector)
        {
            return list.OrderByDescending(selector).Take(count).ToList();
        }
        public static List<T> GetRandom<T>(this List<T> list, int count)
        {
            var rng = new Random();
            return list.OrderBy(_ => rng.Next()).Take(count).ToList();
        }
    }
    #endregion
    // 
    #region TODO4: Create Match class with events
    public class Match
    {
        // TODO: Declare events
        // - GoalScored (string scorer)
        // - PlayerInjured (string player)
        // - RedCard (string player)
        // - MatchStarted
        // - MatchEnded
        // - Substitution (string playerIn, string playerOut)
        public event Action<string> GoalScored;
        public event Action<string> PlayerInjured;
        public event Action<string> RedCard;
        public event Action MatchStarted;
        public event Action MatchEnded;
        public event Action<string, string> Substitution;

        // TODO: Implement methods
        // - StartMatch()
        // - ScoreGoal(string scorer)
        // - InjurePlayer(string player)
        // - ShowRedCard(string player)
        // - EndMatch()
        // - MakeSubstitution(string playerIn, string playerOut)
        public void StartMatch()
        {
            Console.WriteLine("\nThe match has started!");
            MatchStarted?.Invoke();
        }
        public void ScoreGoal(string scorer)
        {
            GoalScored?.Invoke(scorer);
        }
        public void InjurePlayer(string player)
        {
            PlayerInjured?.Invoke(player);
        }
        public void ShowRedCard(string player)
        {
            RedCard?.Invoke(player);
        }
        public void EndMatch()
        {
            MatchEnded?.Invoke();
            Console.WriteLine("\nThe match has ended!");
        }
        public void MakeSubstitution(string playerIn, string playerOut)
        {
            Substitution?.Invoke(playerIn, playerOut);
        }
    }
    // TODO4: Create observers/listeners
    public class MatchCommentator
    {
        // TODO4: Subscribe to events and display commentary
        public void OnGoalScored(string scorer)
        {
            Console.WriteLine("[Commentator] GOAL! " + scorer + " finds the back of the net!");
        }
    }
    public class Fans
    {
        // TODO4: Subscribe to events and display fan reactions
        private string _teamName;
        public Fans(string teamName)
        {
            _teamName = teamName;
        }
        public void OnGoalScored(string scorer)
        {
            Console.WriteLine("[Fans of " + _teamName + "] cheer wildly for " + scorer + "!");
        }
    }
    public class Coach
    {
        // TODO4: Subscribe to events and display coach reactions
        private string _name;
        public Coach(string name)
        {
            _name = name;
        }
        public void OnGoalScored(string scorer)
        {
            Console.WriteLine("[Coach " + _name + "] nods approvingly at " + scorer + "'s goal.");
        }
    }
    public class VAR
    {
        // TODO4: Subscribe to events and display VAR reviews
        public void OnGoalScored(string scorer)
        {
            Console.WriteLine("Reviewing " + scorer + "'s goal... Goal confirmed!");
        }
    }
    #endregion
}

//feel free to add extra functionalites, each of which will be counted as bonus mohsens!!