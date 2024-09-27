using GeneralPurposeFunctions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop_project_1_pos
{
    internal class Program
    {
        static CommonlyUsedFunctions myFuncs = new CommonlyUsedFunctions();
        static List<Product> productList = new List<Product>();//list to be filled out by GenerateProductList()
        static List<Product> cart = new List<Product> ();//List to generate as user adds items to card
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the point of sale terminal");
            GenerateProductList();//Product.GenerateProductList

            //prompt user to pick an item(by number) on a loop
            //while loop
            do
            {
                //while loop for displaying menu - ask user if they want to see the menu again after selecting they want to add more items
                DisplayProductList();//ADjust once method is moved
                Console.WriteLine("Please Select an Item # to add to your cart: ");
                int item = myFuncs.GetANumber();
                Console.WriteLine("How many do you want to add to your cart?");
                int quantity = myFuncs.GetANumber();
                for (int i = 0; i < quantity; i++)
                {
                    cart.Add(productList[item - 1]);
                }
                myFuncs.WriteSeparatorLine("Shopping Cart");
                foreach (Product currentProduct in cart)
                {
                    Console.WriteLine($"{currentProduct.IdNum}. {currentProduct.Name} Price: ${currentProduct.Price}");
                }
            }
            while (myFuncs.moreInput());

            myFuncs.WriteSeparatorLine("Payment Section");
            //prompt user to select payment type - use a switch statment and run different class methods with polymorphism

            myFuncs.WriteSeparatorLine("Reciept Section");
            //Display Reciept - use a switch statement to display different reciepts based on payment type chosen using polymorphism

        }
        //Move the methods to Product Class
        //Change to generate from csv file -- maybe move to product class to keep main clean

        static void GenerateProductList()
        {
            StreamReader productReader = new StreamReader("../../Random_Grocery_List.csv");
            string line = "";
            while ((line = productReader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var values = line.Split(',');
                productList.Add(new Product(int.Parse(values[0]), (string)values[1], (string)values[2], (string)values[3], double.Parse(values[4])));

                if (values.Length != 5)
                {
                    Console.WriteLine($"Invalid line: {line}");
                    continue;
                }               
            }           
        }
        //Potentially move to product class if necessary
        static void DisplayProductList()
        {
            foreach (Product currentProduct in productList)
            {
                Console.WriteLine($"{currentProduct.IdNum}. {currentProduct.Name} Price: ${currentProduct.Price}\nCategory: {currentProduct.Category}" +
                    $"\nDescription: {currentProduct.Description}");
            }
        }

        //Make a Display Cart List Method - Put in product as well


    }
}
