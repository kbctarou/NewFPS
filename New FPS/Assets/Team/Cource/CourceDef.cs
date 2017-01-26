using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SCourceDef
{
    public int CourceNo;   // コース定義No。
    public Vector3 Start;
    public Vector3 End;
    public Vector3 CourceVecDir;   // コースの向き。
    public GameObject Range;           // コース定義の範囲。
};

public class CourceDef : MonoBehaviour {
    public List<SCourceDef> m_CourceDefList = new List<SCourceDef>();
    // Use this for initialization
    void OnEnable()
    {

        // 最初のコース定義を取得。
        Transform CourceNode;
        while (true)
        {

            CourceNode = GetComponentInChildren<Transform>();
            if (gameObject != CourceNode.parent)
            {
                // 自分の子供発見。
                break;
            }
        }

        // コース定義の中身(Start,End,Range,Next)を取得。
        Transform[] Childs = CourceNode.GetComponentsInChildren<Transform>();
        SCourceDef WorkCourceDef = new SCourceDef();
        int DefCounter = 0;
        //int WorkCounter = 0;
        //bool IsEnd = false;
        foreach (Transform Child in Childs)
        {
            if (Child.gameObject == CourceNode)
            {
                // 一番上の親は無視。
                Debug.Log("最上位の親ノードを無視。\n");
                //continue;
            }
            Debug.Log("いずれかの子ノードを発見。\n");
            switch (Child.tag)
            {
                case "CourceStart":
                    Debug.Log("Start出力。\n");
                    WorkCourceDef.Start = Child.position;
                    break;
                case "CourceEnd":
                    Debug.Log("End出力。\n");
                    WorkCourceDef.End = Child.position;
                    break;
                case "CourceRange":
                    Debug.Log("Range出力。\n");
                    WorkCourceDef.Range = Child.gameObject;
                    Debug.Log("次ノードへ移行。\n");
                    // 次のノードに進むとき。
                    WorkCourceDef.CourceVecDir = Vector3.Normalize(WorkCourceDef.End - WorkCourceDef.Start);
                    WorkCourceDef.CourceNo = DefCounter;
                    DefCounter++;
                    m_CourceDefList.Add(WorkCourceDef);
                    //if (Child.GetComponent<CourceRange>().IsEndNode)
                    //{
                    //    IsEnd = true;
                    //}
                    break;
            }
            //WorkCounter++;
            //if (WorkCounter >= 4 || IsEnd)
            //{
            //    //Debug.Log("次ノードへ移行。\n");
            //    //// 次のノードに進むとき。
            //    //WorkCourceDef.CourceVecDir = Vector3.Normalize(WorkCourceDef.End - WorkCourceDef.Start);
            //    //WorkCourceDef.CourceNo = DefCounter;
            //    //DefCounter++;
            //    //m_CourceDefList.Add(WorkCourceDef);
            //    WorkCounter = 0;
            //}
        }
        Debug.Log("コース定義、構成終了。\n");
    }

    

    // Update is called once per frame
    void Update () {
	
	}

    // 渡された情報でどのコース定義にいるか判定する。
    public SCourceDef FindNowCource(GameObject obj)
    {
        foreach (var Cource in m_CourceDefList)
        {
            if (Cource.Range.GetComponent<CourceRange>().FindOnCollisionObject(obj))
            {
                Debug.Log("コース返却。\n");
                return Cource;
            }

        }
        Debug.Log("検索結果、null\n");
        return null;
    }
}
