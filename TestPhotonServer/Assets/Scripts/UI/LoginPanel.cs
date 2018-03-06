using UnityEngine;
using UnityEngine.UI;
using Common;

public class LoginPanel : MonoBehaviour {

    public Transform registerPanelTransform;
    public InputField usernameIF;
    public InputField passwordIF;
    private LoginRequest scriptLoginRequest;
    public Text hitText;

    // Use this for initialization
    void Start () {
        scriptLoginRequest = this.GetComponent<LoginRequest>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnLoginButtonDown()
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
            scriptLoginRequest.UserName = strUserName;
            scriptLoginRequest.PassWord = strPassword;
            scriptLoginRequest.DefaultRequest();
        }
        Debug.Log("Login U:" + strUserName + " P:" + strPassword);
    }
    
    public void OnRegisterButtonDown()
    {
        usernameIF.text = "";
        passwordIF.text = "";
        this.gameObject.SetActive(false);
        registerPanelTransform.gameObject.SetActive(true);
    }

    private void SetHitText(string strText)
    {
        hitText.text = strText;
    }

    public void OnLoginResponse(ReturnCode returnCode)
    {
        if (returnCode == ReturnCode.Success)
        {
            SetHitText("登录成功!");
        }
        else
        {
            SetHitText("登录失败!");
        }
    }
}
