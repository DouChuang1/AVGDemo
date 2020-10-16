using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public AVGMachine machine;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update () {
	
        if(Input.GetMouseButtonDown(0))
        {
            machine.UserClicked();
        }
	}

    public void StartAVG(story01 s,AVGAssetConfig team)
    {
        machine.ac = team;
        machine.data = s;
        machine.StartAVG();
    }
}
