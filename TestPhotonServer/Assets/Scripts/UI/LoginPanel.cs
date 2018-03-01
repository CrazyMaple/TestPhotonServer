﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : MonoBehaviour {

    public Transform registerPanelTransform;
    public InputField usernameIF;
    public InputField passwordIF;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnLoginButtonDown()
    {
        string strUserName = usernameIF.text;
        string strPassword = passwordIF.text;
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
