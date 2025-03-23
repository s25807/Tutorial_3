namespace ContainerApp;

public class Program
{
    public static void Main(string[] args)
    {
        LiquidContainer myLiquidContainer = new LiquidContainer(400, 500, 100, 1000, LiquidContainer.Category.Hazardous);
        GasContainer myGasContainer = new GasContainer(200, 200, 50, 800);
        
        Console.WriteLine(myLiquidContainer);
        Console.WriteLine(myGasContainer);
    }
}