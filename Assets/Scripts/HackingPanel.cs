using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HackingPanel : MonoBehaviour
{
    public GameObject hackingScreen;
    public GameObject infiniteCashToggle;
    public GameObject infiniteEmployeesToggle;

    void Start()
    {
        infiniteCashToggle.GetComponent<Toggle>().isOn = false;
        infiniteEmployeesToggle.GetComponent<Toggle>().isOn = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Tab) && Input.GetKeyDown(KeyCode.LeftShift))
        {
            hackingScreen.SetActive(true);
        }
        if (infiniteCashToggle.GetComponent<Toggle>().isOn == true) {

        }
    }
}
