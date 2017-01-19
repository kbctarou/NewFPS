using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CourceRange : MonoBehaviour {
    public bool IsEndNode;  // コース定義の終端か？

    List<GameObject> m_OnCollisionObjects = new List<GameObject>();  // 自分のRangeに衝突しているオブジェクトを記録する。

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("OnTriggerEnter");
        m_OnCollisionObjects.Add(collider.gameObject);
    }

    void OnTriggerExit(Collider collider)
    {
        Debug.Log("OnTriggerExit");
        m_OnCollisionObjects.Remove(collider.gameObject);
    }

    void OnTriggerStay(Collider collider)
    {
        Debug.Log("OnTriggerStay");
        m_OnCollisionObjects.Add(collider.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        m_OnCollisionObjects.Add(collision.gameObject);
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit");
        m_OnCollisionObjects.Remove(collision.gameObject);
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("OnCollisionStay");
        m_OnCollisionObjects.Add(collision.gameObject);
    }


    // 検索したオブジェクトが存在するか。
    public bool FindOnCollisionObject(GameObject obj)
    {
        int a = new int();
        a = m_OnCollisionObjects.Count;
        Debug.Log(a);
        foreach(var Object in m_OnCollisionObjects)
        {
            Debug.Log("検索中。\n");
            if(obj == Object)
            {
                Debug.Log("検索結果、オブジェクトあり。\n");
                return true;
            }
        }
        Debug.Log("検索結果、オブジェクトなし。\n");
        return false;
    }
}
