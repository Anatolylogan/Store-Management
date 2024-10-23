namespace Store_Management
{
    class Program
    {

        static void Main(string[] args)
        {
            Store store = new Store(10);
            bool running = true;
            while (running)
            {
                Console.WriteLine("Добро пожаловать в магазин!");
                Console.WriteLine("Выберите дествие:");
                Console.WriteLine("1. Добавить товар");
                Console.WriteLine("2. Вывести список товаров");
                Console.WriteLine("3. Рассчитать общую стоимость магазина");
                Console.WriteLine("4. Применить скидку на товар");
                Console.WriteLine("5. Выйти");
                Console.WriteLine("Введите номер действия: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите название товра:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите цену товара:");
                        double price = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Выберите категорию товара:");
                        Console.WriteLine("1.Продукты питания");
                        Console.WriteLine("2.Электроника");
                        Console.WriteLine("3.Одежда");
                        int categoryChoice = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Товар успешно добавлен!");
                        ProductCategory category = (ProductCategory)(categoryChoice - 1);
                        Product product = new Product(name, price, category);
                        store.AddProduct(product);
                        break;
                    case "2":
                        store.DisplayProducts();
                        break;
                    case "3":
                        double totalValue = store.CalculateTotalStoreValue();
                        Console.WriteLine($"Общая стоимость всех товаров с учетом налога: {totalValue}");
                        break;
                    case "4":
                        Console.WriteLine("Введите название продукта для применения скидки");
                        string productName = Console.ReadLine();
                        foreach (var prod in store.Products)
                        {
                            if (prod != null && prod.Name == productName)
                            {
                                Console.WriteLine("Введите процент скидки");
                                double discount = Convert.ToDouble(Console.ReadLine());
                                prod.ApplyDiscount(discount);
                            }
                        }
                        break;
                    case "5":
                        Console.WriteLine("До свидания!");
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Попробуйте снова!");
                        break;

                }
            }
        }
    }
}
