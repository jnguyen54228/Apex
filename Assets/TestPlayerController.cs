using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestPlayerController : NetworkBehaviour {

    void Start() {
        if (!isServer) { 
        
            CmdChangeName("Player 2");
        }
        else if (isServer) {
            RpcUpdateName("Player 1");
        }

    }

    void Update() {
        if (TestCubeScript.button1Press == true) {
            if (!isServer) {
                CmdMoveCube(new Vector2(transform.position.x, transform.position.y + 1));
                TestCubeScript.button1Press = false;
            }
            else {
                RpcUpdateCube(new Vector2(transform.position.x, transform.position.y + 1));
                TestCubeScript.button1Press = false;
            }
        }
    }

    [Command]
    void CmdMoveCube(Vector2 pos) {
        RpcUpdateCube(pos);
    }

    [ClientRpc]
    void RpcUpdateCube(Vector2 pos)
    {
        transform.position = pos;
    }

    [Command]
    void CmdChangeName(string name) {
        RpcUpdateName(name);
    }

    [ClientRpc]
    void RpcUpdateName(string name) {
        transform.name = name;
    }
}
