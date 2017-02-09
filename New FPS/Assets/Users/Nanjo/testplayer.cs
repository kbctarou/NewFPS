using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testplayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.localPosition;
		if(Input.GetKey(KeyCode.W))
        {
            pos.z += 0.8f;
            pos.y = Mathf.PingPong(Time.time, 0.1f);
            //transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 0.1f), transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= 0.8f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.z -= 0.8f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += 0.8f;
        }
        transform.localPosition = pos;
    }
}
