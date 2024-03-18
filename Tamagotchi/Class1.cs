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

        public Pet() 
        {

        }
        public Pet(string nameOfPet) 
        {
            name = nameOfPet;
        }
        public string Name  { get { return name; } }
        public uint Health  { get { return health; } }
        public uint Hungry  { get { return hungry; } }
        public uint Tired   { get { return tired; } }
        public void FeedThePet()
        {
            hungry--;
        }
        public void PlayWithPet()
        {
            tired++;
            hungry--;
        }
        public void RockThePetToSleep() 
        {
            tired = 0;
        }
    }
}
