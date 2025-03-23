namespace ContainerApp;

public class Program
{
    public static void Main(string[] args)
    {
        Ship myFirstShip = new Ship(5, 500, 4000);
        Ship mySecondShip = new Ship(6, 500, 1000);
        
        LiquidContainer myLiquidContainer = new LiquidContainer(400, 500, 100, 1000, LiquidContainer.Category.Hazardous);
        myLiquidContainer.LoadCargo(500);
        GasContainer myGasContainer = new GasContainer(200, 200, 50, 800, 1200);
        myGasContainer.LoadCargo(200);
        RefrigeratedContainer myRefrigeratedContainer =
            new RefrigeratedContainer(300, 200, 100, 500, Product.Food.Bananas);
        myRefrigeratedContainer.LoadCargo(500);
        GasContainer myOtherGasContainer = new GasContainer(400, 200, 50, 800, 1200);
        myOtherGasContainer.LoadCargo(300);
        RefrigeratedContainer myOtherRefrigeratedContainer = new RefrigeratedContainer(400, 200, 100, 500, Product.Food.Cheese);
        myOtherRefrigeratedContainer.LoadCargo(300);
        RefrigeratedContainer myThirdRefrigeratedContainer = new RefrigeratedContainer(300, 200, 100, 1000, Product.Food.Chocolate);
        myThirdRefrigeratedContainer.LoadCargo(800);
        myFirstShip.AddContainer(myLiquidContainer);
        
        List<Container> myContainers = new List<Container>();
        myContainers.Add(myGasContainer);
        myContainers.Add(myRefrigeratedContainer);
        myContainers.Add(myOtherRefrigeratedContainer);
        myContainers.Add(myThirdRefrigeratedContainer);
        myContainers.Add(myOtherGasContainer);
        
        mySecondShip.AddListOfContainers(myContainers);
        
        Ship.TransferContainerBetweenShips(mySecondShip, myGasContainer, myFirstShip);
            
        myRefrigeratedContainer.Empty();
        mySecondShip.RemoveContainer(myOtherRefrigeratedContainer);
        Console.WriteLine(myFirstShip.GetInformation());
        Console.WriteLine(mySecondShip.GetInformation());
        Console.WriteLine(myLiquidContainer);
        Console.WriteLine(myGasContainer);
        Console.WriteLine(myRefrigeratedContainer);
        Console.WriteLine(myOtherRefrigeratedContainer.GetInformation());
    }
}