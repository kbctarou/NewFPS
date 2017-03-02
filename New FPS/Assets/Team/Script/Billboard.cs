using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

    private GameObject m_TargetCamera = null;
    public GameObject TargetCamera
    {
       
        set { Debug.Log("カメラセット"); m_TargetCamera = value; }
    }

    // Use this for initialization
    void Start () {        
        //Vector3 target = m_TargetCamera.transform.position;
        //transform.LookAt(target);
        //transform.localRotation *= Quaternion.AngleAxis(90.0f, new Vector3(1.0f, 0.0f, 0.0f));
        //m_IsRotate = false;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rota = m_TargetCamera.transform.rotation;
        Quaternion rotaInv = /*Quaternion.Inverse(*/rota/*)*/;
        transform.rotation = rotaInv;
        transform.rotation *= Quaternion.AngleAxis(-90.0f, new Vector3(1.0f, 0.0f, 0.0f));
    }
}
