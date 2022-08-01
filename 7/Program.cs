using System;

namespace _7
{   
    /// <summary>
    /// Композиция - присвоим имя товара и должен был быть артикул
    /// </summary>
    class Description
    {       
        public string productDedcription;
        public Description(string description)
        {
            productDedcription = description;
        }                    
    }
    class Product
    {
        public string name;
        Description description;        
        public Product(string name, string description)
        {            
            this.description = new Description(description);
            this.name = name;
        }
        public void PrintProductIonInfo()
        {
            Console.WriteLine("Ваш товар : {0} ", name);
        }        
    }    
    /// <summary>
    /// Абстрактный класс доставка
    /// </summary>
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
        */
        /*
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
    /// <summary>
    /// Наследуемый класс, доставка на дом
    /// </summary>
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
    /// <summary>
    /// Наследуемый класс, доставка в точку самовывоза
    /// </summary>
    class PickPointDelivery : Delivery
    {
        static readonly int storageTime = 48;
        static readonly string pickPointAddress = "г. Забулдыгино дом 5 ТЦ Ромашка";
        public PickPointDelivery(string address, string deliveryDate) : base (address, deliveryDate)
        {
            
        }       
        public static string PickPointAddress
        {
            get
            {
                return pickPointAddress;
            }
        }
        /*
        public static int StorageTime
        {
            get { return storageTime; }            
        }
        */
        public override void PrintDeliveryInfo()
        {
            Console.WriteLine("Ваш заказ прибудет в точку {0}\nПо адресу:{1}", deliveryDate, pickPointAddress);
            Console.WriteLine("Время хранения заказа {0} ч.", storageTime);
        }
    }
    /// <summary>
    /// Наследуемый класс, доставка в магазин
    /// </summary>
    class ShopDelivery : Delivery
    {
        static readonly int storageTime = 72;
        static readonly string shopAddress = "г.Забулдыгино ул. Старого пепла дом 7 ТЦ Варяг";
        public ShopDelivery(string address, string deliveryDate) : base(address, deliveryDate) { } 
        /*
        public static int StorageTime
        {
            get { return storageTime; }
        }
        */
        public static string ShopAddress
        {
            get
            {
                return shopAddress;
            }
        }
        public override void PrintDeliveryInfo()
        {
            Console.WriteLine("Ваш заказ прибудет в магазин {0}\nПо адресу {1}", deliveryDate, address);
            Console.WriteLine("Время хранения заказа {0} ч.", storageTime);
        }
    }
    /// <summary>
    /// Класс заказ с основным методом
    /// </summary>
    /// <typeparam name="TDelivery"></typeparam>
    /// <typeparam name="TProduct"></typeparam>
    class Order<TDelivery, TProduct>  
        where TDelivery : Delivery   
        where TProduct : Product
    {        
        /// <summary>
        /// 2 метода проверки на корректность ввода
        /// </summary>
        /// <param name="num"></param>
        /// <param name="corrnum"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Метод с основной логикой заказа
        /// </summary>
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
                {   //поидеи можно было реализовать счётчик заказов и выдавать номер склеивая счётчик с артикулом товара
                    //но делать я этого не стал, много времени потратил на понимание что и как.... )
                    //хочу уже перейти к новому модулю наконец...
                    Product product1 = new ("Кружка", "Артикул");
                    do
                    {
                        Console.WriteLine("Выберите способ получения:");
                        Console.WriteLine("1 Доставка курьером \n2 Доставка в точку самовывоза" +
                            "\n3 Доставка в магазин");
                        stringnum = Console.ReadLine();
                    } while (InputChek3(stringnum, out intnum));
                    if(intnum == 1)
                    {
                        Console.WriteLine("Введите адрес доставки");
                        string address = Console.ReadLine();
                        Console.WriteLine("Введите желаемую дату доставки:");
                        string deliveryDate = Console.ReadLine();
                        HomeDelivery delivery = new(address, deliveryDate);
                        product1.PrintProductIonInfo();                        
                        delivery.PrintDeliveryInfo();
                    }
                    else if (intnum == 2)
                    {
                        Console.WriteLine("Введите желаемую дату доставки:");
                        string deliveryDate = Console.ReadLine();
                        string pickPointAddress = PickPointDelivery.PickPointAddress;
                        PickPointDelivery pickPointDelivery = new(pickPointAddress, deliveryDate);
                        product1.PrintProductIonInfo();
                        pickPointDelivery.PrintDeliveryInfo();
                    }
                    else if(intnum == 3)
                    {
                        Console.WriteLine("Введите желаемую дату доставки:");
                        string deliveryDate = Console.ReadLine();
                        string shopAddress = ShopDelivery.ShopAddress;
                        ShopDelivery shopDelivery = new(shopAddress, deliveryDate);
                        product1.PrintProductIonInfo();
                        shopDelivery.PrintDeliveryInfo();
                    }
                }
                else 
                {
                    Product product1 = new("Тарелка", "Артикул");
                    do
                    {
                        Console.WriteLine("Выберите способ получения:");
                        Console.WriteLine("1 Доставка курьером \n2 Доставка в точку самовывоза" +
                            "\n3 Доставка в магазин");
                        stringnum = Console.ReadLine();
                    } while (InputChek3(stringnum, out intnum));
                    if (intnum == 1)
                    {
                        Console.WriteLine("Введите адрес доставки");
                        string address = Console.ReadLine();
                        Console.WriteLine("Введите желаемую дату доставки:");
                        string deliveryDate = Console.ReadLine();
                        HomeDelivery delivery = new(address, deliveryDate);
                        product1.PrintProductIonInfo();
                        delivery.PrintDeliveryInfo();
                    }
                    else if (intnum == 2)
                    {
                        Console.WriteLine("Введите желаемую дату доставки:");
                        string deliveryDate = Console.ReadLine();
                        string pickPointAddress = PickPointDelivery.PickPointAddress;
                        PickPointDelivery pickPointDelivery = new(pickPointAddress, deliveryDate);
                        product1.PrintProductIonInfo();
                        pickPointDelivery.PrintDeliveryInfo();
                    }
                    else if (intnum == 3)
                    {
                        Console.WriteLine("Введите желаемую дату доставки:");
                        string deliveryDate = Console.ReadLine();
                        string shopAddress = ShopDelivery.ShopAddress;
                        ShopDelivery shopDelivery = new(shopAddress, deliveryDate);
                        product1.PrintProductIonInfo();
                        shopDelivery.PrintDeliveryInfo();
                    }
                }
            }
            else if (intnum == 2)
            {
                do
                {
                    Console.WriteLine("Выберите категорию: \n1 Диван\n2 Стол\n Введите: 1 или 2");
                    stringnum = Console.ReadLine();

                } while (InputChek2(stringnum, out intnum));
                if (intnum == 1)
                {   //поидеи можно было реализовать счётчик заказов и выдавать номер склеивая счётчик с артикулом товара
                    //но делать я этого не стал, много времени потратил на понимание что и как.... не до конца всё осознал)
                    //хочу уже перейти к новому модулю наконец...
                    Product product1 = new("Диван", "Артикул");
                    do
                    {
                        Console.WriteLine("Выберите способ получения:");
                        Console.WriteLine("1 Доставка курьером \n2 Доставка в точку самовывоза" +
                            "\n3 Доставка в магазин");
                        stringnum = Console.ReadLine();
                    } while (InputChek3(stringnum, out intnum));
                    if (intnum == 1)
                    {
                        Console.WriteLine("Введите адрес доставки");
                        string address = Console.ReadLine();
                        Console.WriteLine("Введите желаемую дату доставки:");
                        string deliveryDate = Console.ReadLine();
                        HomeDelivery delivery = new(address, deliveryDate);
                        product1.PrintProductIonInfo();
                        delivery.PrintDeliveryInfo();
                    }
                    else if (intnum == 2)
                    {
                        Console.WriteLine("Введите желаемую дату доставки:");
                        string deliveryDate = Console.ReadLine();
                        string pickPointAddress = PickPointDelivery.PickPointAddress;
                        PickPointDelivery pickPointDelivery = new(pickPointAddress, deliveryDate);
                        product1.PrintProductIonInfo();
                        pickPointDelivery.PrintDeliveryInfo();
                    }
                    else if (intnum == 3)
                    {
                        Console.WriteLine("Введите желаемую дату доставки:");
                        string deliveryDate = Console.ReadLine();
                        string shopAddress = ShopDelivery.ShopAddress;
                        ShopDelivery shopDelivery = new(shopAddress, deliveryDate);
                        product1.PrintProductIonInfo();
                        shopDelivery.PrintDeliveryInfo();
                    }
                }
                else
                {
                    Product product1 = new("Стол", "Артикул");
                    do
                    {
                        Console.WriteLine("Выберите способ получения:");
                        Console.WriteLine("1 Доставка курьером \n2 Доставка в точку самовывоза" +
                            "\n3 Доставка в магазин");
                        stringnum = Console.ReadLine();
                    } while (InputChek3(stringnum, out intnum));
                    if (intnum == 1)
                    {
                        Console.WriteLine("Введите адрес доставки");
                        string address = Console.ReadLine();
                        Console.WriteLine("Введите желаемую дату доставки:");
                        string deliveryDate = Console.ReadLine();
                        HomeDelivery delivery = new(address, deliveryDate);
                        product1.PrintProductIonInfo();
                        delivery.PrintDeliveryInfo();
                    }
                    else if (intnum == 2)
                    {
                        Console.WriteLine("Введите желаемую дату доставки:");
                        string deliveryDate = Console.ReadLine();
                        string pickPointAddress = PickPointDelivery.PickPointAddress;
                        PickPointDelivery pickPointDelivery = new(pickPointAddress, deliveryDate);
                        product1.PrintProductIonInfo();
                        pickPointDelivery.PrintDeliveryInfo();
                    }
                    else if (intnum == 3)
                    {
                        Console.WriteLine("Введите желаемую дату доставки:");
                        string deliveryDate = Console.ReadLine();
                        string shopAddress = ShopDelivery.ShopAddress;
                        ShopDelivery shopDelivery = new(shopAddress, deliveryDate);
                        product1.PrintProductIonInfo();
                        shopDelivery.PrintDeliveryInfo();
                    }
                }
            }            
        }
    }
    class Program
    {        
        static void Main(string[] args)
        {            
            Order<Delivery, Product> order = new();
            order.MakeOrder(); 
        }
    }
}
