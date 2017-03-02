using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CourceCamera : MonoBehaviour
{
    private Player m_Player;
    // Use this for initialization
    void Start () {
        m_Player = GameObject.Find("Player").GetComponent<Player>();
       // m_Player.GetComponent<Player>().ShotCursor.GetComponent<Billboard>().TargetCamera = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = m_Player.transform.localPosition;
        transform.localRotation = m_Player.transform.localRotation;
	}
}
