using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class EmployeeMode : NetworkBehaviour
{

    public GameObject employeeModeButton;

    void Start()
    {
    }

    void Update()
    {
    }

    public void EmployeeModeActivation() //employee mode makes it so that all of your buildings show up as blue and all of the opponent's buildings show
    {                                    //up as red. In this mode, you can adjust # of employees and happiness levels

        if (DataBase.employeeModeIsActivated == false)
        {
            employeeModeButton.GetComponent<Image>().color = new Color32(149, 149, 149, 255);

            for (int i = 0; i < DataBase.buildingsList.Count; i++)
            {
                if (DataBase.buildingsList[i].owner == "Server" && isServer)
                {
                    GameObject.Find(DataBase.buildingsList[i].buildingName).GetComponent<SpriteRenderer>().color = Color.blue;
                }
                else if (DataBase.buildingsList[i].owner == "Client" && isServer)
                {
                    GameObject.Find(DataBase.buildingsList[i].buildingName).GetComponent<SpriteRenderer>().color = Color.red;
                }
                else if (DataBase.buildingsList[i].owner == "Client" && isClient)
                {
                    GameObject.Find(DataBase.buildingsList[i].buildingName).GetComponent<SpriteRenderer>().color = Color.blue;
                }
                else if (DataBase.buildingsList[i].owner == "Server" && isClient)
                {
                    GameObject.Find(DataBase.buildingsList[i].buildingName).GetComponent<SpriteRenderer>().color = Color.red;
                }
            }

            DataBase.employeeModeIsActivated = true;
        }

        else if (DataBase.employeeModeIsActivated == true) {

            for (int i = 0; i < DataBase.buildingsList.Count; i++)
            {
                GameObject.Find(DataBase.buildingsList[i].buildingName).GetComponent<SpriteRenderer>().color = Color.white;
            }

            DataBase.employeeModeIsActivated = false;
        }
    }
}
