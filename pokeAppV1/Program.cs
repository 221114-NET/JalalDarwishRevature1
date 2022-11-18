namespace pokemonApp;
class Program
{
    static void Main(string[] args)
    {
        PokeStart();
    }

    private static void PokeStart()
    {
        // create the 3 basic starter pokemon
        Pokemon pokemon1 = new Pokemon("Squirtle", 44, 48, 65, 43, 1);
        Pokemon pokemon2 = new Pokemon("Charmander", 39, 52, 43, 65, 2);
        Pokemon pokemon3 = new Pokemon("Bulbasaur", 45, 49, 49, 45, 3);

        Pokemon[] pokemonSelectionArray = { pokemon1, pokemon2, pokemon3 };

        string? userChoice;
        string? userInput;
        int computerNumber;
        int userNumber;
        Random rnd = new Random();
        Console.WriteLine("Welcome Pokemon!");
        Console.WriteLine("Press Enter to begin or type q to quit");
        userInput = Console.ReadLine();
        pokemon1.AssignOwner();
        //Run the pokemon app untill user wants to quit
        while (userInput != "q")
        {
            Console.WriteLine("Enter 1 for Squirtle, 2 for Charmander, 3 for Bulbasour");
            Console.WriteLine("Enter your choice");
            userChoice = Console.ReadLine();
            computerNumber = rnd.Next(1, 4);

            //Validate user input
            bool success = int.TryParse(userChoice, out userNumber);
            if (!success || userNumber < 1 || userNumber > 3)
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine("Enter q to quit or anything else to play again");
                userInput = Console.ReadLine();
                continue;
            }

            Console.WriteLine("The computer chose " + pokemonSelectionArray[computerNumber - 1].Name);

            //launch the pokemone battle from the PokemonBattle Class
            PokemonBattle battle = new PokemonBattle(pokemonSelectionArray[userNumber - 1], pokemonSelectionArray[computerNumber - 1]);
            battle.RunBattle();

            Console.WriteLine("Enter q to quit or anything else to play again");
            userInput = Console.ReadLine();
        }
    }

}