using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;

public class RegisterPanel : MonoBehaviour {

    public Transform loginPanelTransform;
    public InputField usernameIF;
    public InputField passwordIF;
    RegisterRequest scriptRegisterRequest;
    public Text hitText;

    // Use this for initialization
    void Start () {
        scriptRegisterRequest = this.GetComponent<RegisterRequest>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnRegisterButtonDown()
    {
        string strUserName = usernameIF.text;
        string strPassword = passwordIF.text;
        if (strUserName == "")
        {
            SetHitText("账号不能为空");
        }
        else if (strPassword == "")
        {
            SetHitText("密码不能为空");
        }
        else
        {
            SetHitText("");
            scriptRegisterRequest.UserName = strUserName;
            scriptRegisterRequest.PassWord = strPassword;
            scriptRegisterRequest.DefaultRequest();
        }
        Debug.Log("Register U:" + strUserName + " P:" + strPassword);
    }

    public void OnBackButtonDown()
    {
        usernameIF.text = "";
        passwordIF.text = "";
        this.gameObject.SetActive(false);
        loginPanelTransform.gameObject.SetActive(true);
    }

    private void SetHitText(string strText)
    {
        hitText.text = strText;
    }

    public void OnRegisterResponse(ReturnCode returnCode)
    {
        if (returnCode == ReturnCode.Success)
        {
            SetHitText("注册成功!");
        }
        else
        {
            SetHitText("注册失败!");
        }
    }
}
