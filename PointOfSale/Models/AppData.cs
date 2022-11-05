namespace PointOfSale.Models;

public static class AppData
{
    private static Random random = new Random();
    public static string[] Statuses = new string[] { "Cat", "Dog","Cat", "Dog","Cat", "Dog","Cat", "Dog","Cat", "Cat"};
    public static List<int> Tables = new List<int> { 7,8,9,10,11,12,13,14 };

    public static List<Item> Items = new List<Item>
    {
        new Item(){ Title = "Burmese Cat", Price    = 13.99, Quantity = 1, Image = "japchae.png", Category = ItemCategory.Noodles},
        new Item(){ Title = "Dachshund Dog", Price = 14.99, Quantity = 1, Image = "jajangmyeon.png", Category = ItemCategory.Noodles},
        new Item(){ Title = "Chartreux Cat", Price = 12.99, Quantity = 1, Image = "janchi_guksu.png", Category = ItemCategory.Noodles},
        new Item(){ Title = "Coton de Tulear Dog", Price = 14.99, Quantity = 1, Image = "budae_jjigae.png", Category = ItemCategory.Noodles},
        new Item(){ Title = "Scottish Fold Cat", Price = 12.99, Quantity = 1, Image = "naengmyeon.png", Category = ItemCategory.Noodles},
        new Item(){ Title = "Belgian Shepherd Dog", Price = 2.50, Quantity = 1, Category = ItemCategory.Beverages, Image = "soda.png"},
        new Item(){ Title = "Siamese Cat", Price = 3.50, Quantity = 1, Category = ItemCategory.Beverages, Image = "iced_tea.png"},
        new Item(){ Title = "Curly Coated Retriever ", Price = 4.00, Quantity = 1, Category = ItemCategory.Beverages, Image = "tea.png"},
        new Item(){ Title = "Toyger Cat", Price = 4.00, Quantity = 1, Category = ItemCategory.Beverages, Image = "coffee.png"},
        new Item(){ Title = "Abyssinian Cat", Price = 5.00, Quantity = 1, Category = ItemCategory.Beverages, Image = "milk.png"},
    };
    
    public static List<Order> Orders { get; set; } = GenerateOrders();

    private static List<Order> GenerateOrders()
    {
        random.Shuffle(Tables);
        List<Order> orders = new List<Order>();
        for (int i = 0; i < Tables.Count; i++)
        {
            orders.Add((new Order()
            {
                Table = Tables[i],
                Status = RandomStatus(i),
                Items = GenerateItems(i)
            }));
        }

        orders.OrderByDescending(x => x.Status);
        return orders;
    }

    private static List<Item> GenerateItems(int i)
    {
        List<Item> items = new List<Item>();
        items.Add(Items[i]);
        return items;
    }

    private static string RandomStatus(int i)
    {
        //var i = random.Next(0, Statuses.Length - 1);
        return Statuses[i];
    }
}

static class RandomExtensions
{
    public static void Shuffle<T> (this Random rng, List<T> array)
    {
        int n = array.Count;
        while (n > 1) 
        {
            int k = rng.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }
}