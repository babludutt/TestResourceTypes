using System;
using System.Collections.Generic;
using System.Linq;

namespace AirWC.ClassLib
{
    public class ResourceBase
    {
        private ICollection<Resource> requirements;
        internal ICollection<Resource> Resources
        {
            get
            {
                return requirements;
            }
        }
        public void Add(Resource requirement)
        {
            if (requirements == null)
                requirements = new List<Resource>();

            if (requirements.Count == 4)
                throw new ArgumentOutOfRangeException("Not allowed to create more than 4 instances");

            var item = requirements.FirstOrDefault(x => x.ResourceType == requirement.ResourceType);
            if (item != null)
                throw new ArgumentException("ResourceType $requirement.ResourceType already found in collection");

            requirements.Add(requirement);
        }

        public void Remove(Requirements requirement)
        {
            requirements.Remove(requirement);
        }
    }
}
