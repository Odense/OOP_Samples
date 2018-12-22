using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGenerator
{
    class Program
    {
        static Random kubik;
        static List<Item> AllPossibleFuckingLoot;  //можно использовать как массив
        static List<Treasure> AllPossibleFuckingTreasure;
        static List<Weapons> AllPossibleFuckingWeapons;
        static Item GetRandomItem()
        {
            return AllPossibleFuckingLoot[kubik.Next(0, AllPossibleFuckingLoot.Count)];
        }
        static Weapons GetRandomWeapon()
        {
            return AllPossibleFuckingWeapons[kubik.Next(0, AllPossibleFuckingWeapons.Count)];
        }
        public static void Antoshka()
        {
            Console.WriteLine("Введите количество золота");
            int gold = int.Parse(Console.ReadLine());
            if (gold < 1)
                gold = 1;
            string a = "";
            while (a != "нет" || a != "Нет" || a != "ytn" || a != "НЕТ" || a != "YTN" || a != "Ytn" && a == "да" || a == "Да" || a == "ДА" || a == "lf" || a == "Lf" || a == "LF")
            {
                Console.Clear();
                Console.WriteLine("Золото:{0}", gold);
                Console.Write("Какой сундук вы хотите открыть?");
                Console.WriteLine("Большой сундук: 1 стоимость:100, средний сундук: 2 стоимость: 50, маленький сундук: 3 стоимость: 25, сундук оружия: 4 стоимость:125");

                Treasure sunduk = new Treasure();

                int x = int.Parse(Console.ReadLine());
                if (x > 4)
                    x = 4;

                if (x < 1)
                    x = 1;
                switch (x)
                {
                    case 1:
                        sunduk = new Treasure("Вы выиграли Большой сундук!,В нем лежит 10 предметов,big,10");
                        gold -= 100;
                        break;
                    case 2:
                        sunduk = new Treasure("Вы выиграли средний сундук!,В нем лежит 5 предметов,normal,5");
                        gold -= 50;
                        break;
                    case 3:
                        sunduk = new Treasure("Вы выиграли маленький сундук!,В нем лежит 3 предмета,small,3");
                        gold -= 25;
                        break;
                    case 4:
                        sunduk = new Treasure("Вы выиграли сундук оружия!,В нем лежит 5 чертежей,weapons,5");
                        gold -= 125;
                        break;
                }
                Console.Clear();
                Console.WriteLine("Золото:{0}", gold);
                Console.WriteLine(sunduk.Gift);
                Console.Write(sunduk.Gift1);
                Console.WriteLine();
                if (x == 4)
                {
                    for (int j = 0; j < sunduk.N; j++)
                    {
                        Weapons NaxtItem = GetRandomWeapon();
                        NaxtItem.Wraite();
                    }
                }
                else
                {
                    for (int i = 0; i < sunduk.N; i++)
                    {
                        Item NextItem = GetRandomItem();
                        NextItem.Write();
                    }
                }
                Console.WriteLine("Хотите продолжить? да, нет");
                a = Console.ReadLine();
                if (a == "нет" || a == "Нет" || a == "НЕТ" || a == "ytn" || a == "Ytn" || a == "YTN")
                {
                    Console.Clear();
                    Console.WriteLine("хнык(((");
                    break;
                }
            }
        }
        static void Main(string[] args)
        {
            Init();
            Antoshka();
            Console.ReadKey();
        }
        static void Init()
        {
            kubik = new Random();
            AllPossibleFuckingLoot = new List<Item>();
            AllPossibleFuckingTreasure = new List<Treasure>();
            AllPossibleFuckingWeapons = new List<Weapons>();

            string lane;
            StreamReader l = new StreamReader("Weapons.txt", System.Text.Encoding.Default);

            do
            {
                lane = l.ReadLine();
                if (lane != "")
                    AllPossibleFuckingWeapons.Add(new Weapons(lane));
            }
            while (!l.EndOfStream);
            l.Close();

            String line;
            StreamReader s = new StreamReader("Items.txt", System.Text.Encoding.Default);

            do
            {
                line = s.ReadLine();
                if (line != "")
                {
                    AllPossibleFuckingLoot.Add(new Item(line));
                }
            }
            while (!s.EndOfStream);
            s.Close();

            String laine;
            StreamReader a = new StreamReader("Treasures.txt", System.Text.Encoding.Default);

            do
            {
                laine = a.ReadLine();
                if (line != "")
                {
                    AllPossibleFuckingTreasure.Add(new Treasure(laine));
                }
            } while (a.EndOfStream);
            a.Close();
        }
    }

    enum WeaponFreq { Usual, Rare, Legendary }
    enum WeaponType { Weapon }

    public struct Weapons
    {
        string Name;
        WeaponFreq Freq;
        WeaponType Type;

        public Weapons(string l)
        {
            var strings = l.Split(',');

            Name = strings[0];
            if (strings.Length < 2)
            {
                Freq = WeaponFreq.Usual;
            }
            else
                switch (strings[1])
                {
                    case "Usual":
                        Freq = WeaponFreq.Usual;
                        break;

                    case "Legendary":
                        Freq = WeaponFreq.Rare;
                        break;

                    case "Rare":
                        Freq = WeaponFreq.Rare;
                        break;
                    default:
                        Freq = WeaponFreq.Usual;
                        break;
                }

            if (strings.Length < 3)
            {
                Type = WeaponType.Weapon;
            }
            else
                switch (strings[2])
                {
                    case "Armor":
                        Type = WeaponType.Weapon;
                        break;
                    default:
                        Type = WeaponType.Weapon;
                        break;
                }
        }

        public void Wraite()
        {
            switch (Freq)
            {
                case WeaponFreq.Legendary:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;

                case WeaponFreq.Rare:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            switch (Type)
            {
                case WeaponType.Weapon:
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
            }
            Console.Write(Name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine();
        }
    }
    enum ItemFreq { Usual, Rare, Legendary }
    enum ItemType { Weapon, Potion, Armor, Card, Pet, Wings, Gold }

    public struct Item
    {
        string Name;
        ItemFreq Freq;
        ItemType Type;

        public Item(string s)
        {
            var strings = s.Split(',');

            Name = strings[0];
            if (strings.Length < 2)
            {
                Freq = ItemFreq.Usual;
            }
            else
                switch (strings[1])
                {
                    case "Usual":
                        Freq = ItemFreq.Usual;
                        break;

                    case "Legendary":
                        Freq = ItemFreq.Rare;
                        break;

                    case "Rare":
                        Freq = ItemFreq.Rare;
                        break;
                    //TODO: breakpoint;
                    default:
                        Freq = ItemFreq.Usual;
                        break;
                }
            if (strings.Length < 3)
            {
                Type = ItemType.Weapon;
            }
            else
                switch (strings[2])
                {
                    case "Gold":
                        Type = ItemType.Gold;
                        break;

                    case "Armor":
                        Type = ItemType.Armor;
                        break;

                    case "Weapon":
                        Type = ItemType.Weapon;
                        break;

                    case "Potion":
                        Type = ItemType.Potion;
                        break;

                    case "Card":
                        Type = ItemType.Card;
                        break;

                    case "Pet":
                        Type = ItemType.Pet;
                        break;

                    case "Wings":
                        Type = ItemType.Wings;
                        break;

                    default:
                        Type = ItemType.Armor;
                        break;
                }
        }

        public void Write()
        {
            switch (Freq)
            {
                case ItemFreq.Legendary:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;

                case ItemFreq.Rare:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            switch (Type)
            {
                case ItemType.Weapon:
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    break;

                case ItemType.Potion:
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;

                case ItemType.Wings:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;

                case ItemType.Pet:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;

                case ItemType.Card:
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    break;

                case ItemType.Armor:
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;

                case ItemType.Gold:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;

                default:
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
            }
            Console.Write(Name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine();
        }
    }

    enum TreasureFreq { small, normal, big, weapons }

    public struct Treasure
    {
        public string Gift1;
        public string Gift;
        public int N;
        TreasureFreq Coolesty;

        public Treasure(string a)
        {
            var str = a.Split(',');

            Gift1 = str[1];

            Gift = str[0];

            N = int.Parse(str[3]);

            if (str.Length < 2)
            {
                Coolesty = TreasureFreq.small;
            }
            else
            {
                Coolesty = TreasureFreq.normal;
            }

            switch (str[1])
            {
                case "small":
                    Coolesty = TreasureFreq.small;
                    break;

                case "normal":
                    Coolesty = TreasureFreq.normal;
                    break;

                case "big":
                    Coolesty = TreasureFreq.big;
                    break;

                case "weapons":
                    Coolesty = TreasureFreq.weapons;
                    break;

                default:
                    Coolesty = TreasureFreq.small;
                    break;
            }
        }
    }
}
