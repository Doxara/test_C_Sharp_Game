namespace Tamagotchi
{
    public class Game(string name)
    {
        private readonly Pet Pet = new(name);
        private string message = "";
        private readonly int sizeString = 50;
        private static string GetWordWithPad(string text, int sizeString = 50, char padSymb = '*')
        {
            int maxSize = sizeString;
            int textLength = text.Length;
            int leftPad = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((maxSize - textLength) / 2))) + textLength;
            return(new string(text).PadLeft(leftPad, '*').PadRight(maxSize, padSymb));
        }
        private static string GetCells(uint numOfFilledCells = 0)
        {
            if (numOfFilledCells > 10) return "";
            string resultString = "|";
            for (int i = 0; i < numOfFilledCells; i++) 
            {
                resultString += "*|";
            }
            for (int i = 0; i < 10 - numOfFilledCells; i++)
            {
                resultString += " |";
            }
            return resultString;
        }
        private void PrintInfo()
        {
            Console.WriteLine(GetWordWithPad(""));
            Console.WriteLine(GetWordWithPad("Your pet name:"));
            Console.WriteLine(GetWordWithPad(Pet.Name));
            Console.WriteLine(GetWordWithPad(""));
            Console.WriteLine(GetWordWithPad("Stats:"));
            Console.WriteLine(("*Health:  "+ GetCells(Pet.Health)).PadRight(sizeString, '*'));
            Console.WriteLine(("*Hungry:  " + GetCells(Pet.Hungry)).PadRight(sizeString, '*'));
            Console.WriteLine(("*Fatigue: " + GetCells(Pet.Tired)).PadRight(sizeString, '*'));
            Console.WriteLine(("*Happy:   " + GetCells(Pet.Happy)).PadRight(sizeString, '*'));
            if (message != null && message != "")
            { 
                Console.WriteLine(message); 
            }

        }
        public void StartGame()
        {
            uint res = 0;
            while (Pet.IsLiving)
            {
                Console.Clear();
                PrintInfo();
                Console.WriteLine("\nSelect action:\n1 Feed the pet\n2 Play with pet\n3 Rock pet to sleep");
                string command = Console.ReadLine() ?? "";
                if (command != null)
                {
                    try
                    {
                        res = uint.Parse(command);
                    }
                    catch
                    {
                    }
                    if (res > 0 && res < 4)
                    {
                        switch (res)
                        {
                            case 1:
                                message = Pet.FeedThePet();
                                break;
                            case 2:
                                message = Pet.PlayWithPet();
                                break;
                            case 3:
                                message = Pet.RockThePetToSleep();
                                break;
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine("Your pet is sick. Game over!");
            }
        }
    }
}
