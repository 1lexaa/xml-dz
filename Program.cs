using System;
using System.Xml.Serialization;


namespace XML
{
    public class Product
    {
        private String name;
        private double price;
        private byte discount;

        public Product()
        {
            name = String.Empty;
            price = 0;
            discount = 0;
        }
        public Product(string _name, double _price, byte _discount)
        {
            name = _name;
            price = _price;
            discount = _discount;
        }

        public String Name
        {
            set { this.name = value; }
            get { return this.name; }
        }
        public double Price
        {
            set { this.price = value; }
            get { return this.price; }
        }
        public byte Discount
        {
            set { this.discount = value; }
            get { return this.discount; }
        }
        public override string ToString()
        {
            return $"Name: {name}\nPrice: {price}$\nDiscont: {discount}%\n\n";
        }
    }

    class Program
    {

        static void Serialize(Product[] product)
        {
            XmlSerializer ser = new XmlSerializer(product.GetType());

            using (FileStream file = new FileStream("products.xml", FileMode.OpenOrCreate))
            {
                ser.Serialize(file, product);
            }
        }
        static void Deserialization(Product[] product)
        {
            XmlSerializer des = new XmlSerializer(product.GetType());

            using (StreamReader f = new StreamReader("products.xml"))
            {
                Product[] tmp_product = (Product[])des.Deserialize(f);

                foreach (Product item in tmp_product)
                    Console.WriteLine(item);
            }
        }


        static void Main(string[] args)
        {

            Product[] product = new Product[5];
           
            
            product[0] = new Product("Iphone", 900d, 10);
            product[1] = new Product("Macbook Pro 14'", 2000d, 5);
            product[2] = new Product("MacStudio", 4000d, 5);
            product[3] = new Product("Apple Studio", 1600d, 5);
            product[4] = new Product("AirPods", 200d, 5);
           

            Serialize(product);
            Deserialization(product);


        }
    }
}