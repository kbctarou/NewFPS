using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public enum EnemyState { Wait = 0, Move ,Attack,Falter};
    public int m_HP;       // ヒットポイント。
    public static int m_enemyDownNum = 0 ;
    Animator EnemyAnimator = null;
    public EnemyState m_State;      // エネミーの状態。
    public float m_MoveSpeed;  // 移動速度。
    GameObject m_Player = null;
    private CourceRange m_CourceRange = null;
    public CourceRange CRange
    {
        set { m_CourceRange = value; }
    }
    BoxCollider m_Collider;
    // Use this for initialization
    void Start () {
        m_HP = 5;
        m_MoveSpeed = 0.25f;
        EnemyAnimator = GetComponent<Animator>();
        m_State = EnemyState.Wait;
        m_Player = GameObject.Find("Player");
    }
    private int m_NowCourceNo = -1; // 今いるコースのナンバー。
    public int NowCourceNo
    {
        get { return m_NowCourceNo; }
        set { m_NowCourceNo = value; }
    }

	// Update is called once per frame
	void Update () {
        switch (m_State)
        {
            case EnemyState.Wait:
                // 索敵中。
                EnemyAnimator.SetBool("IsFind", false);
                //プレイヤーとの距離判定。遠ければ走ってくる。近くで攻撃
                Dist();
                break;
            case EnemyState.Move:
                // 発見中。
                EnemyAnimator.SetBool("IsFind", true);
                Vector3 pos = transform.position;
                Vector3 EnemyToPlayerVec = m_Player.transform.localPosition - pos;
                EnemyToPlayerVec.Normalize();
                pos += EnemyToPlayerVec * m_MoveSpeed;
                transform.position = pos;
                //プレイヤーとの距離判定。遠ければ走ってくる。近くで攻撃
                Dist();
                break;
            case EnemyState.Attack:
                this.SetTrigger("IsAttack");
                if(!(EnemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.monster2Attack3")))
                {
                    m_State = EnemyState.Wait;
                }
                break;
            case EnemyState.Falter:
                //怯み。
                this.SetTrigger("IsFalter");
                //プレイヤーとの距離判定。遠ければ走ってくる。近くで攻撃
                Dist();
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
                m_CourceRange.RemoveEnemyList(gameObject);
                m_enemyDownNum += 100;
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

    void Dist()
    {
        Vector3 pos = transform.position;
        float dist = Vector3.Distance(m_Player.transform.localPosition, pos);
        if (NowCourceNo == m_Player.GetComponent<Player>().NowCourceNo)
        {
            Debug.Log(dist);
            // 同じコース上にいる。
            if (dist > 2.0f)
            {
                // 距離が遠い。
                m_State = EnemyState.Move;
            }
            else
            {
                // 距離が近い。
                m_State = EnemyState.Attack;
            }
        }
    }

    void OnAttackCollisionEvent()
    {
        GameObject atari = new GameObject();
        atari.transform.localPosition = transform.position;
        m_Collider = atari.AddComponent<BoxCollider>();
        m_Collider.isTrigger = true;
        m_Collider.tag = "DamageCollision";
        Vector3 scale = new Vector3(10.0f, 20.0f, 40.0f);
        m_Collider.size = scale;
    }

    void OnAttackCollisionDestroyEvent()
    {
        Destroy(m_Collider.gameObject);
    }
}
