using UnityEngine;
using System.Collections;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

public class Bt_panel : MonoBehaviour
{
    public BluetoothLib bt;
    public Dropdown drop_ports;
    public InputField in_message;

    private void Start()
    {
        bt = FindObjectOfType<BluetoothLib>();
    }

    public void connect()
    {
        bt.connect(drop_ports.options[drop_ports.GetComponent<Dropdown>().value].text);
    }

    public void disconnect()
    {
        bt.disconnect();
    }
    

    public void send()
    {
        bt.send(in_message.text);

    }

    public void sendB(string str)
    {
        bt.send(str);
        Debug.Log(str + "sent");
    }

    public void scan()
    {
        drop_ports.ClearOptions();
        drop_ports.AddOptions(bt.getPortNames());
    }

    public void go_to_room()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //DontDestroyOnLoad(bt);
    }
    
}