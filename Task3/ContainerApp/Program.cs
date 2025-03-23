namespace ContainerApp;

public class Program
{
    public static void Main(string[] args)
    {
        LiquidContainer myLiquidContainer = new LiquidContainer(400, 500, 100, 1000, LiquidContainer.Category.Hazardous);
        GasContainer myGasContainer = new GasContainer(200, 200, 50, 800, 1200);
        RefrigeratedContainer myRefrigeratedContainer =
            new RefrigeratedContainer(300, 200, 100, 500, Product.Food.Bananas);
        myRefrigeratedContainer.LoadCargo(400);
        Console.WriteLine(myLiquidContainer);
        Console.WriteLine(myGasContainer);
    }
}