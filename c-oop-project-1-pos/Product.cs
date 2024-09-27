using GeneralPurposeFunctions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop_project_1_pos
{
    public class Product
    {
        static CommonlyUsedFunctions myFuncs = new CommonlyUsedFunctions();//Connect to Commonly Used Functions

        private int idNum;
        private string name;
        private string category;
        private string description;
        private decimal price;//Potentially change to string to ensure decimal places

        //Add setters if needed
        public int IdNum {get{ return idNum;}}
        public string Name {get{return name;}}
        public string Category {get{return category;}}
        public string Description {get{return description;}}
        public decimal Price {get{return price;}}
        
        public Product(int productId, string productName,string productCategory, string productDescription, decimal productPrice) 
        {
            idNum = productId;
            name = productName;
            category = productCategory;
            description = productDescription;
            price = productPrice;
        }

        //Generate List from CSV
        static List<Product> productList = new List<Product>();//list to be filled out by GenerateProductList()
        //public void GenerateProductList();
        public static List<Product> GenerateProductList()
        {
            StreamReader productReader = new StreamReader("../../Random_Grocery_List.csv");
            string line = "";
            while ((line = productReader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var values = line.Split(',');
                productList.Add(new Product(int.Parse(values[0]), (string)values[1], (string)values[2], (string)values[3], decimal.Parse(values[4])));

                if (values.Length != 5)
                {
                    Console.WriteLine($"Invalid line: {line}");
                    continue;
                }
            }
            return productList;
        }
        //public void DisplayProductList();
        public static void DisplayProductList()
        {
            Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-10} {4,-30}", "ID", "Name", "Category", "Price", "Description");//Provides headers with spaces for table like view
            //Console.WriteLine("ID\tName\t\tCategory\tPrice\tDescription");//Display Header
            Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-10} {4,-30}", "==", "====", "========", "=====", "==========");//provide divider lines with space for table liek view
            //Console.WriteLine("==\t====\t\t========\t=====\t==========");//Display Header
            foreach (Product currentProduct in productList)
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-10:C2} {4,-30}",//provides space for column like appearance
                    currentProduct.IdNum + ".", // ID
                    currentProduct.Name,        // Name
                    currentProduct.Category,    // Category
                    currentProduct.Price,       // Price (with currency format)
                    currentProduct.Description  // Description
);
                //Console.WriteLine($"{currentProduct.IdNum}.\t{currentProduct.Name}\t\t{currentProduct.Category}\t{currentProduct.Price:C}\t{currentProduct.Description}");
            }
        }
        //public void displayCartList()
        //Display coontents of card and also calculate total item count and sub total of the price of the items
        public static void DisplayCartList(List<Product> cart)
        {
            decimal subTotal = 0;
            int itemCount = 0;
            Console.WriteLine("{0,-5} {1,-20} {2,-10}", "ID", "Name", "Price");
            Console.WriteLine("{0,-5} {1,-20} {2,-10}", "==", "====", "=====");
            foreach (Product currentProduct in cart)
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-10:C2}",
                    currentProduct.IdNum + ".",  // ID
                    currentProduct.Name,         // Name
                    currentProduct.Price         // Price (formatted as currency)
);
                //Console.WriteLine($"{currentProduct.IdNum}. {currentProduct.Name} Price: ${currentProduct.Price}");//Siplay Contents of Cart (Make this a method in Product
                subTotal += currentProduct.Price;
                itemCount++;
            }
            myFuncs.WriteSeparatorLine("Running Totals");//Display a separator line
            Console.WriteLine($"Total Items: {itemCount} Subtotal: ${subTotal}");
        }
    }
}
