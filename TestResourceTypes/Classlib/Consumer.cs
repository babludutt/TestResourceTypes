using System;
using System.Collections.Generic;
using System.Linq;

namespace AirWC.ClassLib
{
    public class Consumer
    {
        public Consumer()
        {
        }

        public void ConsumerClient()
        {
            Provider provider = new Provider();
            provider.Add(new Resource(ResourceType.Firmware, 10));

            Demands demands = new Demands();
            demands.Add(new Requirements(ResourceType.Firmware, 5));

            int c = Create(provider, demands);
        }

        public static int Create(Provider provider, Demands demands)
        {
            IEnumerable<Resource> resources = provider.Resources.Intersect(demands.Resources);
            return resources.Count();
        }
    }
}
