namespace ContainerApp;

public class Product
{
    public enum Food
    {
        Bananas,
        Chocolate,
        Fish,
        Meat,
        IceCream,
        FrozenPizza,
        Cheese,
        Butter,
        Eggs,
        Sausage
    }

    public static double GetRequiredTemperature(Food food)
    {
        switch (food)
        {
            case Food.Bananas:
                return 13.3;
            case Food.Chocolate:
                return 18;
            case Food.Fish:
                return 2;
            case Food.Meat:
                return -15;
            case Food.IceCream:
                return -18;
            case Food.FrozenPizza:
                return -30;
            case Food.Cheese:
                return 7.2;
            case Food.Butter:
                return 20.5;
            case Food.Eggs:
                return 19;
            case Food.Sausage:
                return 5;
            default:
                return 10;
        }
    }
    public static Food GetFood(int num){ return (Food)num; }
    public static void PrintAllProducts()
    {
        for (int i = 0; i < 10; ++i)
        {
            Console.WriteLine(i + ". " + GetFood(i).ToString());
        }
    }
}