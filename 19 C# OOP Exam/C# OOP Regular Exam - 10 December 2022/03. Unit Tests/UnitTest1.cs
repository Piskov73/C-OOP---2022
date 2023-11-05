using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballPlayer player;
        private FootballTeam team;

        [SetUp]
        public void Setup()
        {
            player = new FootballPlayer("Name", 15, "Goalkeeper");
            team = new FootballTeam("Name", 20);
        }

        [Test]
        public void Test_ConstructorFootballPlayer()
        {
            player = new FootballPlayer("Name", 15, "Goalkeeper");
            Assert.NotNull(player);
            Assert.AreEqual(0, player.ScoredGoals);
        }
        [Test]
        public void Test_FootballPlayerNameValid()
        {
            string name = "Ivanco";
            player = new FootballPlayer(name, 15, "Goalkeeper");
            Assert.AreEqual(name, player.Name);
        }
        [Test]
        public void Test_FootballPlayerNameInvalid()
        {
            string name = null;

            Assert.Throws<ArgumentException>(() => new FootballPlayer(name, 15, "Goalkeeper"), "Name cannot be null or empty!");
        }

        [Test]
        public void Test_FootballPlayerNameValidPlayerNumberValid()
        {
            string name = "Ivanco";
            int number = 12;
            player = new FootballPlayer(name, number, "Goalkeeper");
            Assert.AreEqual(number, player.PlayerNumber);
        }
        [Test]
        public void Test_FootballPlayerNameValidPlayerNumberInvalid()
        {
            string name = "Ivanco";
            int number = 35;

            Assert.Throws<ArgumentException>(() => new FootballPlayer(name, number, "Goalkeeper")
            , "Player number must be in range [1,21]");
        }
        [Test]
        public void Test_FootballPlayerNameValidPlayerPositionValid()
        {
            string name = "Ivanco";
            int number = 12;
            string position = "Goalkeeper";
            player = new FootballPlayer(name, number, "Goalkeeper");
            Assert.AreEqual(position, player.Position);
        }
        [Test]
        public void Test_FootballPlayerNameValidPlayerPositionInvalid()
        {
            string name = "Ivanco";
            int number = 12;
            string position = "Znam li";

            Assert.Throws<ArgumentException>(() => new FootballPlayer(name, number, position), "Invalid Position");
        }
        [Test]
        public void Test_Score()
        {
            string name = "Ivanco";
            int number = 12;
            string position = "Goalkeeper";
            player = new FootballPlayer(name, number, position);
            player.Score();
            Assert.AreEqual(1, player.ScoredGoals);
        }

        [Test]
        public void Test_Constructor()
        {
            string name = "Kaspichan";
            int capacity = 20;

            team = new FootballTeam(name, capacity);
            Assert.NotNull(team);
            Assert.AreEqual(name, team.Name);
            Assert.AreEqual(capacity, team.Capacity);
        }
        [Test]
        public void Test_NameValid()
        {
            string name = "Kaspichan";
            int capacity = 20;

            team = new FootballTeam(name, capacity);
            Assert.NotNull(team);
            Assert.AreEqual(name, team.Name);
            Assert.AreEqual(capacity, team.Capacity);
        }
        [Test]
        public void Test_NameInvalid()
        {
            string name = null;
            int capacity = 20;

        Assert.Throws<ArgumentException>(() => new FootballTeam(name, capacity), "Name cannot be null or empty!");
        }
        [Test]
        public void Test_CapacitiArgumentException()
        {
            string name = null;
            int capacity = 10;

            Assert.Throws<ArgumentException>(() => new FootballTeam(name, capacity), "Capacity min value = 15");
        }

        [Test]
        public void Test_AddNewPlayerMethod()
        {
            string name = "Kaspichan";
            int capacity = 15;

            team = new FootballTeam(name, capacity);

            string namePlayr = "Ivanco";
            int number = 12;
            string position = "Goalkeeper";
            player = new FootballPlayer(namePlayr, number, "Goalkeeper");

            string expecte = $"Added player {namePlayr} in position {position} with number {number}";
            string actual=team.AddNewPlayer(player);
            Assert.AreEqual(expecte, actual);

        }

        [Test]
        public void Test_AddNewPlayerInvalid()
        {
            string name = "Kaspichan";
            int capacity = 15;

            team = new FootballTeam(name, capacity);

            team.AddNewPlayer(new FootballPlayer("Name2", 2, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name1", 3, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name1", 4, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name1", 5, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name1", 6, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name1", 7, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name1", 8, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name1", 9, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name1", 10, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name1", 11, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name1", 12, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name1", 13, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name1", 14, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name1", 15, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name1", 1, "Goalkeeper"));

            Assert.AreEqual(15, team.Players.Count);
            string expecte = "No more positions available!";
            string actual = team.AddNewPlayer(new FootballPlayer("Name16", 16, "Goalkeeper"));

            Assert.AreEqual(expecte, actual);

        }

        [Test]
        public void Test_PickPlayer()
        {
            string name = "Kaspichan";
            int capacity = 15;

            team = new FootballTeam(name, capacity);

            team.AddNewPlayer(new FootballPlayer("Name2", 2, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name3", 3, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name4", 4, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name5", 5, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name6", 6, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name7", 7, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name8", 8, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name9", 9, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name10", 10, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name11", 11, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name12", 12, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name13", 13, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name14", 14, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name15", 15, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name1", 1, "Goalkeeper"));

            string namePlayer = "Name14";

            FootballPlayer footballPlayer=team.PickPlayer(namePlayer);

            Assert.IsNotNull(footballPlayer);

            Assert.AreEqual(namePlayer, footballPlayer.Name);

            namePlayer = "Ivan";

            footballPlayer = team.PickPlayer(namePlayer);

            Assert.Null(footballPlayer);

        }

        [Test]
        public void Test_PlayerScore()
        {
            string name = "Kaspichan";
            int capacity = 15;

            team = new FootballTeam(name, capacity);

            team.AddNewPlayer(new FootballPlayer("Name2", 2, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name3", 3, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name4", 4, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name5", 5, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name6", 6, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name7", 7, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name8", 8, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name9", 9, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name10", 10, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name11", 11, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name12", 12, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name13", 13, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name14", 14, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name15", 15, "Goalkeeper"));
            team.AddNewPlayer(new FootballPlayer("Name1", 1, "Goalkeeper"));

            string namePlayer = "Name10";

            string expecte= $"{namePlayer} scored and now has {1} for this season!";

            string actual = team.PlayerScore(10);

            Assert.AreEqual(expecte, actual);

        }
    }
}