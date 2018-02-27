using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ExitGames.Client.Photon;

public class PhotonEngine : MonoBehaviour, IPhotonPeerListener {

    enum RequestCode
    {
        Test = 0
    };

    #region Instance
    private static PhotonEngine Instance;
    #endregion
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
    }

    private static PhotonPeer peer;
    public static PhotonPeer Peer
    {
        get
        {
            return peer;
        }
    }
    // Use this for initialization
    void Start () {
        peer = new PhotonPeer(this, ConnectionProtocol.Udp);//Photon保证UDP也是有序可靠的
        peer.Connect("127.0.0.1:5055", "GamePhotonServer");
	}
	
	// Update is called once per frame
	void Update () {
        peer.Service();//心跳包 处理请求的
	}

    void OnDestroy()
    {
        if (peer != null && peer.PeerState == PeerStateValue.Connected)
        {
            peer.Disconnect();
        }
    }

    public void DebugReturn(DebugLevel level, string message)
    {
        throw new System.NotImplementedException();
    }

    //服务端主动发送数据至客户端
    public void OnEvent(EventData eventData)
    {
        switch (eventData.Code)
        {
            case 1:
                {
                    Debug.Log("收到事件1：" + eventData.Parameters[1]);
                }
                break;
            default:break;
        }
    }

    //发送请求后服务端的响应
    public void OnOperationResponse(OperationResponse operationResponse)
    {
        switch ((RequestCode)operationResponse.OperationCode)
        {
            case RequestCode.Test:
                {
                    Debug.Log(operationResponse.Parameters[1].ToString());
                }
                break;
            default:break;
        }
    }

    //状态发生改变
    public void OnStatusChanged(StatusCode statusCode)
    {
        switch (statusCode)
        {

            case StatusCode.Connect:

                Debug.Log("Connect Success!");

                break;

            case StatusCode.Disconnect:

                Debug.Log("Disconnect!");

                break;

        }
    }
}
