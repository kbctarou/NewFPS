using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NUM : MonoBehaviour {
    public Text numText;
    private int num = 0;
	// Use this for initialization
	void Start () {
        numText.text = "0";
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
