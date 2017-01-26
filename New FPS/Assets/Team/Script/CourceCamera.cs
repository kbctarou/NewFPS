using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CourceCamera : MonoBehaviour
{
    GameObject m_Player;
    // Use this for initialization
    void Start () {
        m_Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        // 現在のカメラの向きからプレイヤーの向きベクトルまで回転させる。
        transform.localRotation = Quaternion.FromToRotation(transform.forward,m_Player.GetComponent<Player>().Direction);
	}
}
