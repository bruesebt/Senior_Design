using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsTheMove.Core.API;
using WhatsTheMove.Core.Common;
using WhatsTheMove.Data.Models;
using WhatsTheMove.Core.Enums;

namespace WhatsTheMove.Core.Tests
{
    [TestClass]
    public class PreferenceTests
    {
        private static Preference TestPreference = new Preference()
        {
            UserId = 14,
            ZipCode = "45245",
            Distance = 10,
            GroupSize = (int)GroupSize.Medium,
            IsFoodRequested = true,
            IsDrinksRequested = false,
            EnergyLevel = null,
            Budget = (int)Budget.Cheaper,
            TimeOfDay = null, 
            DressCode = null,
            DateAdded = System.DateTime.Now
        };

        [TestMethod]
        public async Task A_CreatePreferenceTest()
        {
            // Initialize api helper
            ApiHelper.InitializeClient();

            // Create
            Preference Preference = await PreferenceProcessor.CreatePreference(TestPreference);

            Assert.IsNotNull(Preference);
        }


        [TestMethod]
        public async Task B_GetPreferencesTest()
        {
            // Initialize api helper
            ApiHelper.InitializeClient();

            IEnumerable<Preference> userPreferences = await PreferenceProcessor.LoadPreferences(TestPreference.UserId);

            Assert.IsNotNull(userPreferences);
            Assert.IsTrue(userPreferences.Any());
        }


        [TestMethod]
        public async Task C_UpdatePreferenceTest()
        {
            Preference Preference1 = await GetPreference();

            Assert.IsNotNull(Preference1);

            // Update
            Preference Preference2 = new Preference()
            {
                Id = Preference1.Id,
                UserId = 14,
                ZipCode = "45305",
                Distance = 15,
                GroupSize = (int)GroupSize.Small,
                IsFoodRequested = false,
                IsDrinksRequested = true,
                EnergyLevel = (int)EnergyLevel.Medium,
                Budget = (int)Budget.Expensive,
                TimeOfDay = (int)TimeOfDay.Afternoon,
                DressCode = (int)DressCode.Casual,
                DateAdded = System.DateTime.Now
            };

            Preference2 = await PreferenceProcessor.UpdatePreference(Preference2);

            Assert.IsNotNull(Preference2);
            Assert.IsFalse(Preference1.Equals(Preference2));
            Assert.AreEqual(Preference2.UserId, TestPreference.UserId);
            Assert.AreEqual(Preference2.ZipCode, "45305");
        }


        [TestMethod]
        public async Task D_DeletePreference()
        {
            Preference pref = await GetPreference();

            Assert.IsNotNull(pref);

            // Delete
            await PreferenceProcessor.DeletePreference(pref.Id);

            IEnumerable<Preference> userPreferences = await PreferenceProcessor.LoadPreferences(TestPreference.UserId);

            Assert.IsNotNull(userPreferences);
            Assert.IsFalse(userPreferences.Any());
        }

        public async Task<Preference> GetPreference()
        {
            // Initialize api helper
            ApiHelper.InitializeClient();

            IEnumerable<Preference> userPreferences = await PreferenceProcessor.LoadPreferences(TestPreference.UserId);

            Assert.IsNotNull(userPreferences);
            Assert.IsTrue(userPreferences.Any());

            Preference Preference = userPreferences.First();

            return Preference;
        }
    }
}
