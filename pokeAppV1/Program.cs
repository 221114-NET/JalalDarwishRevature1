namespace pokemonApp;
class Program
{
    static void Main(string[] args)
    {
        PokeStart();
    }

#region Pokemon Startup
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
#endregion

#region Pokemon Class
    // create a pokemon class
    class Pokemon
    {
    public enum Choices:int
    {
        WATER = 1,
        FIRE,
        GRASS
    }
        // create a constructor
        public Pokemon(string name, int health, int attack, int defense, int speed, int type)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Defense = defense;
            Speed = speed;
            Type = (Choices)type;

        }
        // create properties
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public Choices Type {get; set;}
    }
#endregion

#region Pokemon Battle Class
    //create a pokemon battle class
    class PokemonBattle
    {
        // create a constructor
        public PokemonBattle(Pokemon pokemon1, Pokemon pokemon2)
        {
            Pokemon1 = pokemon1;
            Pokemon2 = pokemon2;
        }
        // create properties
        public Pokemon Pokemon1 { get; set; }
        public Pokemon Pokemon2 { get; set; }
        // create a method that will run the battle
        public void RunBattle()
        {
                // create a variable to hold the pokemon that attacks first
                Pokemon firstAttacker;
                Pokemon secondAttacker;
            // create a loop that will run until one pokemon faints
            while (Pokemon1.Health > 0 && Pokemon2.Health > 0)
            {

                // check to see which pokemon has the higher speed
                if (Pokemon1.Speed > Pokemon2.Speed)
                {
                    firstAttacker = Pokemon1;
                    secondAttacker = Pokemon2;
                }
                else
                {
                    firstAttacker = Pokemon2;
                    secondAttacker = Pokemon1;
                }
                // have the first attacker attack the second attacker
                Console.WriteLine($"{firstAttacker.Name} attacks {secondAttacker.Name}");
                // calculate the damage
                int damage = firstAttacker.Attack - secondAttacker.Defense;

                //if pokemone has type advantage double the damage
                if (firstAttacker.Type == secondAttacker.Type)
                {
                }
                else if ((int)firstAttacker.Type == 1 && (int)secondAttacker.Type == 2 || (int)firstAttacker.Type == 2 && (int)secondAttacker.Type == 3 || (int)firstAttacker.Type == 3 && (int)secondAttacker.Type == 1)
                {
                    damage *= 2;
                }
                else
                {
                    damage = Math.Max(damage / 2, 1);
                }

                // check to see if the damage is greater than 0
                if (damage > 0)
                {
                    // subtract the damage from the second attackers health
                    secondAttacker.Health -= damage;
                    // display the damage done
                    Console.WriteLine($"{secondAttacker.Name} took {damage} damage");
                }
                else
                {
                    // display that the attack was ineffective
                    Console.WriteLine($"{secondAttacker.Name} took no damage");
                }
                // check to see if the second attacker has fainted
                if (secondAttacker.Health > 0)
                {
                    // have the second attacker attack the first attacker
                    Console.WriteLine($"{secondAttacker.Name} attacks {firstAttacker.Name}");
                    // calculate the damage
                    damage = secondAttacker.Attack - firstAttacker.Defense;
                    //if pokemone has type advantage double the damage
                    if (secondAttacker.Type == firstAttacker.Type)
                    {
                    }
                    else if ((int)secondAttacker.Type == 1 && (int)firstAttacker.Type == 2 || (int)secondAttacker.Type == 2 && (int)firstAttacker.Type == 3 || (int)secondAttacker.Type == 3 && (int)firstAttacker.Type == 1)
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage = Math.Max(damage / 2, 1);
                    }

                    // check to see if the damage is greater than 0
                    if (damage > 0)
                    {
                        // subtract the damage from the first attackers health
                        firstAttacker.Health -= damage;
                        // display the damage done
                        Console.WriteLine($"{firstAttacker.Name} took {damage} damage");
                    }
                }
                     System.Console.WriteLine($"\nPress enter to continue battle.\n" +
                      $"{firstAttacker.Name}'s current health is {firstAttacker.Health}.\n" +
                      $"{secondAttacker.Name}'s current health is {secondAttacker.Health}.");
                     Console.ReadLine();

            }
            if(Pokemon1.Health <= 0)
            {
                System.Console.WriteLine(Pokemon1.Name + " Has Fainted");
            }
            else
            {
                System.Console.WriteLine(Pokemon2.Name + " Has Fainted");
            }
        }
    }
#endregion
}