using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using CommunicationLibrary;
public class TestConnect : MonoBehaviour
{
    public Text login;
    public Text pass;
    public Text pass1;
    public Text email;
    public Text result;
    public Button button;
    private Communication com;
    private void Start()
    {
        button.onClick.AddListener(RegisterButton);
        com = new Communication();
    }

    private void  RegisterButton()
    {
        result.text = com.CreateNewAccRequest(login.text, pass.text, email.text);
    }
}
