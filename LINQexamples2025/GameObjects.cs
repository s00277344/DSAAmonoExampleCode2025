using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQexamples2025
{
    public class GameObjects
    {
        public static Random r = new Random();

        public List<Collectable> Collectables = new List<Collectable>()
        {
            new Collectable { id= Guid.NewGuid().ToString(), selected = (r.Next(0,2)==1?true:false), val = 100},
              new Collectable { id= Guid.NewGuid().ToString(), selected = (r.Next(0,2)==1?true:false), val = r.Next(100,200)},
                new Collectable { id= Guid.NewGuid().ToString(), selected = (r.Next(0,2)==1?true:false), val = 300},
                  new Collectable { id= Guid.NewGuid().ToString(), selected = (r.Next(0,2)==1?true:false), val = r.Next(100,200)},
                    new Collectable { id= Guid.NewGuid().ToString(), selected = (r.Next(0,2)==1?true:false), val = r.Next(100,200)},
        };

        public List<Player> players = new List<Player>
        {
            new Player { PlayerId = Guid.NewGuid().ToString(),
                                         FirstName = "Paul",
                                         SceondName = "Powell",
                                          GamerTag = "Post Dark",
                                             XP = 1000},

            new Player { PlayerId = Guid.NewGuid().ToString(),
                                         FirstName = "Fred",
                                         SceondName = "Flinstone",
                                          GamerTag = "Twinny",
                                             XP = 100},

            new Player { PlayerId = Guid.NewGuid().ToString(),
                                         FirstName = "Margaret",
                                         SceondName = "Muldooney",
                                          GamerTag = "Minny",
                                             XP = 600},
            new Player { PlayerId = Guid.NewGuid().ToString(),
                                         FirstName = "Bill",
                                         SceondName = "Bloggs",
                                          GamerTag = "Mahindy",
                                             XP = 250},
    };
        public List<GameData> games = new List<GameData>
        {
            new GameData
            {
                GameID = Guid.NewGuid().ToString(),
                GameName = "Gear Up"
            },
            new GameData
            {
                GameID = Guid.NewGuid().ToString(),
                GameName = "Game on"
            }
        };
        public List<GameScore> scores = new List<GameScore>();
        

        public GameObjects()
        {
            // Create the Game scores here as the Games and players will be created
            Random _randomScore = new Random();

            foreach (var g in games)
            {
                var randomPlayer = players
                        .Select(p => new { p.PlayerId, gid = Guid.NewGuid() })
                        .OrderBy(o => o.gid).Take(3).ToList();

                foreach (var p in randomPlayer)
                {
                    scores.Add(new GameScore
                    {
                        ScoreID = Guid.NewGuid().ToString(),
                        GameID = g.GameID,
                        PlayerID = p.PlayerId,
                        score = _randomScore.Next(5, 600)
                    });
                }

            }

        }

        


    public void ExportModel()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            NewLine = Environment.NewLine,
            HasHeaderRecord = true
        };

        using (var writer = new StreamWriter("games.csv"))
        using (var csv = new CsvWriter(writer, config))
        {
            csv.WriteRecords(games);
        }

        using (var writer = new StreamWriter("players.csv"))
        using (var csv = new CsvWriter(writer, config))
        {
            csv.WriteRecords(players);
        }

        using (var writer = new StreamWriter("scores.csv"))
        using (var csv = new CsvWriter(writer, config))
        {
            csv.WriteRecords(scores);
        }

        using (var writer = new StreamWriter("collectables.csv"))
        using (var csv = new CsvWriter(writer, config))
        {
            csv.WriteRecords(Collectables);
        }
    }

    }
    public class GameData
    {
        public string GameID { get; set; } // Key Field
        public string GameName { get; set; }

        public override string ToString()
        {
            return String.Concat(" Game Name ", GameName);
        }
    }

    public class GameScore
    {
        public string ScoreID { get; set; } // Key Field
        public string GameID { get; set; }
        public string PlayerID { get; set; }
        public int score { get; set; }

        public override string ToString()
        {
            return String.Concat(new string[] 
                            {" Game ID ", GameID," Player ID ",
                                PlayerID, " Score ",score.ToString() });
        }
    }
    public class Player
    {
        public string PlayerId { get; set; } // Key Field
        public int XP { get; set; }
        public string GamerTag { get; set; }
        public string FirstName { get; set; }
        public string SceondName { get; set; }

        public override string ToString()
        {
            return String.Concat(new string[]
                            {" XP ", XP.ToString()," Gamer Tag ",
                                GamerTag, " first name ",FirstName });
        }
    }

    public class Collectable
    {
        public string id { get; set; }
        public bool selected { get; set; }
        public int val { get; set; }
        public override string ToString()
        {
            return String.Concat(new string[]
                            {" ID ", id.ToString()," Value ",
                                val.ToString(), " first name ", (selected? "Selected":"Not Selected")});
        }
    }


}
