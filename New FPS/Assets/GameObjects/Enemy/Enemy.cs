using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    enum EnemyState { Wait = 0, Move ,Attack};
    Animator EnemyAnimator = null;
    EnemyState m_State = new EnemyState();      // エネミーの状態。
    float m_MoveSpeed = new float();  // 移動速度。
    GameObject m_Player = null;
    // Use this for initialization
    void Start () {
        m_MoveSpeed = 0.0f;
        EnemyAnimator = GetComponent<Animator>();
        m_State = EnemyState.Move;
        m_Player = GameObject.Find("Main Camera");
    }
	
	// Update is called once per frame
	void Update () {
        switch (m_State)
        {
            case EnemyState.Wait:
                // 索敵中。
                EnemyAnimator.SetBool("IsFind", false);
                break;
            case EnemyState.Move:
                // 発見中。
                EnemyAnimator.SetBool("IsFind", true);
                m_MoveSpeed = 0.5f;
                Vector3 pos = transform.localPosition;
                Vector3 EnemyToPlayerVec = m_Player.transform.localPosition - pos;
                EnemyToPlayerVec.Normalize();
                pos += EnemyToPlayerVec * m_MoveSpeed;
                transform.localPosition = pos;
                break;
            case EnemyState.Attack:
                this.SetTrigger("IsAttack");
                break;
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
