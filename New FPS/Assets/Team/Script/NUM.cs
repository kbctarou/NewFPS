using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NUM : MonoBehaviour {
    public Text numText;
    private int num = 0;
	// Use this for initialization
	void Start () {
        string t;
        num += Enemy.m_enemyDownNum;
        t = num.ToString("00000");
        numText.text = "SCORE :" + t;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }

}
