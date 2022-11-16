namespace rockPaperScissorsV1;
class Program
{
    public enum Choices:int
    {
        ROCK=1,
        PAPER,
        SCISSORS
    }
    static void Main(string[] args)
    {
        Random rng = new Random();
        string? userInput = "", exit ="";
        bool continuePlaying = true;
        int computerChoice = 0, userChoice = 0;
        Choices choices;

        // Can be used to get Enum represtation of an integer
        // Enum.TryParse(1.ToString(), out choices);

        Console.WriteLine("Welcome to Rock Paper Scissors V1.");

        while(continuePlaying)
        {
            Console.WriteLine("Please enter ROCK, PAPER, or SCISSORS");
            userInput = Console.ReadLine();

            if(Enum.TryParse(userInput, true, out choices))
            {
                userChoice = ((int)choices);
            }
            else
            {
                Console.WriteLine("Invalid Input");
                continue;
            }

            //Console.WriteLine($"You selected {choices.ToString()}");
            
            computerChoice = rng.Next(1,4);
            if(userChoice == computerChoice)
            {
                Console.WriteLine("It was a tie!");
            }
            else if( (userChoice-computerChoice)==1 || (userChoice==1 && computerChoice==3) )
            {
                Console.WriteLine("You Win!");
            }
            else
            {
                Console.WriteLine("You lose!");
            }

            Console.WriteLine("press e to exit, or any other key to continue playing");
            exit = Console.ReadLine();
            if(exit == "e")
            {
                continuePlaying = false;
            }

        }
    }
}
