﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataBase : MonoBehaviour {     //Class used for data shared across the game

    public static int cash = 100;
    public static int currentBuildingPrice;
    public static string currentBuilding;
    public static bool highlightBuildingTest = false;
    public static bool EmployeeModeHighlightBuildingTest = false;
    public static GameObject currentBuildingObject = null;
    public static GameObject previousBuilding = null;
    public static string turn = "server"; //the server gets the first turn of the game
    public static bool serverTurnEnded = false;
    public static bool clientTurnEnded = false;
    public static int turns = 0; //total number of turns that have taken place; used to determine the current day
    public static int day = 1;
    public static bool serverBuildingPurchased = false;
    public static bool clientBuildingPurchased = false;
    public static bool serverWin = false; //determines whether server/client has won
    public static bool clientWin = false;
    public static int totalRevenue = 0;
    public static int employeePool = 100;
    public static int employeesOwned = 0;
    public static bool employeeModeIsActivated = false;
    public static bool employeeModeCloseButton = false;
    public static Color32 employeeModePreviousColor;
    public static bool newTurn = false;
    public static bool infinteCashActivated = false;

    public static IList<Building> buildingsList = new List<Building>() {

        new Building(){ buildingName = "Office Building 1", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 10},
        new Building(){ buildingName = "Office Building 2", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 10},
        new Building(){ buildingName = "Office Building 3", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 10},
        new Building(){ buildingName = "Convenience Store 1", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15, employeeCap = 5, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 15, leaveRate = 10},
        new Building(){ buildingName = "Convenience Store 2", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15, employeeCap = 5, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 15, leaveRate = 10},
        new Building(){ buildingName = "Convenience Store 3", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15, employeeCap = 5, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 15, leaveRate = 10},
        new Building(){ buildingName = "Apartment Building 1", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 10},
        new Building(){ buildingName = "Apartment Building 2", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 10},
        new Building(){ buildingName = "Apartment Building 3", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 10},
        new Building(){ buildingName = "Trade Center 1", buildingBought = false, buildingPrice = 70, owner = "none", revenue = 35, employeeCap = 15, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 35, leaveRate = 10},
        new Building(){ buildingName = "Trade Center 2", buildingBought = false, buildingPrice = 70, owner = "none", revenue = 35, employeeCap = 15, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 35, leaveRate = 10},
        new Building(){ buildingName = "Club 1", buildingBought = false, buildingPrice = 100, owner = "none", revenue = 50, employeeCap = 20, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 50, leaveRate = 10},
        new Building(){ buildingName = "Club 2", buildingBought = false, buildingPrice = 100, owner = "none", revenue = 50, employeeCap = 20, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 50, leaveRate = 10},
        new Building(){ buildingName = "Super Market 1", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 10},
        new Building(){ buildingName = "Super Market 2", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 10},
        new Building(){ buildingName = "Church 1", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15, employeeCap = 5, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 15, leaveRate = 10},
        new Building(){ buildingName = "Church 2", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15, employeeCap = 5, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 15, leaveRate = 10},
        new Building(){ buildingName = "Movie Theater", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 10},
        new Building(){ buildingName = "Blockbuster 1", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 10},
        new Building(){ buildingName = "Blockbuster 2", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 10},
        new Building(){ buildingName = "S-Bank", buildingBought = false, buildingPrice = 100, owner = "none", revenue = 50, employeeCap = 20, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 50, leaveRate = 10},
        new Building(){ buildingName = "Cake Shop 1", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 10},
        new Building(){ buildingName = "Cake Shop 2", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 10},
        new Building(){ buildingName = "Post Office 1", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15, employeeCap = 5, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 15, leaveRate = 10},
        new Building(){ buildingName = "Post Office 2", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15, employeeCap = 5, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 15, leaveRate = 10},
        new Building(){ buildingName = "Mall", buildingBought = false, buildingPrice = 100, owner = "none", revenue = 50, employeeCap = 20, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 50, leaveRate = 10},
        new Building(){ buildingName = "H-Tower", buildingBought = false, buildingPrice = 100, owner = "none", revenue = 50, employeeCap = 20, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 50, leaveRate = 10},
        new Building(){ buildingName = "Parking Garage 1", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 10},
        new Building(){ buildingName = "Parking Garage 2", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 10}
    };

    // public static int[,] ownedBuildingTypes = new int[5, 2] { { 0, 20 }, { 0, 30 }, { 0, 50 }, { 0, 70}, { 0, 100} }; //the second number of each array represents
    //the price of the building
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

        public int leaveRate { get; set; }
    }
}
