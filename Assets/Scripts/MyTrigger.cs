using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTrigger : MonoBehaviour {

    public story01 data;
    public AVGAssetConfig team;
    public UIManager manager;

    private void OnTriggerEnter(Collider other)
    {
        manager.StartAVG(data, team);
    }
}
