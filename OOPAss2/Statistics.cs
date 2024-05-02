using System.IO.MemoryMappedFiles;
using System.Text.Json;

namespace OOPAss2;

public static class Statistics {
    //private static int threeOrMoreHighscore = 0;
    //private static string threeOrMoreHighscorer = "";
    static GameData sevensOutData = new GameData();
    static GameData threeOrMoreData = new GameData();
    private class GameData {
        public int NumberOfPlays { get; set; } = 0;
        public List<int> Highscores { get; set; } = [ ];

        public void HighscoreAddAndSort(int score) {
            if (Highscores.Count < 10) {
                Console.WriteLine("highscore added to the list!!!");
                Highscores.Add(score);
            }
            else {
                if (Highscores[-1] < score) {
                    Console.WriteLine("new highscore added to the list!!!!!!");
                    Highscores[-1] = score;
                    
                }
            }
            Highscores.Sort();
            NumberOfPlays++;
        }
    }
    public static void ThreeOrMore(int score) {
        threeOrMoreData.HighscoreAddAndSort(score);
    }

    public static void SevensOut(int score) {
        sevensOutData.HighscoreAddAndSort(score);
    }

    public static void GetHighScores() {
        Console.WriteLine("would you like the highscores and playcounts for:\n(1) sevens out\n(2) three or more");
        string choice = Console.ReadLine();
        if (choice == "1") {
            Console.WriteLine($"play count = {string.Join(", ", sevensOutData.NumberOfPlays)}\nhighscores = {string.Join(", ", sevensOutData.Highscores)}");
        }
        else {
            Console.WriteLine($"play count = {string.Join(", ", threeOrMoreData.NumberOfPlays)}\nhighscores = {string.Join(", ", threeOrMoreData.Highscores)}");
        }
    }

    public static void Load() {
        
        string templateJson = JsonSerializer.Serialize(new GameData());
        
        if (!File.Exists("seven.json"))
            File.WriteAllText("seven.json", templateJson);
        if (!File.Exists("three.json"))
            File.WriteAllText("three.json", templateJson);
        
        sevensOutData = JsonSerializer.Deserialize<GameData>(File.ReadAllText("seven.json"));
        threeOrMoreData = JsonSerializer.Deserialize<GameData>(File.ReadAllText("three.json"));
    }

    public static void Save() {
        string sevenJson = JsonSerializer.Serialize(sevensOutData);
        File.WriteAllText("seven.json", sevenJson);
        string threeJson = JsonSerializer.Serialize(sevensOutData);
        File.WriteAllText("three.json", threeJson);
    }
}