namespace pokemonApp;

using System.Text.RegularExpressions;
class Pokemon : IPokemaster
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
    public string? Owner {get; set;}

    //methods
    public void AssignOwner()
    {
        bool validInput = true;
        while(validInput)
        {
            Console.WriteLine("Please enter your name (1-6 letters):");
            Owner = Console.ReadLine();
            //Make sure Owner is not null
            if(String.IsNullOrEmpty(Owner))
            {
                Owner = " ";
            }
            //Get any 4 characters
            Regex rx = new Regex("^[a-zA-Z]{1,6}$");
            //If input is valid, set validInput to false to break out of loop
            validInput = !rx.IsMatch(Owner);
        }
        //Testing rx validation
        Console.WriteLine(Owner);
    }
}