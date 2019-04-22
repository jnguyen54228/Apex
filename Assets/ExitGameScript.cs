using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameScript : MonoBehaviour {

    public void ExitGameBtn ()
    {
        Application.Quit();
        Debug.Log("Nice");
    }
}
