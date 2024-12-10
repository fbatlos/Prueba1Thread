class ThreadTest 
{ 
    static void Main()  
    { 
        Thread t = new Thread (new ThreadStart (choseHand));
        Thread t2 = new Thread (new ThreadStart (choseHand));
 
        t.Start();
        t2.Start();
       
    } 
 
    static void choseHand() 
    { 
        int handNumber = new Random().Next(1,4);
        String hand = null;
        switch (handNumber)
        {
            case 1:
                hand = "Piedra";
                break;
            case 2 :
                hand = "Papel";
                break;
            case 3 :
                hand = "Tigeras";
                break;
        }
        
        Console.WriteLine(hand);
    } 
}