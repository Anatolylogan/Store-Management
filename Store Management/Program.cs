namespace Store_Management
{
    public class Program
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
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddProduct(store);
                            break;
                        case 2:
                            store.DisplayProducts();
                            break;
                        case 3:
                            totalValue(store);
                            break;
                        case 4:
                            ApplyDiscount(store);
                            break;
                        case 5:
                            Console.WriteLine("До свидания!");
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Неверный ввод. Попробуйте снова!");
                            break;

                    }
                }
            }
        }
        private static void AddProduct(Store store)
        {
            Console.Write("Введите название товара: ");
            string name = Console.ReadLine();

            Console.Write("Введите цену товара: ");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price) || price <= 0)
            {
                Console.WriteLine("Некорректная цена. Введите положительное число: ");
            }
            Console.WriteLine("Выберите категорию товара:");
            Console.WriteLine("0 - Продукты питания");
            Console.WriteLine("1 - Электроника");
            Console.WriteLine("2 - Одежда");
            int categoryChoice;
            while (!int.TryParse(Console.ReadLine(), out categoryChoice) || categoryChoice < 0 || categoryChoice > 2)
            {
                Console.WriteLine("Некорректный выбор. Пожалуйста, выберите от 0 до 2: ");
            }
            ProductCategory category = (ProductCategory)categoryChoice;
            Product newProduct = new Product(name, price, category);
            store.AddProduct(newProduct);
        }

        private static void ApplyDiscount(Store store)
        {
            Console.WriteLine("Введите индекс товара для примениня скидки:");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите процент скидки:");
            double percentage = double.Parse(Console.ReadLine());
            Discount discount = new Discount(percentage);
            store.ApplyDiscountToProduct(index, discount);
        }
        private static void totalValue(Store store)
        {
            double totalValue = store.CalculateTotalStoreValue();
            Console.WriteLine($"Общая стоимость всех товаров с учетом налога: {totalValue}");
        }
    }
}