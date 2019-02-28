using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;
using UnityEngine;

public class BluetoothLib : MonoBehaviour {

    public SerialPort port;
    private List<string> portNames;
    private Thread readThread;

    // 掃描所有 serial prots 且回傳。可將結果放到 dropdown
    public List<string> getPortNames()
    {
        portNames = new List<string>(SerialPort.GetPortNames());
        return portNames;
    }

    // 連接到指定的 prot，如 "COM3"。可用 getPortNames() 取得可用的 portName
    public void connect(string portName)
    {
        port = new SerialPort(portName, 9600);
        port.Open();

    }

    // 解除連接的 port
    public void disconnect()
    {
        if (port.IsOpen)
        {
            port.Close();
        }
    }

    // 傳送資料到已經連接的 port。可用 connect() 連接 port
    public void send(string data)
    {
        if (port == null || port.IsOpen == false)
        {
            throw new System.Exception("No port is connected");
        }

        byte[] bytes_send = Encoding.ASCII.GetBytes(data);
        //port.Write(bytes_send, 0, bytes_send.Length);
        port.Write(data + " ");
        
    }
}
