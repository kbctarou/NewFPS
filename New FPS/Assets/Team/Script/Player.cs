using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    enum ModeState { Move = 0,Battle};
    private ModeState m_ModeState = ModeState.Move;  // 移動中、バトル中。
    private bool m_IsRotation = false;  // プレイヤーが回転中か。
    public GameObject m_BulletOriginal;
    public GameObject m_BulletSEOriginal;
    InputComponent m_Input = new KeyBoardComponent();
    float RotationSpeed = 20.0f;    // 弾の射角の回転速度。
    Quaternion m_ShotQuat = new Quaternion();  // 弾の射角。
    Quaternion m_PrevRotation;  // 回転補間するときに回転前のクォータニオンを保存するための入れ物。
    Quaternion m_TargetRotation;    // 回転補間するときの目標点。
    float m_RotaSpeed = 0.1f;   // プレイヤーの回転速度。
    float m_RotaCounter = 0.0f; // 回転処理に使用。
    Vector3 m_Direction = new Vector3(0.0f, 0.0f, 1.0f);    // プレイヤーの向きベクトル。
    public Vector3 Direction
    {
        get { return m_Direction; }
    }

    [SerializeField]
    private float m_MoveSpeed = 1.0f;

    private List<CourceDef> m_NowCource = new List<CourceDef>(); // 現在衝突しているコース定義(二つのコース定義に重なった場合に対応)。
    public List<CourceDef> NowCource
    {
     get{
            return m_NowCource;
        }
    }

    // Use this for initialization
    void Start()
    {
        m_Direction = transform.forward;  // プレイヤーの向きベクトル取得。
        m_ShotQuat = Quaternion.FromToRotation(transform.forward, m_Direction); // 射角をプレイヤーの向きベクトルにする。
        //m_TargetRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update () {
        // 弾の射角調整関数。
        ShotDirAdjustment();
        // 状況に応じた行動。
        PlayerAction();
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
    // ※CouceRangeのコールバック関数にて呼び出し。
    public void ProjectionCourceDef()
    {
        if (m_NowCource.Count == 1)
        {
            Debug.Log("Count1");
            // 現在のコースに射影。
            //Vector3 PrevDirection = m_Direction;
            m_Direction = m_NowCource[0].CourceVecDir;
            m_PrevRotation = transform.localRotation;
            m_TargetRotation = transform.localRotation * Quaternion.FromToRotation(/*PrevDirection*/transform.forward, m_Direction);
            m_ShotQuat *= m_TargetRotation;    // 弾の射角をプレイヤーが回転した分回す。
            m_IsRotation = true;
            m_RotaCounter = 0.0f;
        }
        else if (m_NowCource.Count == 2)
        {
            Debug.Log("Count2");
            // コースが重なったとき。
            //Vector3 PrevDirection = m_Direction;
            Vector3 Vec1 = m_NowCource[0].CourceVecDir;
            Vector3 Vec2 = m_NowCource[1].CourceVecDir;
            // ハーフベクトル算出。
            m_Direction = Vector3.Normalize(Vec1 + Vec2);
            m_PrevRotation = transform.localRotation;
            m_TargetRotation = transform.localRotation * Quaternion.FromToRotation(/*PrevDirection*/transform.forward, m_Direction);
            m_ShotQuat *= m_TargetRotation;    // 弾の射角をプレイヤーが回転した分回す。
            m_IsRotation = true;
            m_RotaCounter = 0.0f;
        }
        else
        {
            // 完全にコースを外れた場合。
            m_MoveSpeed = 0.0f;
        }
    }

    // 状況に応じた行動関数。
    private void PlayerAction()
    {
        switch (m_ModeState)
        {
            case ModeState.Move:
                // 移動
                Move();
                break;
            case ModeState.Battle:
                // バトル中。
                break;
        }
    }

    private void Move()
    {
        if (m_IsRotation)
        {
            m_RotaCounter += m_RotaSpeed;
            // 現在の向きから目標の向きベクトルまで回転させる。
            transform.localRotation = Quaternion.Lerp(m_PrevRotation,m_TargetRotation, m_RotaCounter);
            //transform.localRotation *= Quaternion.FromToRotation(transform.forward, m_Direction);
            Debug.Log(Mathf.Abs(Quaternion.Angle(transform.localRotation, m_TargetRotation)));
            if (Mathf.Abs(Quaternion.Angle(transform.localRotation, m_TargetRotation)) <= 0.0001f)
            {
                // 回転終了か。
                Debug.Log("回転終了。");
                m_IsRotation = false;
            }
        }
        else
        {
            // プレイヤーの向きに移動量をかけて加算。
            transform.localPosition += transform.forward * m_MoveSpeed;
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

        // 回転量を保存。
        m_ShotQuat = quat;
    }
}
