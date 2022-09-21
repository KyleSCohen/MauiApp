
namespace AMPAS.Model;

public class FruitService
{
    private readonly List<Fruit> _fruitDB = new()
    {
        new Fruit("apple.png", "Apple"),
        new Fruit("bananas.png", "Bananas"),
        new Fruit("orange.png", "Orage"),
        new Fruit("guava.png", "Guava"),
        new Fruit("guava.png", "Guava"),
        new Fruit("guava.png", "Guava"),
        new Fruit("watermelon.png", "Watermelon")
    };

    public Fruit GetFruit()
        => _fruitDB[new Random().Next(0, 
                                    _fruitDB.Count - 1)];
}


// Contract for a fruit
public record struct Fruit(string Source, string Name);
