namespace OOPAss2;
using System;

public class Die {

    public int Value { get; private set; }
    public int Roll(){
        
        Random rnd = new Random();
        int result = rnd.Next(1,7);
        Value = result;
        return result;
    }
}