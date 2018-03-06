using ExitGames.Client.Photon;
using UnityEngine;
using System.Collections.Generic;
using Common;
using Common.Tools;

public class LoginRequest : Request {

    [HideInInspector]
    public string UserName;
    [HideInInspector]
    public string PassWord;

    LoginPanel scriptLoginPanel;

    public override void Start()
    {
        base.Start();
        scriptLoginPanel = GetComponent<LoginPanel>();
    }

    public override void DefaultRequest()
    {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        data.Add((byte)ParameterCode.UserName, UserName);
        data.Add((byte)ParameterCode.PassWord, PassWord);
        PhotonEngine.Peer.OpCustom((byte)OpCode, data, true);
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        if ((OperationCode)operationResponse.OperationCode == OpCode)
        {
            scriptLoginPanel.OnLoginResponse((ReturnCode)operationResponse.ReturnCode);
        }//else 非法请求

        //Debug.Log(operationResponse.OperationCode + " LoginState:" + operationResponse.ReturnCode);
        //string strLoginState = DictTool.GetValue<byte, object>(operationResponse.Parameters, (byte)ParameterCode.LoginState).ToString();
        //Debug.Log(operationResponse.OperationCode + " LoginState:" + strLoginState);
    }


}
