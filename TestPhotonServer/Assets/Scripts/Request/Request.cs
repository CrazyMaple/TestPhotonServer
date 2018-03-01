using UnityEngine;
using Common;
using ExitGames.Client.Photon;

public abstract class Request : MonoBehaviour {

    public OperationCode OpCode;
    public abstract void DefaultRequest();
    public abstract void OnOperationResponse(OperationResponse operationResponse);

    // Use this for initialization
    void Start () {
        PhotonEngine.Instance.AddRequest(this);
	}

    private void OnDestroy()
    {
        PhotonEngine.Instance.RemoveRequest(this);
    }
}
