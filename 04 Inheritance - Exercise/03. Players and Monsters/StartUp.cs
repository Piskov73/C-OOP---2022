using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var hero =new Hero("Games",1);
            Console.WriteLine(hero);
            var elf = new Elf("Snega", 23);
            Console.WriteLine(elf);
            var museElf = new MuseElf("Lusi", 43);
                Console.WriteLine(museElf);
            var wizard = new Wizard("Albena", 44);
            Console.WriteLine(wizard);
            var darkWizard = new DarkWizard("Mario", 43);
            Console.WriteLine(darkWizard);
            var soulMaster = new SoulMaster("Ivan4o", 32);
            Console.WriteLine(soulMaster);
            var knight = new Knight("Stamat", 55);
            Console.WriteLine(knight);
            var darkKnight = new DarkKnight("Petrun4o", 19);
            Console.WriteLine(darkKnight);
            var bladeKnight = new BladeKnight("Boris4o", 44);
            Console.WriteLine(bladeKnight);
        }
    }
}
