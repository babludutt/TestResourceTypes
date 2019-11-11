using Microsoft.VisualStudio.TestTools.UnitTesting;
using AirWC;
using System.Collections.Generic;
using System.Linq;
using System;
using AirWC.ClassLib;

namespace AirWC.UnitTest
{
    [TestClass]
    public class AirWCUnitTest
    {
        [TestMethod]
        public void TestEqualReference()
        {
            Resource r = new Resource(ResourceType.Firmware, 10);

            Provider provider = new Provider();
            provider.Add(r);

            Demands demands = new Demands();
            demands.Add(r);

            int c = Create(provider, demands);
            Assert.IsTrue(c == 1);


        }
        public int Create(Provider provider, Demands demands)
        {
            IEnumerable<Resource> resources = provider.Resources.Intersect(demands.Resources, new ResourceEqualityComparer());
            return resources.Count();
        }

        [TestMethod]
        public void ValueEquals()
        {
            Provider provider = new Provider();
            provider.Add(new Resource(ResourceType.Firmware, 10));

            Demands demands = new Demands();
            demands.Add(new Resource(ResourceType.Firmware, 10));

            int c = Create(provider, demands);
            Assert.IsTrue(c == 1);
        }

        [TestMethod]
        public void CountIntersect()
        {
            Provider provider = new Provider();
            provider.Add(new Resource(ResourceType.Firmware, 10));
            provider.Add(new Resource(ResourceType.Hardware, 20));

            Demands demands = new Demands();
            demands.Add(new Resource(ResourceType.Firmware, 10));
            demands.Add(new Resource(ResourceType.Other, 30));

            int c = Create(provider, demands);
            Assert.IsTrue(c == 1);
        }

        [TestMethod]
        public void CheckMaxSize()
        {
            Provider provider = new Provider();
            provider.Add(new Resource(ResourceType.Firmware, 10));
            provider.Add(new Resource(ResourceType.Hardware, 20));
            provider.Add(new Resource(ResourceType.Software, 30));
            provider.Add(new Resource(ResourceType.Other, 40));
            try
            {
                provider.Add(new Resource(ResourceType.Other, 50));
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentOutOfRangeException));
            }
        }

        [TestMethod]
        public void DuplicateCheck()
        {
            Provider provider = new Provider();
            provider.Add(new Resource(ResourceType.Firmware, 10));

            try
            {
                provider.Add(new Resource(ResourceType.Firmware, 20));
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }
        }
    }
}

