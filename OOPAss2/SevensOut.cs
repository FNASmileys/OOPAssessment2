namespace OOPAss2;

public class SevensOut : Game{
    
    public override void play() {
        Console.WriteLine("would you like to play against (1) the computer or (2) another player");
        string ans = Console.ReadLine();
        
        string Player2;
        if (ans == "1") {
            Player2 = "computer";
        }
        else {
            Player2 = "player 2";
        }

        int playerOneScore = 0;
        int playerTwoScore = 0;
        
        //bool gameOver = false;
        while(true) {
            Console.WriteLine("player 1 turn \n press any key to roll");
            Console.ReadLine();
            Console.WriteLine("rolling dice...");
            Die d1 = new Die();
            Die d2 = new Die();
            int dice1 = d1.Roll();
            int dice2 = d2.Roll();
            Console.WriteLine($"dice one landed on: {dice1} \ndice two landed on: {dice2}");
            Testing.sevensDie = [d1, d2];
            if (dice1 + dice2 == 7) {
                break;
            }
            if (dice1 == dice2) {
                playerOneScore = playerOneScore + ((dice1 + dice2) * 2);
            }
            else {
                playerOneScore = playerOneScore + dice1 + dice2;
            }
            Console.WriteLine($"player one score: {playerOneScore}");
            Console.WriteLine($"{Player2} turn");
            if (Player2 == "player 2") {
                Console.WriteLine("press any key to roll");
                Console.ReadLine();
            }
            Console.WriteLine("rolling dice...");
            int dice3 = d1.Roll();
            int dice4 = d2.Roll();
            Console.WriteLine($"dice one landed on: {dice3}\ndice two landed on: {dice4}");
            Testing.sevensDie = [d1, d2];
            if (dice3 + dice4 == 7) {
                break;
            }
            if (dice3 == dice4) {
                playerTwoScore = playerTwoScore + (dice3 + dice4) * 2;
            }
            else {
                playerTwoScore = playerTwoScore + dice3 + dice4;
            }
            Console.WriteLine($"player two score: {playerTwoScore}");
        }

        string winner;
        if (playerTwoScore > playerOneScore) {
            Console.WriteLine($"player two wins with a score of {playerTwoScore}" +
                              $"\nplayer one loses with a score of {playerOneScore}");
            Statistics.SevensOut(playerTwoScore);
        }
        else if (playerOneScore > playerTwoScore) {
            Console.WriteLine($"player one wins with a score of {playerOneScore}" +
                              $"\nplayer two loses with a score of {playerTwoScore}");
            Statistics.SevensOut(playerOneScore);
        }
        else {
            Console.WriteLine($"The game was a draw \nplayer one had a score of {playerOneScore}" +
                              $"\nplayer one had a score of {playerTwoScore}");
            Statistics.SevensOut(playerOneScore);
        }
        

        

    }
}