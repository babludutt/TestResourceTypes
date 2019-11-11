
using System;
using System.Collections.Generic;
using System.Text;

namespace AirWC.ClassLib
{
    class ResourceEqualityComparer : IEqualityComparer<Resource>
    {
        public bool Equals(Resource item1, Resource item2)
        {
            if (object.ReferenceEquals(item1, item2))
                return true;
            if (item1 == null || item2 == null)
                return false;
            return item1.ResourceType.Equals(item2.ResourceType) &&
                   item1.NumberofUnits.Equals(item2.NumberofUnits);
        }

        public int GetHashCode(Resource item)
        {
            return new { item.ResourceType, item.NumberofUnits }.GetHashCode();
        }
    }
}

