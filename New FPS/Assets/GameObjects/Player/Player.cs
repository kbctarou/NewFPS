using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    public GameObject m_BulletOriginal;
    public GameObject m_BulletSEOriginal;
    InputComponent m_Input = new KeyBoardComponent();
    float RotationSpeed = 20.0f;
    Quaternion m_ShotQuat = new Quaternion();  // 弾の射角。
    Vector3 m_Direction = new Vector3(0.0f, 0.0f, 1.0f);    // プレイヤーの向きベクトル。
    public Vector3 Direction
    {
        get { return m_Direction; }
    }

    CourceDef m_CourceDef;
    SCourceDef m_NowCource; // 現在衝突しているコース定義。
    bool m_IsInTheNowCource = false;    // 現在のコースのRangeに衝突しているか。

    // Use this for initialization
    void Start()
    {
        //CharacterController CC = GetComponent<CharacterController>();
        m_Direction = transform.forward;  // プレイヤーの向きベクトル取得。
        m_ShotQuat = Quaternion.FromToRotation(transform.forward, m_Direction); // 射角をプレイヤーの向きベクトルにする。
        Debug.Log(m_ShotQuat);

        //m_CourceDef = GameObject.Find("Cource").GetComponent<CourceDef>();  // コース定義取得。
        //m_NowCource = m_CourceDef.FindNowCource(gameObject);    // プレイヤーがいるコースを取得。
        Vector3 PrevDirection = m_Direction;
        //m_Direction = m_NowCource.CourceVecDir;
        m_ShotQuat *= Quaternion.FromToRotation(PrevDirection, m_Direction);    // 弾の射角をプレイヤーが回転した分回す。
    }
    // Update is called once per frame
    void Update () {
        // コース射影処理。
        //ProjectionCourceDef();
        // 弾の射角調整関数。
        ShotDirAdjustment();
        // 弾発射処理。
        if (m_Input.IsTrigger_Space())
        {
            // 弾発射。
            GameObject bullet = Instantiate(m_BulletOriginal);  // 弾の複製を生成。
            bullet.transform.localPosition = transform.localPosition;
            bullet.GetComponent<Bullet>().m_Direction = m_ShotQuat * new Vector3(0.0f,0.0f,1.0f)/*bullet.GetComponent<Bullet>().m_Direction*/;
            Instantiate(m_BulletSEOriginal);    // 曲の複製を生成。
        }
	}

    // コース定義射影関数。
    private void ProjectionCourceDef()
    {
        if (m_NowCource.Range.GetComponent<CourceRange>().FindOnCollisionObject(gameObject))
        {
            // 現在のコースに衝突している。
            return;
        }
        else
        {
            // 現在のコースから外れた。
            Vector3 PrevDirection = m_Direction;
            m_NowCource = m_CourceDef.FindNowCource(gameObject);
            m_Direction = m_NowCource.CourceVecDir;
            m_ShotQuat *= Quaternion.FromToRotation(PrevDirection, m_Direction);    // 弾の射角をプレイヤーが回転した分回す。
        }
    }

    // 弾の射角調整関数。
    private void ShotDirAdjustment()
    {
        Quaternion quat = m_ShotQuat;
        // キー判定。
        if (m_Input.IsPress_Right())
        {
            quat *= Quaternion.AngleAxis(Mathf.Deg2Rad * RotationSpeed, new Vector3(0.0f, 1.0f, 0.0f));
        }
        else if (m_Input.IsPress_Left())
        {
            quat *= Quaternion.AngleAxis(Mathf.Deg2Rad * -RotationSpeed, new Vector3(0.0f, 1.0f, 0.0f));
        }
        if (m_Input.IsPress_Up())
        {
            quat *= Quaternion.AngleAxis(Mathf.Deg2Rad * -RotationSpeed, new Vector3(1.0f, 0.0f, 0.0f));
        }
        else if (m_Input.IsPress_Down())
        {
            quat *= Quaternion.AngleAxis(Mathf.Deg2Rad * RotationSpeed, new Vector3(1.0f, 0.0f, 0.0f));
        }

        Debug.Log(quat);
        // 回転量を保存。
        m_ShotQuat = quat;
    }
}
