using System;
namespace AirWC.ClassLib
{
    public class Resource
    {
        internal ResourceType ResourceType;
        internal int NumberofUnits;

        public Resource(ResourceType resourceType, int numberofUnits)
        {
            ResourceType = resourceType;
            NumberofUnits = numberofUnits;
        }
    }
}
