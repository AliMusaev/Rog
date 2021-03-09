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
        string retMessage = null;
        // Check on password matches

        if (LoginCheck() && PasswordCheck() && EmailCheck())
        {
            bool retVal = communication.RegistrationRequest(_login.text, _password.text, _email.text, out retMessage);
            if (retVal)
            {
                Close();
            }
            else
            {
                _resutlText.text = retMessage;
            }
        }
                

           
        
        
    }


    private bool LoginCheck()
    {
        bool retVal = false;
        if (_login.text.Length >= 4 && _login.text.Length <= 24)
        {
            retVal = true;
        }
        else
        {
            _resutlText.text = "Login must be 4 or more characters but not more than 24";
            retVal = false;
        }
        return retVal;
    }
    private bool PasswordCheck()
    {
        bool retVal = false;
        if (string.Equals(_password.text, _confirmPassword.text))
        {
            if (_password.text.Length >= 8 && _password.text.Length <= 24)
            {
                retVal = true;
            }
            else
            {
                _resutlText.text = "Password must be 8 or more characters but not more than 24";
                retVal = false;
            }
        }
        else
        {
            _resutlText.text = "Entered passwords does not match";
            retVal = false;
        }
        return retVal;
    }
    private bool EmailCheck()
    {
        bool retVal = false;
        if (_email.text.Length >= 6 && _email.text.Length <= 50)
        {
            retVal = true;
        }
        else
        {
            _resutlText.text = "Email is short to be true";
            retVal = false;
        }
        return retVal;
    }
    private void Close()
    {
        Destroy(this.gameObject);
    }

  
}
