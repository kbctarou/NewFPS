using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float m_MoveSpeed = 0.0f;
    Vector3 m_Direction = new Vector3(0.0f, 0.0f, 1.0f);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.localPosition;
        pos += m_Direction * m_MoveSpeed;
        transform.localPosition = pos;
        MeshRenderer MR = GetComponent<MeshRenderer>();
        if (!MR.isVisible)
        {
            Destroy(gameObject);
        }
	}
}
