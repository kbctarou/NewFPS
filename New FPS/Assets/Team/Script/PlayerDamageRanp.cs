using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageRanp : MonoBehaviour {
    Player m_Player = null;
    Image m_Image = null;
    //float m_TimeCounter;
    //[Tooltip("点滅時間(間隔が早くなる前のもの)")]
    //[SerializeField]
    //private float m_IntervalTime;
    //private float m_WorkIntervalTime = 0.0f;
	// Use this for initialization
	void Start () {
        m_Player = GameObject.Find("Player").GetComponent<Player>();
        m_Image = GetComponent<Image>();
        Color c = m_Image.color;
        c.a = 0.0f;
        m_Image.color = c;
	}
	
	// Update is called once per frame
	void Update () {
        Color color = m_Image.color;
        color.a = 1.0f - ((float)m_Player.Hp / (float)m_Player.HpMax);
        m_Image.color = color;
    }
}
