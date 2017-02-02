using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CourceRange : MonoBehaviour {

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("OnTriggerEnter");
            Debug.Log(gameObject.transform.parent.gameObject.GetComponent<CourceDef>().CourceNo);
            // 当たったものがプレイヤーならコース定義の情報を渡す。
            Player player = collider.GetComponent<Player>();
            player.NowCource.Add(gameObject.transform.parent.gameObject.GetComponent<CourceDef>());
            player.ProjectionCourceDef();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("OnTriggerExit");
            Debug.Log(gameObject.transform.parent.gameObject.GetComponent<CourceDef>().CourceNo);
            // 外れたものがプレイヤーならコース定義の情報を削除。
            Player player = collider.GetComponent<Player>();
            player.NowCource.Remove(gameObject.transform.parent.gameObject.GetComponent<CourceDef>());
            player.ProjectionCourceDef();
        }
    }

    //void OnTriggerStay(Collider collider)
    //{
    //    Debug.Log("OnTriggerStay");
    //    m_OnCollisionObjects.Add(collider.gameObject);
    //}

    //void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("OnCollisionEnter");
    //    m_OnCollisionObjects.Add(collision.gameObject);
    //}

    //void OnCollisionExit(Collision collision)
    //{
    //    Debug.Log("OnCollisionExit");
    //    m_OnCollisionObjects.Remove(collision.gameObject);
    //}

    //void OnCollisionStay(Collision collision)
    //{
    //    Debug.Log("OnCollisionStay");
    //    m_OnCollisionObjects.Add(collision.gameObject);
    //}
}
