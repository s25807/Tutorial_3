namespace ContainerApp;

public class Ship
{
    private List<Container> _containers;
    private double _maximumSpeedKnots, _maximumWeightOfAllContainers;
    private int _maximumContainerCapacity;

    public Ship(int maximumContainerCapacity, double maximumSpeedKnots, double maximumWeightOfAllContainers)
    {
        this._containers = new List<Container>();
        this._maximumContainerCapacity = maximumContainerCapacity;
        this._maximumSpeedKnots = maximumSpeedKnots;
        this._maximumWeightOfAllContainers = maximumWeightOfAllContainers;
    }

    public bool AddContainer(Container container)
    {
        if (this._containers.Count <= this._maximumContainerCapacity && !this._containers.Contains(container))
        {
            this._containers.Add(container);
            return true;
        }
        return false;
    }

    public bool AddListOfContainers(List<Container> listOfContainers)
    {
        for(int i = 0; i < listOfContainers.Count; i++){
            if(!AddContainer(listOfContainers[i])) return false;
        }
        return true;
    }

    public bool RemoveContainer(Container container)
    {
        return this._containers.Remove(container);
    }

    public bool ReplaceContainer(Container newContainer, string containerSerialNumber)
    {
        for (int i = 0; i < this._containers.Count; i++)
        {
            if (this._containers[i].ToString().Equals(containerSerialNumber))
            {
                this._containers[i] = newContainer;
                return true;
            }
        }
        return false;
    }

    private string GetAllContainersSerialNumber()
    {
        string result = "";
        for (int i = 0; i < this._containers.Count; i++)
        {
            result += "\n" + this._containers[i].ToString();
        }
        return result;
    }
    
    public string GetInformation()
    {
        return "--Ship Information--\nMaximum Speed: " + this._maximumSpeedKnots +
               "\nMaximum Allowed Weight: " + this._maximumWeightOfAllContainers +
               "\nContainer Capacity: " + this._maximumContainerCapacity + 
               "\nCurrent Containers: " + GetAllContainersSerialNumber();
    }
}