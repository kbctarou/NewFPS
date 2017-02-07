using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CourceDef : MonoBehaviour {
    private static int m_CourceCount = 0;
    public int CourceCount
    {
        get { return m_CourceCount; }
    }

    private int m_CourceNo;   // コース定義No。
    public int CourceNo { get { return m_CourceNo; } }
    private Vector3 m_Start;
    public Vector3 Start { get { return m_Start; } }
    private Vector3 m_End;
    public Vector3 End { get { return m_End; } }
    private Vector3 m_CourceVecDir;   // コースの向き。
    public Vector3 CourceVecDir { get { return m_CourceVecDir; } }
    private GameObject m_Range;           // コース定義の範囲。
    public GameObject Range{ get { return m_Range; } }
    [Tooltip("そのノードでバトルがあるか。")]
    [SerializeField]
    private bool m_IsBattle = false;
    public bool IsBattlle
    {
        set { m_IsBattle = value; }
        get { return m_IsBattle; }
    }

    // Use this for initialization
    void OnEnable()
    {
        m_CourceNo = m_CourceCount;
        m_CourceCount++;
        // コース定義の中身(Start,End,Range,Next)を取得。
        Transform[] Childs = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform Child in Childs)
        {
            switch (Child.tag)
            {
                case "CourceStart":
                    m_Start = Child.position;
                    break;
                case "CourceEnd":
                    m_End = Child.position;
                    break;
                case "CourceRange":
                    m_Range = Child.gameObject;
                    m_CourceVecDir = Vector3.Normalize(m_End - m_Start);
                    break;
            }
        }
    }
}
