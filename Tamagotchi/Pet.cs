namespace Tamagotchi
{
    internal class Pet
    {
        private readonly string name = "No name";
        private uint health = 10;
        private uint hungry = 0;
        private uint tired = 0;
        private uint happy = 10;
        private bool isLiving = true;
        public Pet() 
        {

        }
        public Pet(string nameOfPet) 
        {
            name = nameOfPet;
        }
        public string Name  { get { return name; } }
        public uint Health  { 
            get { return health; } 
            private set 
            { 
                if (value >= 0 && value < 11)
                { 
                    if(value > 0)
                    {
                        health = value; 
                    }
                    else
                    {
                        PetIsSick();
                    }
                }
                else
                {
                    throw new Exception("Bad argument in set");
                }
            }
        }
        public uint Hungry  { 
            get { return hungry; }
            private set
            {
                if (value > 0 && value < 11)
                {
                    hungry = value;
                }
                else
                {
                    throw new Exception("Bad argument in set");
                }
            }
        }
        public uint Tired   { 
            get { return tired; }
            private set
            {
                if (value > 0 && value < 11)
                {
                    tired = value;
                }
                else
                {
                    throw new Exception("Bad argument in set");
                }
            }
        }
        public uint Happy 
        {
            get {  return happy; }
            private set
            {
                if (value > 0 && value < 11)
                {
                    tired = value;
                }
                else
                {
                    throw new Exception("Bad argument in set");
                }
            }
        }
        public bool IsLiving { get { return isLiving; } }
        
        private string DecreaseHealth()
        {
            string mes = "";
            if (health > 1)
            {  
                if (health < 8)
                {
                    mes+=DecreaseHappy();
                }
                health--; 
            }
            else { mes += PetIsSick(); }
            return mes;
        }
        private void IncreaseHealth()
        {
            if (health < 10)
            { health++; }
        }
        private string DecreaseHappy()
        { 
            if (happy > 0) { happy--; }
            else
            {
                return "Your pet is totally unhappy!\n";
            }
            return "";
        }
        private void IncreaseHappy()
        {
            if (happy < 10) { happy++; }
        }
        private string DecreaseHungry()
        {
            string mes = "";
            if (hungry > 0)
            {
                hungry--;
                if (hungry < 5)
                {
                    IncreaseHealth();
                }
                if (hungry > 6)
                {
                    IncreaseHappy();
                }
            }
            else
            {
                mes += DecreaseHealth();
                mes += "Your pet is overeating!\n";

            }
            return mes;
        }
        private string IncreaseHungry()
        {
            string mes = "";
            if (hungry < 10)
            {
                hungry++;
            }
            else
            {
                mes += "Your pet very want eat!\n";
                mes += DecreaseHealth();
            }
            return mes;
        }
        private string IncreaseTired()
        {
            string mes = "";
            if (tired < 10)
            {
                tired++;
            }
            else
            {
                mes += "Your pet want to sleep!\n";
                mes += DecreaseHappy();
            }
            return mes;
        }
        private string PetIsSick()
        {
            isLiving = false;
            return "Your pet is sick!!!!\n";
        }
        public string FeedThePet()
        {
           string mes = DecreaseHungry();
           return mes+"You successfully fed your pet!\n";
        }
        public string PlayWithPet()
        {
            string mes = "";
            mes += IncreaseTired();
            mes += IncreaseHungry();
            IncreaseHappy();
            return mes + "You successfully play with pet!\n";
        }
        public string RockThePetToSleep() 
        {
            string mes = "";
            tired = 0;
            mes += DecreaseHappy();
            mes += IncreaseHungry();
            return mes;
        }
        public string Status()
        {
            string res = "";
            res += "Health:      " + health + "\n";
            res += "Happy level: " + happy + "\n";
            res += "Tired level: " + tired + "\n";
            res += "Hungry level:" + hungry + "\n";
            res += "He is living:" + isLiving + "\n";
            return res;
        }
        public override string ToString()
        {
            return Status();
        }
    }
}
