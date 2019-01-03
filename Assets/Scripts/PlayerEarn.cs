using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//namespace System;

public class Player : MonoBehaviour
{

    private static int Cash = DataBase.cash;
    public static int[,] ownedBuildingTypes = new int[,] { { 0, 20 }, { 0, 30 }, { 0, 50 }, { 0, 75 } };
    // '0' - #number'o'Office ($20), '1' - #number'o'convienienceStore ($30), 
    // '2' - #number'o'apartmentBuilding ($50), '3' - #number'o'tradeCenter ($75)

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If building type owned gain x money per building pe


    }   

    //per turn
    
    for(int i = 0; i < 4; i++)
    {
        Cash += ownedBuildingTypes[i,0] * ownedBuildingTypes[i,1];
`   }
}