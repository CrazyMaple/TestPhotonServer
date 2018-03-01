using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : MonoBehaviour {

    public Transform loginPanelTransform;
    public InputField usernameIF;
    public InputField passwordIF;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnRegisterButtonDown()
    {
        string strUserName = usernameIF.text;
        string strPassword = passwordIF.text;
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
