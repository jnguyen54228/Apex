using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;

public class RevPerBuilding : NetworkBehaviour
{
    public static IList<Building> buildingsList = new List<Building>() {

        new Building(){ buildingName = "Office Building 1", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 10,  //start-game building
            employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 10, maxRevenue = 40},

        new Building(){ buildingName = "Office Building 2", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 10,  //start-game building
            employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 10, maxRevenue = 40},

        new Building(){ buildingName = "Convenience Store 1", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 10,  //start-game building
            employeeCap = 5, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 10, maxRevenue = 25},  //has more appeal in beginning because has more bang for your buck early on

        new Building(){ buildingName = "Convenience Store 2", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 10,  //start-game building
            employeeCap = 5, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 10, maxRevenue = 25},

        new Building(){ buildingName = "Apartment Building 1", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 10,  //start-game building
            employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 10, maxRevenue = 40},  //might not be as appealing early on, but will be more beneficial in the long run

        new Building(){ buildingName = "Apartment Building 2", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 10,  //start-game building
            employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 10, maxRevenue = 40},

        new Building(){ buildingName = "Trade Center 1", buildingBought = false, buildingPrice = 150, owner = "none", revenue = 40,  //mid-game building
            employeeCap = 15, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 40, maxRevenue = 110},  //when buying this building is when you should be focusing your attention to what strategy you will use

        new Building(){ buildingName = "Trade Center 2", buildingBought = false, buildingPrice = 150, owner = "none", revenue = 40,  //mid-game building
            employeeCap = 15, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 40, maxRevenue = 110},

        new Building(){ buildingName = "Club", buildingBought = false, buildingPrice = 250, owner = "none", revenue = 65,  //end-game building
            employeeCap = 20, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 65, maxRevenue = 175},  //can't buy until the upper half  of the mid section of the game (or in the end game)

        new Building(){ buildingName = "Super Market", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 10,  //start-game building
            employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 10, maxRevenue = 40},

        new Building(){ buildingName = "Church", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 10,  //start-game building
            employeeCap = 5, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 10, maxRevenue = 25},

        new Building(){ buildingName = "Movie Theater", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 10,  //start-game building
            employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 10, maxRevenue = 40}
    };

    public static int Reven(string x, int mon)
    {
        for (int i = 0; i < buildingsList.Count; i++)
        {
            if (buildingsList[i].owner == x)
            {
                double L = buildingsList[i].maxRevenue - buildingsList[i].baseRevenue;
                double D = 1 + (Math.Pow(Math.E, -(buildingsList[i].employeesOwned - (buildingsList[i].employeeCap/2))));
                double buildRev = (L / D) + buildingsList[i].baseRevenue;
   
                mon += (int)buildRev;
            }
        }

        return mon;
    }

    public class Building
    {
        public string buildingName { get; set; }

        public bool buildingBought { get; set; }

        public int buildingPrice { get; set; }

        public string owner { get; set; }

        public int revenue { get; set; }

        public int employeeCap { get; set; }

        public int employeesOwned { get; set; }

        public int daysWithNoEmployees { get; set; }

        public int baseRevenue { get; set; }

        public int maxRevenue { get; set; }
    }
}
