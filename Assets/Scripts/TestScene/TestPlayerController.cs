using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestPlayerController : NetworkBehaviour {

    private bool test;

    void Start() {

        test = false;

        if (!isServer && hasAuthority) {
            CmdChangeName("Player 2");
        }
        else if (isServer) {
            RpcUpdateName("Player 1");
        }

    }

    void Update() {

        if (isServer) {
            Debug.Log(test);
        }

        if (TestCubeScript.button1Press == true) {
            if (!isServer && hasAuthority) {
                CmdTest(test);
                CmdMoveCube(new Vector2(transform.position.x, transform.position.y + 1));
                TestCubeScript.button1Press = false;
            }
            else if(isServer){
                RpcUpdateCube(new Vector2(transform.position.x, transform.position.y + 1));
                TestCubeScript.button1Press = false;
            }
        }
    }

    [Command]
    void CmdTest(bool t)
    {
        RpcUpdateTest(t);
    }

    [ClientRpc]
    void RpcUpdateTest(bool y) {
        y = true;
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
