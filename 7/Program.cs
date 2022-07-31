using System;

namespace _7
{
    abstract class Product
    {
        public string Type;
        public Product(string type)
        {
            Type = type;
        }
    }
    class Tableware : Product
    {
        public string product1 = "Кружка";
        public string product2 = "Тарелка";
        public Tableware(string type) : base(type)
        {
            Type = type;                        
        }
    }
    class Furniture : Product
    {
        public string product1 = "Стол";
        public string product2 = "Диван";
        public Furniture(string type) : base(type)
        {
            Type = type;
        }
    }
    abstract class Delivery
    {
        public string address;
        public string deliveryDate; 
        /*
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }
        */
        
        public Delivery (string address, string deliveryDate)
        {
            this.address = address;
            this.deliveryDate = deliveryDate;
        }
        
        public abstract void PrintDeliveryInfo();
    }

    class HomeDelivery : Delivery
    {
        public string courier;
        
        public HomeDelivery (string address, string deliveryDate) : base (address, deliveryDate)
        {
            courier = "Александр";
        }
        
        /*
        public string Courier
        {
            get { return courier; }
            set { courier = value; }
        }
        */
        public override void PrintDeliveryInfo()
        {
            Console.WriteLine("Куръер {0} привезёт ваш заказ {1}\nПо адресу {2}", courier, deliveryDate, address);
        }
    }

    class PickPointDelivery : Delivery
    {
        static readonly int storageTime = 48;
        
        public PickPointDelivery(string address, string deliveryDate) : base(address, deliveryDate) { }
        
        /*
        public static int StorageTime
        {
            get { return storageTime; }            
        }
        */
        public override void PrintDeliveryInfo()
        {
            Console.WriteLine("Ваш заказ прибудет в точку {0}\nПо адресу:{1}", deliveryDate, address );
            Console.WriteLine("Время хранения заказа {0} ч.", storageTime);
        }
    }

    class ShopDelivery : Delivery
    {
        static readonly int storageTime = 72;
        
        public ShopDelivery(string address, string deliveryDate) : base(address, deliveryDate) { }
        /*
        public static int StorageTime
        {
            get { return storageTime; }
        }
        */
        public override void PrintDeliveryInfo()
        {
            Console.WriteLine("Ваш заказ прибудет в магазин {0}\nПо адресу {1}", deliveryDate, address);
            Console.WriteLine("Время хранения заказа {0} ч.", storageTime);
        }
    }

    class Order<TDelivery, TProduct> 
        where TDelivery : Delivery
        where TProduct : Product
    {
        public TDelivery Delivery;
        public int Number;
        public TProduct Description;

        public static bool InputChek2(string num, out int corrnum)
        {
            if (int.TryParse(num, out int intnum))
            {
                if (intnum == 1 | intnum == 2)
                {
                    corrnum = intnum;
                    return false;
                }
            }
            {
                corrnum = 0;
                Console.WriteLine("Не корректный ввод, попробуйте снова");
                return true;
            }
        }
        public static bool InputChek3(string num, out int corrnum)
        {
            if (int.TryParse(num, out int intnum))
            {
                if (intnum == 1 | intnum == 2)
                {
                    corrnum = intnum;
                    return false;
                }
                else if(intnum == 3)
                {
                    corrnum = intnum;
                    return false;
                }
            }
            {
                corrnum = 0;
                Console.WriteLine("Не корректный ввод, попробуйте снова");
                return true;
            }
        }
        public void MakeOrder()
        {           
            string stringnum;
            int intnum;
            Console.WriteLine("Добро пожаловать в магазин Посуды и Мебели");
            do
            {
                Console.WriteLine("Выберите категорию: \n1 Посуда\n2 Мебель\n Введите: 1 или 2");
                stringnum = Console.ReadLine();

            } while (InputChek2(stringnum, out intnum));
           // int num;
            if (intnum == 1)
            {
                do
                {
                    Console.WriteLine("Выберите категорию: \n1 Кружка\n2 Тарелка\n Введите: 1 или 2");
                    stringnum = Console.ReadLine();

                } while (InputChek2(stringnum, out intnum));
                if (intnum == 1)
                {                    
                    Tableware product = new("Кружка");
                    do
                    {
                        Console.WriteLine("Выберите способ получения:");
                        Console.WriteLine("1 Доставка курьером \n2 Доставка в точку самовывоза" +
                            "\n3 Доставка в магазин");
                    } while (InputChek2(stringnum, out intnum));
                    if(intnum == 1)
                    {
                        Order<TDelivery, TProduct> order = new();
                        Console.WriteLine("Введите адресс доставки:");
                        order.Delivery.address = Console.ReadLine();
                        Delivery.address = Console.ReadLine();

                        Console.WriteLine("Введите желаемую дату доставки:");
                        
                        
                        
                    }
                    else if (intnum == 2)
                    {
                        Console.WriteLine("Введите адресс доставки:");

                        //Delivery.address = Console.ReadLine();
                        //Console.WriteLine("Введите желаемую дату доставки:");
                        //Delivery.DeliveryDate = Console.ReadLine();
                        //PickPointDelivery pickPointDelivery = new(Delivery.Address, Delivery.DeliveryDate);
                        //pickPointDelivery.PrintDeliveryInfo();
                    }

                }
                else 
                {
                    Tableware product = new("Тарелка"); 
                }
            }
            else if (intnum == 2)
            {

            }
            
        }

        //HomeDelivery homeDelivery = new("г. 2, ул. 3, д 5, кв 132", "15.09.2022");

    }
    class Program
    {
        
        static void Main(string[] args)
        {
            // HomeDelivery delivery = new ("Андрей", "г. 2, ул. 1, квартира 555", "23.05.2022");
            // delivery.PrintDeliveryInfo();
            //Order<HomeDelivery> order = new ();
            Order<Delivery, Tableware> order = new();
            order.MakeOrder();
        }
    }
}
