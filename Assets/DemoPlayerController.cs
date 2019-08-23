using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DemoPlayerController : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isServer && Input.GetKeyDown(KeyCode.W) && hasAuthority)
        {
            RpcUpdateCube(new Vector2(transform.position.x, transform.position.y + 1));
        }
        else if (!isServer && Input.GetKeyDown(KeyCode.W)) {
            CmdMoveCube(new Vector2(transform.position.x, transform.position.y + 1));
        }
	}

    [Command]
    void CmdMoveCube(Vector2 pos)
    {
        RpcUpdateCube(pos);
    }

    [ClientRpc]
    void RpcUpdateCube(Vector2 pos)
    {
        transform.position = pos;
    }
}
