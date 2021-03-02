using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TestConnect : MonoBehaviour
{
    public Text login;
    public Text pass;
    public Text pass1;
    public Text email;
    public Text result;
    public Button button;
    const int port = 61555;
    const string address = "95.31.4.144";  //95.31.4.144
    private void Start()
    {
        button.onClick.AddListener(RegisterButton); 
    }

    private void  RegisterButton()
    {
        TcpClient client = new TcpClient(address, port);
        NetworkStream stream = null;
        try
        {
            stream = client.GetStream();
            // Input
            string message = $"regQ|{login.text}|{pass.text}|{email.text}";
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);


            data = new byte[64]; // буфер для получаемых данных
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            bytes = stream.Read(data, 0, data.Length);
            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            result.text = builder.ToString();
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
        finally
        {
            if (client != null)
                client.Close();
        }
    }
}
