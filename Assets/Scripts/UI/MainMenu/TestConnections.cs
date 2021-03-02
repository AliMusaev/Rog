using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TestConnections : MonoBehaviour
{
    const int port = 8888;
    const string address = "127.0.0.1";
    public Text tet;
    public Button but;
    void Start()
    {
        but.onClick.AddListener(pip);
        
        
        
    }

    // Update is called once per frame
    void pip()
    {
        TcpClient client = null;
        try
        {
            
            client = new TcpClient(address, port);
            
            NetworkStream stream = client.GetStream();

                var message = string.Format("a1|0132|lol@mail.ru|loginsukd|pass|");
                byte[] data = Encoding.Unicode.GetBytes(message);
                // отправка сообщения
                stream.Write(data, 0, data.Length);

                // получаем ответ
                data = new byte[64]; // буфер для получаемых данных
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                bytes = stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                message = builder.ToString();
            tet.text = message;

        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
        finally
        {
            client.Close();
        }
    }
}
