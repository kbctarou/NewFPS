﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public enum EnemyState { Wait = 0, Move ,Attack,Falter};
    public int m_HP;       // ヒットポイント。
    //Animator EnemyAnimator = null;
    public EnemyState m_State;      // エネミーの状態。
    public float m_MoveSpeed;  // 移動速度。
    GameObject m_Player = null;
    // Use this for initialization
    void Start () {
        m_HP = 5;
        m_MoveSpeed = 0.0f;
        //EnemyAnimator = GetComponent<Animator>();
        m_State = EnemyState.Wait;
        m_Player = GameObject.Find("Main Camera");
    }
	
	// Update is called once per frame
	void Update () {
        switch (m_State)
        {
            case EnemyState.Wait:
                // 索敵中。
                //EnemyAnimator.SetBool("IsFind", false);
                break;
            case EnemyState.Move:
                // 発見中。
                //EnemyAnimator.SetBool("IsFind", true);
                Vector3 pos = transform.localPosition;
                Vector3 EnemyToPlayerVec = m_Player.transform.localPosition - pos;
                EnemyToPlayerVec.Normalize();
                pos += EnemyToPlayerVec * m_MoveSpeed;
                transform.localPosition = pos;
                break;
            case EnemyState.Attack:
                //this.SetTrigger("IsAttack");
                break;
            case EnemyState.Falter:
                //怯み。
                //this.SetTrigger("IsFalter"): 
                break;
        }
	}

    // 当たった瞬間呼ばれるコールバック関数。
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Bullet>())
        {
            // 当たった対象がBulletならBulletComponentがNullにはならない。
            // 暫定処理。
            if (m_HP <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                m_HP--;
                m_State = EnemyState.Falter;
            }
        }
    }

    ///
    IEnumerator _SetTrigger(string name)
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool(name, true);
        yield return new WaitForSeconds(0);
        animator.SetBool(name, false);
    }
    /// <summary>
    /// フラグのトリガー設定。
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    void SetTrigger(string name)
    {
        StartCoroutine(_SetTrigger(name));
    }
}
