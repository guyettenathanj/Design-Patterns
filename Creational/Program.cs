#region File Purpose
/* Purpose: The purpose of this file is to give a step by step
explanation of the various factory patterns, using the C# language. 
It is meant to be read top down. Note: In a real project all the classes 
and interfaces would be seperated out into various folders and files, 
but for the sake of conveinces, I'm keeping everything in one big file.*/
// Definitions by https://learn.microsoft.com/en-us/shows/visual-studio-toolbox/design-patterns-factories
#endregion

#region Simple Factory

#region Definition and Purpose 
/* Simple Factory Pattern: Encapsulates object creation in one 
 * place. Why is this useful? We don't have to go hunting for 
 * types that implement a specific contract or interface. 
 * For example without the factory pattern shown below... */
#endregion
IYouTubeCelebrety myCeleb = new MrBeast();

#region Notes
/* Tiger is an IAnimal implementor, but we don't have a conveinent 
 * way of finding other implementors of the IAnimal interface...
Now with the simple factory shown below... */
#endregion
IYouTubeCelebrety myCeleb1 =
    ICelebretySimpleFactory.Create(CelebretyType.MrBeast);

#region Notes
/* Here with the Simple Factory pattern, we have a centralized 
 * place to create types that implement the IAnimal interface.
 * we can cycle through the AnimalType enum, to find other 
 * implementors, rather than manually searching the code. */

// Pros: Easy to implement and understand.
// Cons: Factory is tied to knowing about specific implementations.
#endregion

#region Simple Factory Pattern Dependencies...
internal class MrBeast : IYouTubeCelebrety
{
    public void Dazzle()
    {
        throw new NotImplementedException();
    }

    public string GetCatchPhrase()
    {
        return "Roar!";
    }

    public int GetMoneh()
    {
        return 100;
    }
}

internal class PewDiePie : IYouTubeCelebrety
{
    public void Dazzle()
    {
        throw new NotImplementedException();
    }

    public string GetCatchPhrase()
    {
        return "Woof!";
    }
}

internal class Markiplier : IYouTubeCelebrety
{
    public void Dazzle()
    {
        throw new NotImplementedException();
    }

    public string GetCatchPhrase()
    {
        return "Meow!";
    }
}

internal interface IYouTubeCelebrety
{
    /// <summary>
    /// Vacuous string of words to appeal to widest audience 
    /// to maximize ad revenue.
    /// </summary>
    /// <returns></returns>
    string GetCatchPhrase();

    void Dazzle();
}

public static class ICelebretySimpleFactory
{
    internal static IYouTubeCelebrety Create(CelebretyType celebretyType)
    {
        switch (celebretyType)
        {
            case CelebretyType.MrBeast:
                return new MrBeast();
            case CelebretyType.PewDiePie:
                return new PewDiePie();
            case CelebretyType.Markiplier:
                return new Markiplier();
            default:
                break;
        }
        throw new Exception("Type not found!");
    }
}

internal enum CelebretyType
{
    MrBeast,
    PewDiePie,
    Markiplier
}
#endregion
#endregion
 
#region Factory Method Pattern

// Factory Method Pattern:
// The Factory Method pattern uses factory methods to deal with the
// problem of creating objects without having to specify the exact class
// of the object that will be created.

#region Factory Method Pattern Dependencies
public abstract class PizzaStore
{
    public IPizza OrderPizza(IList<string> ingredients)
    {
        IPizza pizza = CreatePizza(ingredients);
        pizza.Bake();
        pizza.Cut();
        pizza.Box();
        return pizza;
    }
    public abstract IPizza CreatePizza(IList<string> ingredients);
}

public class NewYorkPizzaStore : PizzaStore
{
    public override IPizza CreatePizza(IList<string> ingredients)
    {
        //This is tied to a specific pizza implementation
        return new NewYorkPizza(ingredients);
    }
}
public class ChicagoPizzaStore : PizzaStore
{
    public override IPizza CreatePizza(IList<string> ingredients)
    {
        //This is tied to a specific pizza implementation
        return new ChicagoPizza(ingredients);
    }
}
public class CaliforniaPizzaStore : PizzaStore
{
    public override IPizza CreatePizza(IList<string> ingredients)
    {
        //This is tied to a specific pizza implementation
        return new CaliforniaPizza(ingredients);
    }
}

public interface IPizza
{
    IList<string> Toppings { get; }
    DoughType Dough { get; set; }
    string Seasonings { get; set; }
    string SauceType { get; set; }
    void Bake();
    void Cut();
    void Box();
}

public class NewYorkPizza : Pizza
{
    public NewYorkPizza(IList<string> ingredients) : base(ingredients)
    {
        Dough = DoughType.Thin;
    }

    public override void Bake() { }
    public override void Cut() { }
    public override void Box() { }
}
public class ChicagoPizza : Pizza
{
    public ChicagoPizza(IList<string> ingredients) : base(ingredients)
    {
        Dough = DoughType.Pan;
    }
    public override void Bake() { }
    public override void Cut() { }
    public override void Box() { }
}
public class CaliforniaPizza : Pizza
{
    public CaliforniaPizza(IList<string> ingredients) : base(ingredients)
    {
        Dough = DoughType.None;
    }
    public override void Bake() { }
    public override void Cut() { }
    public override void Box() { }
}

public abstract class Pizza : IPizza
{
    protected Pizza(IList<string> ingredients)
    {
        Toppings = ingredients;
    }
    public IList<string> Toppings { get; }
    public DoughType Dough { get; set; }
    public string Seasonings { get; set; }
    public string SauceType { get; set; }
    public abstract void Bake();
    public abstract void Cut();
    public abstract void Box();
}


// Stuff
public enum DoughType
{
    None,
    Thin,
    Pan,
    DeepDish
}

#endregion

#endregion
