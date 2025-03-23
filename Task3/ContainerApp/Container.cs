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

    public virtual void LoadCargo(double massOfCargo)
    {
        if (massOfCargo > _maximumPayload) throw new OverfillException("Attempted Overload of " + this.SerialNumber + " Container!");
        else this._massOfCargo = massOfCargo;
    }

    public virtual void Empty()
    {
        this._massOfCargo = 0;
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
    public GasContainer(double containerHeight, double containerDepth, double tareWeight,
        double maximumPayload) : base(containerHeight, containerDepth, tareWeight, maximumPayload)
    {
        SetSerialNumber();
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
    
    public string Notify(string message)
    {
        return message + "\nContainer Serial Number: " + this.SerialNumber;
    }

    public override void LoadCargo(double massOfCargo)
    {
        
    }

    private void CargoInformation()
    {
        
    }

    protected override void SetSerialNumber()
    {
        this.SerialNumber = "Kon-C-" + NumberOfContainers;
        ++NumberOfContainers;
    }
}