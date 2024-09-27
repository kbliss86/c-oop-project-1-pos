using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop_project_1_pos
{
    public class Product
    {
        private int idNum;
        private string name;
        private string category;
        private string description;
        private double price;//Potentially change to string to ensure decimal places

        //Add setters if needed
        public int IdNum {get{ return idNum;}}
        public string Name {get{return name;}}
        public string Category {get{return category;}}
        public string Description {get{return description;}}
        public double Price {get{return price;}}
        
        public Product(int productId, string productName,string productCategory, string productDescription, double productPrice) 
        {
            idNum = productId;
            name = productName;
            category = productCategory;
            description = productDescription;
            price = productPrice;
        }

        //public void GenerateProductList();
    }
}
