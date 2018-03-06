using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Common;

public class RegisterRequest : Request {

    [HideInInspector]
    public string UserName;
    [HideInInspector]
    public string PassWord;

    private RegisterPanel scriptRegisterPanel;
    public override void Start()
    {
        base.Start();
        scriptRegisterPanel = GetComponent<RegisterPanel>();
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
            scriptRegisterPanel.OnRegisterResponse((ReturnCode)operationResponse.ReturnCode);
        }//else 非法请求
        
        //Debug.Log(operationResponse.OperationCode + " RegisterState:" + operationResponse.ReturnCode);
        //string strRegisterState = DictTool.GetValue<byte, object>(operationResponse.Parameters, (byte)ParameterCode.LoginState).ToString();
        //Debug.Log(operationResponse.OperationCode + " RegisterState:" + strRegisterState);
    }
}
