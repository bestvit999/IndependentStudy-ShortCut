using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            go_to_btPanel();
        }
    }

    public void go_to_btPanel()
    {
        SceneManager.LoadScene("bluetooth_panel");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //DontDestroyOnLoad(bt);
    }
}
