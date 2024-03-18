using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    public class Pet
    {
        private string name = "No name";
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
        
        private void DecreaseHealth()
        {
            if (health > 0)
            {  
                if (health < 7)
                {
                    DecreaseHappy();
                }
                health--; 
            }
            else { PetIsSick(); }
        }
        private void IncreaseHealth()
        {
            if (health < 10)
            { health++; }
        }
        private void DecreaseHappy()
        { 
            if (happy > 0) { happy--; }
            else
            {
                Console.WriteLine("Your pet is totally unhappy!");
            }
        }
        private void IncreaseHappy()
        {
            if (happy < 10) { happy++; }
        }
        private void DecreaseHungry()
        {
            if (hungry > 0)
            {
                hungry--;
                IncreaseHappy();
                if (hungry < 5)
                {
                    IncreaseHealth();
                }
            }
            else
            {
                DecreaseHealth();
                DecreaseHappy();
            }
        }
        private void IncreaseHungry()
        {
            if (hungry < 10)
            {
                hungry++;
            }
            else
            {
                Console.WriteLine("Your pet very want eat!");
                DecreaseHealth();
            }
        }
        private void DecreaseTired()
        {
            if (tired > 5)
            {
                tired = 0;
            }
            else
            {
                Console.WriteLine("Your pet no want to sleep!");

            }
        }
        private void IncreaseTired()
        {
            if (tired < 10)
            {
                tired++;
            }
            else
            {
                Console.WriteLine("Your pet want to sleep!");
                DecreaseHappy();
            }
        }
        private void PetIsSick()
        {
            Console.WriteLine("Your pet is dead!!!!");
            isLiving = false;
        }
        public void FeedThePet()
        {
            DecreaseHungry();
            Console.WriteLine("You successfully fed your pet!");
        }
        public void PlayWithPet()
        {
            IncreaseTired();
            IncreaseHungry();
            IncreaseHappy();
        }
        public void RockThePetToSleep() 
        {
            tired = 0;
            DecreaseHappy();
            IncreaseHungry();
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
