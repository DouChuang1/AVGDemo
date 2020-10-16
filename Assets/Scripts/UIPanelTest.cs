using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelTest : MonoBehaviour {

    public UIPanel uiPanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            uiPanel.ShowCharaA(true);
            uiPanel.ShowContent(true);
            uiPanel.ShowContentBg(true);
            uiPanel.SetContent("Hello");
        }
	}
}
