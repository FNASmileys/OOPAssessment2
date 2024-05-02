// See https://aka.ms/new-console-template for more information

using OOPAss2;

public static class Program {
    public static void Main() {
        Statistics.Load();
        bool running = true;
        while (running) {
            Console.WriteLine("menu\n \nwould you like to:\n(1) play Sevens Out\n(2) play Three Or More\n(3) get statistics\n(4) run testing\n(5) see game rules\n(6) close program");
            string choice = Console.ReadLine();
            if (choice == "1") {
                Console.WriteLine("playing Three Or More...");
                SevensOut sevensOut = new SevensOut();
                sevensOut.play();
            }
            else if (choice == "2"){
                Console.WriteLine("playing Three Or More...");
                ThreeOrMore threeOrMore = new ThreeOrMore();
                threeOrMore.play();
            }
            else if (choice == "3"){
                Statistics.GetHighScores();
            }
            else if (choice == "4"){
            
            }
            else if (choice == "5"){
            
            }
            else {
                running = false;
            }
        }
        Statistics.Save();
    }
}