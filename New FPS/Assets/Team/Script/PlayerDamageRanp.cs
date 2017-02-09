using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageRanp : MonoBehaviour {
    Player m_Player = null;
    SpriteRenderer m_SpriteRenderer = null;
    //float m_TimeCounter;
    //[Tooltip("点滅時間(間隔が早くなる前のもの)")]
    //[SerializeField]
    //private float m_IntervalTime;
    //private float m_WorkIntervalTime = 0.0f;
	// Use this for initialization
	void Start () {
        m_Player = GameObject.Find("Player").GetComponent<Player>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        Color c = m_SpriteRenderer.color;
        c.a = 0.0f;
        m_SpriteRenderer.color = c;
	}
	
	// Update is called once per frame
	void Update () {
        Color color = m_SpriteRenderer.color;
        color.a = 1.0f - (m_Player.Hp / m_Player.HpMax);
        m_SpriteRenderer.color = color;
    }
}
