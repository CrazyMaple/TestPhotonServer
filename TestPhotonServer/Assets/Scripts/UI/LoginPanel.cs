using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : MonoBehaviour {

    public Transform registerPanelTransform;
    public InputField usernameIF;
    public InputField passwordIF;
    private LoginRequest scriptLoginRequest;

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
            Debug.Log("账号不能为空");
        }
        else if (strPassword == "")
        {
            Debug.Log("密码不能为空");
        }
        else
        {
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
}
