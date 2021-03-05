using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using CommunicationLibrary;
public class RegistrationMenu : MonoBehaviour
{
    [SerializeField] private Text _login;
    [SerializeField] private Text _password;
    [SerializeField] private Text _confirmPassword;
    [SerializeField] private Text _email;
    [SerializeField] private Text _resutlText;
    [SerializeField] private Button _regButton;
    [SerializeField] private Button _backButton;
    private Communication communication;
    private void Start()
    {
        _regButton.onClick.AddListener(RegistationRequest);
        _backButton.onClick.AddListener(Close);
        communication = new Communication();
    }

    private void  RegistationRequest()
    {
        _resutlText.text = communication.CreateNewAccRequest(_login.text, _password.text, _email.text);
    }
    private void Close()
    {
        Destroy(this.gameObject);
    }
}
