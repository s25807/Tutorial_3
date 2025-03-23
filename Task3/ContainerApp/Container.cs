namespace ContainerApp;

public abstract class Container
{
    protected static int NumberOfContainers = 0;
    protected double _massOfCargo, _containerHeight, _containerDepth, _tareWeight, _maximumPayload;
    protected string SerialNumber;

    public Container(double _massOfCargo, double containerHeight, double containerDepth, double tareWeight, double maximumPayload)
    {
        this._massOfCargo = _massOfCargo;
        this._containerHeight = containerHeight;
        this._containerDepth = containerDepth;
        this._tareWeight = tareWeight;
        this._maximumPayload = maximumPayload;
    }

    protected abstract void SetSerialNumber();

    public virtual void LoadCargo(double massOfCargo)
    {
        this._massOfCargo = massOfCargo;
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
    public LiquidContainer(double _massOfCargo, double containerHeight, double containerDepth, double tareWeight,
        double maximumPayload, Category category) : base(0, containerHeight, containerDepth, tareWeight, maximumPayload)
    {
        this._category = category;
    }

    public override void LoadCargo(double massOfCargo)
    {
        if (massOfCargo >= this._maximumPayload / 2 && this._category == Category.Hazardous) Console.WriteLine(Notify("Attempted Overload of Hazardous Container!"));
        else if(massOfCargo >= this._maximumPayload * 0.9 && this._category == Category.Ordinary) Console.WriteLine(Notify("Attempted Overload of Ordinary Container!"));
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