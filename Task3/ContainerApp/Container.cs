namespace ContainerApp;

public abstract class Container
{
    private static int NumberOfContainers = 0;
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

    public virtual void SetMassOfCargo(double massOfCargo)
    {
        this._massOfCargo = massOfCargo;
    }
}

public class LiquidContainer : Container
{
    protected override void SetSerialNumber()
    {
        
    }
}