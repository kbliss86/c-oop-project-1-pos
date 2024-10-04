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
        private decimal price;

        const decimal TAX_AMOUNT = .06m;//Constant used for calculating sales tax
       
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
        
        //Uses CSV to generate a list of products available
        public static List<Product> GenerateProductList()
        {
            StreamReader productReader = new StreamReader("../../Random_Grocery_List.csv");
            string line = "";
            while ((line = productReader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var values = line.Split(',');
                productList.Add(new Product(int.Parse(values[0]), values[1], values[2], values[3], decimal.Parse(values[4])));

                if (values.Length != 5)
                {
                    myFuncs.CenterText($"Invalid line: {line}");
                    continue;
                }
            }
            productReader.Close();
            return productList;
        }
        
        //Loops through the product list and displays each item (formatted into columns)
        public static void DisplayProductList()
        {
            string header = string.Format("{0,-5} {1,-20} {2,-15} {3,-10} {4,-30}", "ID", "Name", "Category", "Price", "Description");
            myFuncs.CenterText(header);
            string line = string.Format("{0,-5} {1,-20} {2,-15} {3,-10} {4,-30}", "==", "====", "========", "=====", "==========");
            myFuncs.CenterText(line);
            foreach (Product currentProduct in productList)
            {
                string content = string.Format("{0,-5} {1,-20} {2,-15} {3,-10:C2} {4,-30}",
                    currentProduct.IdNum + ".", // ID
                    currentProduct.Name,        // Name
                    currentProduct.Category,    // Category
                    currentProduct.Price,       // Price (with currency format)
                    currentProduct.Description  // Description
                );
                myFuncs.CenterText(content);
            }
        }
        //Display coontents of card and also calculate total item count and sub total of the price of the items
        public static decimal DisplayCartList(List<Product> cart)
        {
            decimal subTotal = 0;
            int itemCount = 0;
            string header = string.Format("{0,-5} {1,-20} {2,-10}", "ID", "Name", "Price");
            myFuncs.CenterText(header);
            string line = string.Format("{0,-5} {1,-20} {2,-10}", "==", "====", "=====");

            foreach (Product currentProduct in cart)
            {
                string content = string.Format("{0,-5} {1,-20} {2,-10:C2}",
                    currentProduct.IdNum + ".",  // ID
                    currentProduct.Name,         // Name
                    currentProduct.Price         // Price (formatted as currency)
                );
                myFuncs.CenterText(content);
                subTotal += currentProduct.Price;
                itemCount++;
            }
            myFuncs.WriteSeparatorLine("Totals");//Display a separator line
            myFuncs.CenterText($"Total Items: {itemCount}");
            myFuncs.CenterText($"Subtotal: ${subTotal}");
            return subTotal;
        }
        //Display the Subtotal, Tax, and Grand Total when called
        public static (decimal taxTotal, decimal grandTotal) DisplayTotals(decimal subTotal)
        {
            decimal taxTotal = 0;
            decimal grandTotal = 0;
            const decimal TAX_AMOUNT = .06m;
            taxTotal = Math.Round(subTotal * TAX_AMOUNT, 2);
            grandTotal = taxTotal + subTotal;
            myFuncs.CenterText($"Sub total: ${subTotal}");
            myFuncs.CenterText($"Tax total: ${taxTotal}");
            myFuncs.CenterText($"Grand total: ${grandTotal}");
            return (taxTotal, grandTotal);
        }
    }
}
