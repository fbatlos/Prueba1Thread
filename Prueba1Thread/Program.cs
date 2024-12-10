class ThreadTest
{
    public  String handT;
    
 
    public void choseHand() 
    { 
        int handNumber = new Random().Next(1,4);
        switch (handNumber)
        {
            case 1:
                handT = "Piedra";
                break;
            case 2 :
                handT = "Papel";
                break;
            case 3 :
                handT = "Tijeras";
                break;
        }
    }
    
}

class Game
{
    static void Main()  
    { 
        ThreadTest tTest = new ThreadTest();

        Thread t = new Thread(tTest.choseHand);
        
        
        int winsT = 0;
        
        
        t.Start ();
        t.Join();
        
        Console.WriteLine(tTest.handT);
        
        
        
    } 
    
}