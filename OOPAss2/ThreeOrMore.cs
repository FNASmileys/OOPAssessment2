namespace OOPAss2;
using System.Linq;

public class ThreeOrMore : Game {
    /*
    Roll all 5 dice hoping for a 3-of-a-kind or better.
    If 2-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice.
    3-of-a-kind: 3 points
    4-of-a-kind: 6 points
    5-of-a-kind: 12 points 
    First to a total of 20.
    */
    private List<Die> checker(Die[] dice) {
        List<Die> largest = new List<Die>();
        foreach (var die in dice) {

            var output = (from l in dice
                where l.Value == die.Value
                select l).ToList();
            
            if (output.Count > largest.Count) 
                largest = output;
        }

        return largest;
    }

    private void diePrint(Die[] dice) {
        var values = from Die die in dice select die.Value;
        Console.WriteLine($"you rolled {string.Join(", ", values)}");
    }
    
    public override void play() {
        Console.WriteLine("would you like to play against (1) the computer or (2) another player");
        string ans = Console.ReadLine();
        bool player2;
        bool p1Winner;
        if (ans == "1") {
            player2 = false;
        }
        else {
            player2 = true;
        }

        int playerOneScore = 0;
        int playerTwoScore = 0;
        while (true) {
            Die[] dice = new Die[5];
            for (int i = 0; i < dice.Length; i++) {
                dice[i] = new Die();
            }
            
            Console.WriteLine("player 1 turn \n press any key to roll");
            Console.ReadLine();
            Console.WriteLine("rolling dice...");
            foreach (Die i in dice) {
                i.Roll();
            }

            /*List<Die> largest = new List<Die>();
            foreach (var die in dice) {

                var output = (from l in dice
                    where l.Value == die.Value
                    select l).ToList(); 
                if (output.Count > largest.Count) {
                    for (int i = 0; i > output.Count; i++) {
                        largest = output;
                    }
                } 
            }*/
            List<Die> largest = checker(dice);
            diePrint(dice);
            
            if (largest.Count == 2) {
                Console.WriteLine("you got 2 of the same dice\nwould you can:\n(1) re-roll all dice\n(2) re-roll the remaining dice");
                string choice = Console.ReadLine();
                if (choice == "1") {
                    Console.WriteLine("re-rolling all dice...");
                    foreach (var l in dice) {
                        l.Roll();
                    }
                    diePrint(dice);
                    largest = checker(dice);
                }
                
                else {
                    Console.WriteLine("re-rolling the remaining dice...");
                    var output = (from l in dice
                        where l.Value != largest[0].Value
                        select l).ToArray();
                    foreach (var n in output) {
                        n.Roll();
                    }
                    diePrint(dice);
                    largest = checker(dice);
                }
            }
            
            if (largest.Count == 3) {
                Console.WriteLine("you got 3 of the same dice\nyou gained 3 points");
                playerOneScore = playerOneScore + 3;
            }
            else if (largest.Count == 4) {
                Console.WriteLine("you got 4 of the same dice\nyou gained 6 points");
                playerOneScore = playerOneScore + 6;
            }
            else if (largest.Count == 5) {
                Console.WriteLine("you got 5 of the same dice\nyou gained 12 points");
                playerOneScore = playerOneScore + 12;
            }
            else {
                Console.WriteLine("you didn't get three or more of the same dice\nyou gained NO points");
            }
            Console.WriteLine($"player one score is now {playerOneScore}");
            Testing.tomSeccondTolast = Testing.tomLast;
            Testing.tomLast = playerOneScore;
            if (playerOneScore >= 20) {
                p1Winner = true;
                break;
            }
            
            // PLAYER 2 //////////////////////////////////////////
            if (player2) {
                Console.WriteLine("player 2 turn \npress any key to roll");
                Console.ReadLine();
            }
            else {
                Console.WriteLine("player two turn (computer)");
            }
            Console.WriteLine("rolling dice...");
            foreach (Die i in dice) {
                i.Roll();
            }
            
            largest = checker(dice);
            diePrint(dice);
            if (largest.Count == 2) {
                string choice;
                if (player2) {
                    Console.WriteLine(
                        "you got 2 of the same dice\nwould you can:\n(1) re-roll all dice\n(2) re-roll the remaining dice");
                    choice = Console.ReadLine();
                }
                else {
                    Random rnd = new Random();
                    choice = rnd.Next(1,3).ToString();
                }
                if (choice == "1") {
                    Console.WriteLine("re-rolling all dice...");
                    foreach (var l in dice) {
                        l.Roll();
                    }
                    diePrint(dice);
                    largest = checker(dice);
                }
                else {
                    Console.WriteLine("re-rolling the remaining dice...");
                    var output = (from l in dice
                        where l.Value != largest[0].Value
                        select l).ToArray();
                    foreach (var n in output) {
                        n.Roll();
                    }
                    diePrint(dice);
                    largest = checker(dice);
                }
            }
            if (largest.Count == 3) {
                Console.WriteLine("you got 3 of the same dice\nyou gained 3 points");
                playerTwoScore = playerTwoScore + 3;
            }
            else if (largest.Count == 4) {
                Console.WriteLine("you got 4 of the same dice\nyou gained 6 points");
                playerTwoScore = playerTwoScore + 6;
            }
            else if (largest.Count == 5) {
                Console.WriteLine("you got 5 of the same dice\nyou gained 12 points");
                playerTwoScore = playerTwoScore + 12;
            }
            else {
                Console.WriteLine("you didn't get three or more of the same dice\nyou gained NO points");
            }
            Console.WriteLine($"player 2 score is now {playerTwoScore}");
            Testing.tomSeccondTolast = Testing.tomLast;
            Testing.tomLast = playerTwoScore;
            if (playerTwoScore >= 20) {
                p1Winner = false;
                break;
            }
        }

        if (p1Winner) {
            Console.WriteLine($"player one wins with a score of {playerOneScore}\nplayer two got a score of {playerTwoScore}");
            Statistics.ThreeOrMore(playerOneScore);
        }
        else {
            Console.WriteLine($"player two wins with a score of {playerTwoScore}\nplayer one got a score of {playerOneScore}");
            Statistics.ThreeOrMore(playerTwoScore);
        }
        
        
    }
}