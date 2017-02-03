using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UPDOWN : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 0.1f), transform.position.z);
    }
}
