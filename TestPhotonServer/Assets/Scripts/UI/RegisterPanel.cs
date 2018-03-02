using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : MonoBehaviour {

    public Transform loginPanelTransform;
    public InputField usernameIF;
    public InputField passwordIF;
    RegisterRequest scriptRegisterRequest;

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
            Debug.Log("账号不能为空");
        }
        else if (strPassword == "")
        {
            Debug.Log("密码不能为空");
        }
        else
        {
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
}
