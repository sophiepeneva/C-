# C-

using System;

namespace SimonaHW
{
    struct Customer
    {
        public char typeOfMural;
        public string name;
    }

    class Program {
    
    static int GetPrice(int exterior,int interior, int month)
        {
            int extCost = 750;
            int intCost = 500;
            if (month == 4 || month == 5 || month == 9 || month == 10)
            {
                extCost = 699;
            }
            if (month == 7 || month == 8)
            {
                intCost = 450;
            }
            Console.WriteLine($"Interior prices for this month: {intCost}\nExterior prices for this month: {extCost}");
            int price = extCost * exterior + interior * intCost;
            return price;
        }

    static int GetMurals(bool intOrExt)
        {
            if (intOrExt == false) Console.WriteLine("Exterior:");
            else  Console.WriteLine("Interior:");
            int scheduledMurals = int.Parse(Console.ReadLine());
            return scheduledMurals;
        }

    static int GetMonth(int exteriorMurals, int interiorMurals)
    {
            Console.WriteLine("What months is it? ");
            int answer = int.Parse(Console.ReadLine());

            while (answer < 1 || answer > 12)
        {
            Console.WriteLine("Invalid Input. Try again.");
            answer = int.Parse(Console.ReadLine());
        }
        if (answer < 3 || answer == 12)
        {
            Console.WriteLine("Exterior murals cannot be scheduled between the months of December and February. Sorry!");
            exteriorMurals = 0;
        }
        
            return answer;
    }
        static void fillCustomersArray(Customer[] customers,bool intOrExt, int begin, int end)
        {
            int counter = begin;
            while (end - begin > 0)
            {
                if (intOrExt == true) Console.WriteLine("Enter customer names for all interior murals");
                else Console.WriteLine("Enter customer names for all exterior murals");
                customers[counter].name = Console.ReadLine();
                Console.WriteLine("Enter code for mural style");
                Console.WriteLine("L for landscape\nS for seascape\nA for abstract\nC for children's\nO for other.");

                customers[counter].typeOfMural = char.Parse(Console.ReadLine());
                while (customers[counter].typeOfMural != 'L' && customers[counter].typeOfMural != 'S' && customers[counter].typeOfMural != 'A' && customers[counter].typeOfMural != 'C' && customers[counter].typeOfMural != 'O')
                {
                    Console.WriteLine("Invalid input. Try again:");
                    customers[counter].typeOfMural = char.Parse(Console.ReadLine());
                }
                end--;
                counter++;
            }

        }

        static void codePrompt(int counter, Customer[] customers, int interiorMurals)
        {
            char code = char.Parse(Console.ReadLine());
            while (code != '.')
            {
                while (code != 'L' && code != 'S' && code != 'A' && code != 'C' && code != 'O' && code != '.')
                {
                    Console.WriteLine("Invalid input. Try again:");
                    code = char.Parse(Console.ReadLine());
                }
                int typeCount = 0;
                for (int i = 0; i < counter; i++)
                {
                    if (customers[i].typeOfMural == code)
                    {
                        typeCount++;
                        if (i < interiorMurals)
                            Console.WriteLine($"{customers[i].name}: interior");
                        else Console.WriteLine($"{customers[i].name}: exterior");
                    }
                }
                if (typeCount == 0) Console.WriteLine("There are no customers scheduled for this mural type");
                code = char.Parse(Console.ReadLine());
            }
        }

        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Make your vision your view.\nEnter the desired amount of exterior and interior murals for next month:\n");
            int exteriorMurals, interiorMurals;
            exteriorMurals = GetMurals(false);
            interiorMurals = GetMurals(true);
            while (exteriorMurals + interiorMurals > 30)
            {
                Console.Write("Too many murals. Try аgain:\n");
                Console.Write("Exterior Murals: ");
                exteriorMurals = int.Parse(Console.ReadLine());
                Console.Write("Interior Murals: ");
                interiorMurals = int.Parse(Console.ReadLine());
            }
            Console.Write($"{exteriorMurals} ext and {interiorMurals} interior.\n");
            //if there are more int than ext
            if (interiorMurals > exteriorMurals) Console.WriteLine("Interior murals are scheduled more than exterior.");
            else Console.WriteLine("Interior murals aren't scheduled more than exterior ones.");
            // month 
            int answer = GetMonth(exteriorMurals, interiorMurals);
            //price
            int totalCost = GetPrice(interiorMurals, exteriorMurals, answer);
            Console.WriteLine($"The total costs add up to {totalCost}");
            int totalM = exteriorMurals + interiorMurals;
            Customer[] customers = new Customer[totalM];
            if(interiorMurals>0)
            fillCustomersArray(customers, true, 0, interiorMurals);
            if(exteriorMurals>0)
            fillCustomersArray(customers, false, interiorMurals, totalM);
            Console.WriteLine($"{customers[0].name}");
            int counter = interiorMurals + exteriorMurals;
            int[] muralTypes = new int[5] {0,0,0,0,0 };
            for(int i = 0; i < counter; i++)
            {
                if (customers[i].typeOfMural == 'L') muralTypes[0]++;
                if (customers[i].typeOfMural == 'S') muralTypes[1]++;
                if (customers[i].typeOfMural == 'A') muralTypes[2]++;
                if (customers[i].typeOfMural == 'C') muralTypes[3]++;
                if (customers[i].typeOfMural == 'O') muralTypes[4]++;
            }  
                Console.WriteLine($"Landscape : {muralTypes[0]}");
                Console.WriteLine($"Seascape : {muralTypes[1]}");
                Console.WriteLine($"Abstract : {muralTypes[2]}");
                Console.WriteLine($"Children's : {muralTypes[3]}");
                Console.WriteLine($"Other : {muralTypes[4]}");
            Console.WriteLine("Please enter code for mural styles. When done enter '.'");
            codePrompt(counter, customers, interiorMurals);
            }
        }
    }
