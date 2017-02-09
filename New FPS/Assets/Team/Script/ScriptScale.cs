using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        Vector3 Scale = transform.localScale;
        if (Scale.y <= 10.0f)
        {
            Scale.y += 0.1f;
            transform.localScale = Scale;
        }

    }
}
