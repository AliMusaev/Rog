using CommunicationLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoginMenu : MonoBehaviour
{
    [SerializeField] private InputField _login;
    [SerializeField] private InputField _password;
    [SerializeField] private Text _resutlText;
    [SerializeField] private Button _loginButton;
    [SerializeField] private Button _regButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _regPrefab;
    private Communication communication;
    void Start()
    {
        _regButton.onClick.AddListener(GenerateRegMenu);
        _loginButton.onClick.AddListener(TryToLogin);
        communication = new Communication();
    }


    private void GenerateRegMenu()
    {
        Instantiate(_regPrefab, this.gameObject.transform, false);
    }
    private void TryToLogin()
    {
        int retMessage;
        string retVal = communication.LoginRequest(_login.text, _password.text, out retMessage);
        
        if (retMessage != -1)
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            _resutlText.text = retVal;
        }
    }
}
