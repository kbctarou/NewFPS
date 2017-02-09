using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CourceRange : MonoBehaviour {
    CourceDef m_Def = null;
    List<GameObject> m_Enemys = new List<GameObject>();

    public void RemoveEnemyList(GameObject Object)
    {
        m_Enemys.Remove(Object);
    }

    // Use this for initialization
    void Start () {
        m_Def = gameObject.transform.parent.gameObject.GetComponent<CourceDef>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(m_Enemys.Count <= 0)
        {
            m_Def.IsBattlle = false;
        }else
        {
            m_Def.IsBattlle = true;
        }
	}
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // 当たったものがプレイヤーならコース定義の情報を渡す。
            Player player = collider.GetComponent<Player>();
            player.NowCource.Add(m_Def);
            player.ProjectionCourceDef();
        }
        else if(collider.gameObject.tag == "Enemy")
        {
            collider.gameObject.GetComponent<Enemy>().NowCourceNo = m_Def.CourceNo;
            collider.gameObject.GetComponent<Enemy>().CRange = this;
            m_Enemys.Add(collider.gameObject);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // 外れたものがプレイヤーならコース定義の情報を削除。
            Player player = collider.GetComponent<Player>();
            player.NowCource.Remove(m_Def);
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
