using System.Collections.Generic;

namespace Luojia_Ziqiang_Supermarket_Goods_Information_Service_Platform
{
    public enum Gender { MALE, FEMALE };
    public class Consumer
    {
        private string ConsumerName;
        private string StudentID;
        private int Age;
        private Gender gender;
        private string Password;
        private static Consumer Singleton = null;
        private static object singletonLock = new object();//该私有对象用于lock，使之可适用于多线程
        private Consumer(string ConsumerName, string StudentID, int Age, Gender gender, string Password)
        {
            this.ConsumerName = ConsumerName;
            this.StudentID = StudentID;
            this.Age = Age;
            this.gender = gender;
            this.Password = Password;
        }

        public static Consumer getConsumerInstance()
        {
            if (Singleton == null)
            {
                lock (singletonLock)
                {
                    if (Singleton == null)
                    {
                        Singleton = new Consumer("测试", "2018300000000", 20, Gender.MALE, "Test123.");
                    }
                }
            }
            return Singleton;
        }
        public bool LogIn(string id, string password)
        {
            if (id == StudentID && password == Password)
                return true;
            else
                return false;
        }
        public string getConsumerName()
        {
            return ConsumerName;
        }
        public void setConsumerName(string name)
        {
            ConsumerName = name;
        }
        public int getAge()
        {
            return Age;
        }
        public void setAge(int age)
        {
            Age = age;
        }
        public string getPassword()
        {
            return Password;
        }
        public void setPassword(string password)
        {
            Password = password;
        }
        public string getStudentID()
        {
            return StudentID;
        }
        public Gender getGender()
        {
            return gender;
        }

        public bool SubmitOrders(Order order)
        {
            //添加数据操作，即将order送给后台管理系统
            return true;
        }
    }
    public class Product
    {
        private string ProductName;
        private string Manufacturer;
        private string ProductionDate;
        private int Price;
        public Product(string ProductName, string Manufacturer, string ProductionDate, int Price)
        {
            this.ProductName = ProductName;
            this.Manufacturer = Manufacturer;
            this.ProductionDate = ProductionDate;
            this.Price = Price;
        }
        public string getProductName()
        {
            return ProductName;
        }
        public string getManufacturer()
        {
            return Manufacturer;
        }
        public string getProductDate()
        {
            return ProductionDate;
        }

        public int getPrice()
        {
            return Price;
        }
    }
    public class Order
    {
        private string OrderID;
        private Consumer consumer;
        private List<Product> Commodity;
        private string ConsumptionTime;
        public Order(string OrderID, Consumer consumer, List<Product> Commodity, string ConsumptionTime)
        {
            this.OrderID = OrderID;
            this.consumer = consumer;
            this.Commodity = Commodity;
            this.ConsumptionTime = ConsumptionTime;
        }
        public void AddingGoods(Product product)
        {
            Commodity.Add(product);
        }
        public bool DeleteGoods(Product product)
        {
            if (!Commodity.Contains(product))
                return false;
            else
            {
                Commodity.Remove(product);
                return true;
            }
        }
    }
}
