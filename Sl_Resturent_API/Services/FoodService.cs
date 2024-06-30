using Sl_Resturent_API.Models;

namespace Sl_Resturent_API.Services;

public static class FoodService
{
    static List<Foods> Pizzas { get; }
    static int nextId = 3;
    static FoodService()
    {
        Pizzas = new List<Foods>
        {
            new Foods { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
            new Foods { Id = 2, Name = "Veggie", IsGlutenFree = true }
        };
    }

    public static List<Foods> GetAll() => Pizzas;

    public static Foods? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Foods pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Delete(int id)
    {
        var pizza = Get(id);
        if(pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    public static void Update(Foods pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if(index == -1)
            return;

        Pizzas[index] = pizza;
    }
}