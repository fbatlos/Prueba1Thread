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
        ThreadTest tTest2 = new ThreadTest();

        Thread t = new Thread(tTest.choseHand);
        Thread t2 = new Thread(tTest2.choseHand);
        
        
        int winsT = 0;
        int winsT2 = 0;
        
        
        t.Start ();
        t.Join();
        t2.Start ();
        t2.Join();
        Console.WriteLine(tTest.handT);
        Console.WriteLine(tTest2.handT);
        
        var winner = checkWinner(tTest.handT, tTest2.handT);
        
        Console.WriteLine(winner);
    }

    static int checkWinner(String handt,String handt2)
    {
        if (handt == handt2)
        {
            return 0;
        }

        switch (handt)
        {
            case "Piedra":
                if (handt2 == "Papel")
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            case "Tijeras":
                if (handt2 == "Piedra")
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            
            case "Papel":
                if (handt2 == "Tijeras")
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            default:
                return 0;
        }
        
    }
    
}