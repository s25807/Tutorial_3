namespace ContainerApp;

public abstract class Container
{
    protected static int NumberOfContainers = 0;
    protected double _massOfCargo, _containerHeight, _containerDepth, _tareWeight, _maximumPayload;
    protected string SerialNumber;

    public Container(double containerHeight, double containerDepth, double tareWeight, double maximumPayload)
    {
        this._massOfCargo = 0;
        this._containerHeight = containerHeight;
        this._containerDepth = containerDepth;
        this._tareWeight = tareWeight;
        this._maximumPayload = maximumPayload;
    }

    protected abstract void SetSerialNumber();
    public abstract string GetInformation();

    public virtual void LoadCargo(double massOfCargo)
    {
        if (massOfCargo > _maximumPayload) throw new OverfillException("Attempted Overload of " + this.SerialNumber + " Container!");
        else this._massOfCargo = massOfCargo;
    }

    public virtual void Empty()
    {
        this._massOfCargo = 0;
    }

    public double GetTotalWeightOfCargo()
    {
        return this._massOfCargo + this._tareWeight;
    }
    
    public override string ToString()
    {
        return this.SerialNumber;
    }
}

public class LiquidContainer : Container, IHazardNotifier
{
    public enum Category
    {
        Ordinary,
        Hazardous
    }
    private Category _category;
    public LiquidContainer(double containerHeight, double containerDepth, double tareWeight,
        double maximumPayload, Category category) : base(containerHeight, containerDepth, tareWeight, maximumPayload)
    {
        this._category = category;
        SetSerialNumber();
    }

    public override string GetInformation()
    {
        return "Container: " + this.SerialNumber + "\nCategory: " + this._category.ToString() +
               "\nCurrent Cargo Mass: " + this._maximumPayload +
               "\nMaximum Payload: " + this._maximumPayload +
               "\nContainer Height: " + this._containerHeight +
               "\nContainer Depth: " + this._containerDepth;
    }

    public override void LoadCargo(double massOfCargo)
    {
        if (massOfCargo > this._maximumPayload / 2 && this._category == Category.Hazardous) throw new OverfillException(Notify("Hazard Notification: Attempted Overload of Hazardous Liquid Container!"));
        else if(massOfCargo > this._maximumPayload * 0.9 && this._category == Category.Ordinary) throw new OverfillException(Notify("Hazard Notification: Attempted Overload of Ordinary Liquid Container!"));
        else this._massOfCargo = massOfCargo;
    }
    
    public string Notify(string message)
    {
        return message + "\nContainer Serial Number: " + this.SerialNumber;
    }
    
    protected override void SetSerialNumber()
    {
        this.SerialNumber = "Kon-L-" + NumberOfContainers;
        ++NumberOfContainers;
    }
}

public class GasContainer : Container, IHazardNotifier
{
    private double _pressurePascal;
    public GasContainer(double containerHeight, double containerDepth, double tareWeight,
        double maximumPayload, double pressure) : base(containerHeight, containerDepth, tareWeight, maximumPayload)
    {
        this._pressurePascal = pressure;
        SetSerialNumber();
    }
    
    public override string GetInformation()
    {
        return "Container: " + this.SerialNumber + "\nCategory: " + this._pressurePascal +
               "\nCurrent Cargo Mass: " + this._maximumPayload +
               "\nMaximum Payload: " + this._maximumPayload +
               "\nContainer Height: " + this._containerHeight +
               "\nContainer Depth: " + this._containerDepth;
    }

    public override void LoadCargo(double massOfCargo)
    {
        if (massOfCargo > this._maximumPayload) throw new OverfillException(Notify("Hazard Notification: Attempted Overload of Gas Container!"));
        else this._massOfCargo = massOfCargo;
    }

    public string Notify(string message)
    {
        return message + "\nContainer Serial Number: " + this.SerialNumber;
    }

    protected override void SetSerialNumber()
    {
        this.SerialNumber = "Kon-G-" + NumberOfContainers;
        ++NumberOfContainers;
    }

    public override void Empty()
    {
        this._massOfCargo = this._massOfCargo * 0.05;
    }
}

public class RefrigeratedContainer : Container
{
    private Product.Food _food;
    private double _requiredTemperature, _setTemperature;
    public RefrigeratedContainer(double containerHeight, double containerDepth, double tareWeight,
        double maximumPayload, Product.Food food) : base(containerHeight, containerDepth, tareWeight, maximumPayload)
    {
        this._food = food;
        this._requiredTemperature = Product.GetRequiredTemperature(food);
        SetSerialNumber();
    }
    
    public override string GetInformation()
    {
        return "Container: " + this.SerialNumber + "\nCategory: " + _food.ToString() +
               "\nSet Temperature: " + _setTemperature +
               "\nRequired Temperature: " + _requiredTemperature +
               "\nCurrent Cargo Mass: " + this._maximumPayload +
               "\nMaximum Payload: " + this._maximumPayload +
               "\nContainer Height: " + this._containerHeight +
               "\nContainer Depth: " + this._containerDepth;
    }
    
    public string Notify(string message)
    {
        return message + "\nContainer Serial Number: " + this.SerialNumber;
    }

    public override void LoadCargo(double massOfCargo)
    {
        if (massOfCargo > this._maximumPayload)
            throw new OverfillException(Notify("Hazard Notification: Attempted Overload of Refrigerated Container!"));
        if (Category() == this._food)
        {
            this._setTemperature = Temperature();
            this._massOfCargo = massOfCargo;
        }
        else throw new Exception(Notify("Hazard Notification: Only " + this._food.ToString() + " are allowed."));
    }

    private Product.Food Category()
    {
        Console.WriteLine("Provide Category of Product: ");
        Product.PrintAllProducts();
        return Product.GetFood(Convert.ToInt32(Console.ReadLine()));
    }

    private double Temperature()
    {
        Console.WriteLine("Enter Temperature: ");
        double temp = double.Parse(Console.ReadLine());
        if (temp >= this._requiredTemperature) return temp;
        else
        {
            Console.WriteLine("Temperature Too Low!\nSet it to Required (" + this._requiredTemperature + ")? Y/N");
            string input = Console.ReadLine();
            if (input.Equals("Y", StringComparison.OrdinalIgnoreCase)) return _requiredTemperature;
            else throw new Exception(Notify("Hazardous Notification: Attempt of Setting Temperature Too Low!"));
        }
    }

    protected override void SetSerialNumber()
    {
        this.SerialNumber = "Kon-C-" + NumberOfContainers;
        ++NumberOfContainers;
    }
}