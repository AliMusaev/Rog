using CommunicationLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoginMenu : MonoBehaviour
{
    [SerializeField] private Text _login;
    [SerializeField] private Text _password;
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
        string retMessage;
        bool retVal = communication.LoginRequest(_login.text, _password.text, out retMessage);
        
        if (retVal)
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            _resutlText.text = retMessage;
        }
    }
}
