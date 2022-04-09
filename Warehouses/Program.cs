using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"E:\C# Code\Warehouses\Warehouses\Inventory.txt";

            //File existance checking
            if (!(File.Exists(filePath)))
            {
                Console.WriteLine("Inventory file not found, try changing filePath");
                Console.ReadLine();
                return;
            }

            //declaring variables needed
            StreamReader sr = new StreamReader(filePath);
            Warehouse[] warehouses = new Warehouse[6];
            int counter = 0;
            string line;

            //while loop that reads Inventory.txt and creates a list of Warehouse objects
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
   
                warehouses[counter] = new Warehouse(Convert.ToInt32(parts[0]),
                    Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), Convert.ToInt32(parts[3]), Convert.ToInt32(parts[4]));


                counter++;
            }

            sr.Close();

            //creating named variables for each warehouse
            Warehouse Atlanta = warehouses[0];
            Warehouse Baltimore = warehouses[1];
            Warehouse Chicago = warehouses[2];
            Warehouse Denver = warehouses[3];
            Warehouse Ely = warehouses[4];
            Warehouse Fargo = warehouses[5];

            Console.WriteLine("Key: Part102, Part215, Part410, Part525, Part711");
            Console.WriteLine("\n\nStart of the day inventories:");
            Console.WriteLine("Atlanta's Inventory: " + Atlanta + 
                "\nBaltimore's Inventory: " + Baltimore + 
                "\nChicago's Inventory: " + Chicago + 
                "\nDenver's Inventory: " + Denver + 
                "\nEly's Inventory: " + Ely + 
                "\nFargo's Inventory: " + Fargo);

            //declaring needed variables for reading Transactions.txt and processing results
            filePath = @"E:\C# Code\Warehouses\Warehouses\Transactions.txt";
            sr = new StreamReader(filePath);
            //lowestQuant is the variable to hold the lowest value for each item in the warehouse list
            //highestQuant is the variable to hold the highest value for each item in the warehouse list
            //holder holds the position of the warehouse with the lowest/highest item so it can be used later
            int lowestQuant = 1000000;
            int highestQuant = 0;
            int holder = 0;

            //while loop that reads Transactions.txt line by line
            //Only the first switch case of each if statment is explained through comments, the rest work the exact same
            while ((line = sr.ReadLine()) != null)
            {
                string[] transaction = line.Split(',');
                //resetting variables with each while loop
                holder = 0;
                lowestQuant = 1000000;
                highestQuant = 0;

                //if statement that decides if the item was a purchase or a sale
                if (transaction[0].Equals("P"))
                {
                    //switch case that takes the item number from Transactions.txt and decides executes the adding of the item to the warehouse values
                    switch (Convert.ToInt32(transaction[1]))
                    {
                        case 102:
                            //iterates through each warehouse in the warehouse list and compares the current iteration's part102 value to the current lowest part102 value
                            for(int i = 0; i < warehouses.Length; i++)
                            {
                                //if the current part102 value is lower saves its value as the lowest and holds its position in the list for use later
                                if (warehouses[i].GetPart102() < lowestQuant)
                                {
                                    lowestQuant = warehouses[i].GetPart102();
                                    holder = i;
                                }
                            }

                            //takes the held warehouse with the lowest amount of part102 and adds the purchased items to its values
                            warehouses[holder].SetPart102(warehouses[holder].GetPart102() + Convert.ToInt32(transaction[2]));

                            break;

                        case 215:
                            for (int i = 0; i < warehouses.Length; i++)
                            {
                                if (warehouses[i].GetPart215() < lowestQuant)
                                {
                                    lowestQuant = warehouses[i].GetPart215();
                                    holder = i;
                                }
                            }

                            warehouses[holder].SetPart215(warehouses[holder].GetPart215() + Convert.ToInt32(transaction[2]));

                            break;

                        case 410:
                            for (int i = 0; i < warehouses.Length; i++)
                            {
                                if (warehouses[i].GetPart410() < lowestQuant)
                                {
                                    lowestQuant = warehouses[i].GetPart410();
                                    holder = i;
                                }
                            }

                            warehouses[holder].SetPart410(warehouses[holder].GetPart410() + Convert.ToInt32(transaction[2]));


                            break;

                        case 525:
                            for (int i = 0; i < warehouses.Length; i++)
                            {
                                if (warehouses[i].GetPart525() < lowestQuant)
                                {
                                    lowestQuant = warehouses[i].GetPart525();
                                    holder = i;
                                }
                            }

                            warehouses[holder].SetPart525(warehouses[holder].GetPart525() + Convert.ToInt32(transaction[2]));

                            break;

                        case 711:
                            for (int i = 0; i < warehouses.Length; i++)
                            {
                                if (warehouses[i].GetPart711() < lowestQuant)
                                {
                                    lowestQuant = warehouses[i].GetPart711();
                                    holder = i;
                                }
                            }

                            warehouses[holder].SetPart711(warehouses[holder].GetPart711() + Convert.ToInt32(transaction[2]));

                            break;
                    }
                }
                else
                {
                    //switch case that takes the item number from Transactions.txt and decides executes the subtracting of the item to the warehouse values
                    switch (Convert.ToInt32(transaction[1]))
                    {
                        case 102:
                            //iterates through each warehouse in the warehouse list and compares the current iteration's part102 value to the current highest part102 value
                            for (int i = 0; i < warehouses.Length; i++)
                            {
                                //if the current part102 value is higher saves its value as the highest and holds its position in the list for use later
                                if (warehouses[i].GetPart102() > highestQuant)
                                {
                                    highestQuant = warehouses[i].GetPart102();
                                    holder = i;
                                }
                            }

                            //takes the held warehouse with the lowest amount of part102 and subtracts the purchased items to its values
                            warehouses[holder].SetPart102(warehouses[holder].GetPart102() - Convert.ToInt32(transaction[2]));

                            break;

                        case 215:
                            for (int i = 0; i < warehouses.Length; i++)
                            {
                                if (warehouses[i].GetPart215() > highestQuant)
                                {
                                    highestQuant = warehouses[i].GetPart215();
                                    holder = i;
                                }
                            }

                            warehouses[holder].SetPart215(warehouses[holder].GetPart215() - Convert.ToInt32(transaction[2]));

                            break;

                        case 410:
                            for (int i = 0; i < warehouses.Length; i++)
                            {
                                if (warehouses[i].GetPart410() > highestQuant)
                                {
                                    highestQuant = warehouses[i].GetPart410();
                                    holder = i;
                                }
                            }

                            warehouses[holder].SetPart410(warehouses[holder].GetPart410() - Convert.ToInt32(transaction[2]));

                            break;

                        case 525:
                            for (int i = 0; i < warehouses.Length; i++)
                            {
                                if (warehouses[i].GetPart525() > highestQuant)
                                {
                                    highestQuant = warehouses[i].GetPart525();
                                    holder = i;
                                }
                            }

                            warehouses[holder].SetPart525(warehouses[holder].GetPart525() - Convert.ToInt32(transaction[2]));

                            break;

                        case 711:
                            for (int i = 0; i < warehouses.Length; i++)
                            {
                                if (warehouses[i].GetPart711() > highestQuant)
                                {
                                    highestQuant = warehouses[i].GetPart711();
                                    holder = i;
                                }
                            }

                            warehouses[holder].SetPart711(warehouses[holder].GetPart711() - Convert.ToInt32(transaction[2]));

                            break;
                    }
                }

            }

            Console.WriteLine("\n\nEnd of the day inventories:");
            Console.WriteLine("Atlanta's Inventory: " + Atlanta +
                "\nBaltimore's Inventory: " + Baltimore +
                "\nChicago's Inventory: " + Chicago +
                "\nDenver's Inventory: " + Denver +
                "\nEly's Inventory: " + Ely +
                "\nFargo's Inventory: " + Fargo);

            //close reader and hold console open for viewing
            sr.Close();
            Console.ReadLine();


        


        }



    }
}
