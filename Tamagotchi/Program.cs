using System.Windows.Input;
using Tamagotchi;

Pet MyPet = new Pet("Musya");
Console.WriteLine(MyPet);
uint res = 0;

while (MyPet.IsLiving)
{
    Console.Clear();
    Console.WriteLine(MyPet);
    Console.WriteLine("Select:\n1 Feed\n2 Play\n3 Rock");
    string command = Console.ReadLine();
    if (command != null)
    {
        try
        {
            res = uint.Parse(command);
        }
        catch 
        {
            Console.WriteLine("Bad input!");
        }
        if (res > 0 && res < 4)
        {
            switch (res) 
            {
                case 1:
                    MyPet.FeedThePet();
                    break;
                case 2:
                    MyPet.PlayWithPet();
                    break;
                case 3:
                    MyPet.RockThePetToSleep(); 
                    break;
            }
        }
    }
    Console.Clear() ;
    Console.WriteLine("Your pet id dead. Game over!");
}