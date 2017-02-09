using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float m_AddPower = 0.0f;
    public Vector3 m_Direction = new Vector3(0.0f, 0.0f, 1.0f);

	// Use this for initialization
	void Start () {
        // レイヤーを使って弾とプレイヤーは当たり判定を行わないように設定する。
        {
            int Layer1 = LayerMask.NameToLayer("Bullet");
            int Layer2 = LayerMask.NameToLayer("Player");
            Physics.IgnoreLayerCollision(Layer1, Layer2);
        }
        Vector3 Force = m_Direction * m_AddPower;
        Rigidbody RB = GetComponent<Rigidbody>();
        RB.AddForce(Force);
    }

    // Update is called once per frame
    void Update () {
        MeshRenderer MR = GetComponent<MeshRenderer>();
        if (!MR.isVisible)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Ground" || collider.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
