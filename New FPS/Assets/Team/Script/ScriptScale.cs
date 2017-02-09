using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptScale : MonoBehaviour {

    //スケール拡大完了
    private bool m_IsScale;
    public bool IsScale
    {
        get { return m_IsScale; }
    }

	// Use this for initialization
	void Start () {
        m_IsScale = false;
    }

    void Update()
    {
        Vector3 Scale = transform.localScale;
        if (Scale.y <= 5.0f)
        {
            Scale.y += 0.1f;
            transform.localScale = Scale;
        }
        else if(Scale.y >= 5.0f && m_IsScale == false)
        {
            m_IsScale = true;
        }

    }
}
