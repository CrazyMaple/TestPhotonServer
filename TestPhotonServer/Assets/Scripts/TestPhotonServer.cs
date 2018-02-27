using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using ExitGames.Client.Photon;

public class TestPhotonServer : MonoBehaviour
{
    enum RequestCode
    {
        Test = 0
    };

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(50, 250, 200, 30), "Button1"))
        {
            Debug.Log("BUtton");
            SendRequest();
        }
    }

    void SendRequest()
    {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        data.Add(1, "Maple大鸡鸡");
        PhotonEngine.Peer.OpCustom((int)RequestCode.Test, data, true);
    }


}
