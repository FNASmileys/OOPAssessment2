using System.Diagnostics;

namespace OOPAss2;

public class Testing {
    public static Die[] sevensDie = new Die[2];
    public static int tomSeccondTolast = 0;
    public static int tomLast = 0;
    public void test() {
        SevensOut sevensOut = new SevensOut();
        sevensOut.play();
        Debug.Assert(sevensDie[0].Value + sevensDie[1].Value == 7, "the die didn't add up to seven");
        ThreeOrMore threeOrMore = new ThreeOrMore();
        Console.WriteLine("test passed");
        threeOrMore.play();
        Debug.Assert(tomLast >= 20 && tomSeccondTolast < 20, "the last score wasn't 20 or higher" );
        Console.WriteLine("test passed");
    }
}