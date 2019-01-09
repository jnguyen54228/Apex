using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine;

public class TurnManager : NetworkBehaviour {

    private GameObject dayText;
    private GameObject waitPanel;
    DataBase scriptInstance = null;
    private int day;
    public int cash;

    // Use this for initialization
    void Start()
    {
        waitPanel = GameObject.Find("Wait Panel");
        waitPanel.SetActive(false);

        day = 1;

        dayText = GameObject.Find("Day");
        dayText.GetComponent<Text>().text = day.ToString();

        GameObject tempObj = GameObject.Find("Cash");
        scriptInstance = tempObj.GetComponent<DataBase>();
    }
	
	// Update is called once per frame
	void Update () {

        if (isServer) {
            if (DataBase.turn == "server")    //if it's the server's turn on the server's computer,                                        
            {
                //they are free to do what ever they want 
                cash = scriptInstance.Main();
                waitPanel.SetActive(false);
                Cursor.visible = true;
            }
            else {                                          //however if it's the client's turn on the server's computer,
                waitPanel.SetActive(true);                  //the server;s computer is locked 
                Cursor.visible = false;
            }
        }
        else if (!isServer)
        {
            if (DataBase.turn == "client") {
                waitPanel.SetActive(false);
                Cursor.visible = true;
            }
            else
            {
                waitPanel.SetActive(true);
                Cursor.visible = false;
            }
        }
    }

    public void EndTurn()  //function that runs when the end turn button is pressed     
    {                           
        if (isServer)           
        {
            DataBase.turn = "client"; 
            DataBase.serverTurnEnded = true; //triggers code to run in the PlayerController Class
        }
        else if (!isServer) {
            DataBase.turn = "server";
            DataBase.clientTurnEnded = true;
        }
    }
}
