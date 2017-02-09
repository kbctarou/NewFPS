using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleText : MonoBehaviour {
    private const int MAX = 50;
    private int i = 0;
    private int j = 1;
    private Vector3 Scale;
    float time;
	// Use this for initialization
	void Start () {
        Scale.x = 0.0f;
        Scale.y = 0.0f;
        Scale.z = 0.0f;
        Scale = transform.localScale;
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 0.2f)
        {
            if (i >= MAX)
            {
                j *= -1;
            }
            else if (i <= 0)
            {
                j *= -1;
            }
            Scale.x += j;
            Scale.y += j;
            Scale.z += j;
            transform.localScale = Scale;
            i += j;
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
