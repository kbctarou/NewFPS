using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public GameObject m_BulletOriginal;
    public GameObject m_BulletSEOriginal;
    InputComponent m_Input = new KeyBoardComponent();
    float RotationSpeed = 0.3f;
    Vector3 m_ShotDir = new Vector3(0.0f, 0.0f, 1.0f);
	// Use this for initialization
	void Start () {
        CharacterController CC = GetComponent<CharacterController>();
        m_ShotDir = transform.forward;  // プレイヤーの向きベクトル取得。
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion quat = new Quaternion();
        // キー判定。
        if (m_Input.IsPress_Right())
        {
            quat *= Quaternion.AngleAxis(RotationSpeed,new Vector3(0.0f, 1.0f, 0.0f));
        }
        else if (m_Input.IsPress_Left())
        {
            quat *= Quaternion.AngleAxis(-RotationSpeed, new Vector3(0.0f, 1.0f, 0.0f));
        }
        if (m_Input.IsPress_Up())
        {
            quat *= Quaternion.AngleAxis(RotationSpeed, new Vector3(1.0f, 0.0f, 0.0f));
        }
        else if (m_Input.IsPress_Down())
        {
            quat *= Quaternion.AngleAxis(-RotationSpeed, new Vector3(1.0f, 0.0f, 0.0f));
        }


        if (m_Input.IsTrigger_Space())
        {
            GameObject bullet = Instantiate(m_BulletOriginal);  // 弾の複製を生成。
            bullet.transform.localPosition = transform.localPosition;
            Instantiate(m_BulletSEOriginal);    // 曲の複製を生成。
        }
	}
}
