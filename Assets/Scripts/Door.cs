using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public float speed = 0;
    public float maxY=3;

	// Update is called once per frame
	void Update () {
        transform.Translate(0, speed * Time.deltaTime, 0);
        if(transform.position.y>=maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        }
	}

    public void OpenDoor()
    {
        speed = 10;
    }
}
