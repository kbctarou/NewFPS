using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NUM : MonoBehaviour {
    public Text numText;
    private int num = 0;
	// Use this for initialization
	void Start () {
        string t;
        t = num.ToString("00000");
        numText.text = "SCORE :" + (t+Enemy.m_enemyDownNum);
	}

    // Update is called once per frame
    void Update()
    {
      
    }

}
