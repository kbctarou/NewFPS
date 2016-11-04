using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour {
    enum Scenes {Title = 0,Game,Result,Max};
    string[] SceneNames;
    static int NextScene = (int)Scenes.Game;
	// Use this for initialization
	void Start () {
        SceneNames = new string[(int)Scenes.Max];
        SceneNames[(int)Scenes.Title] = "TitleScene";
        SceneNames[(int)Scenes.Game] = "GameScene";
        SceneNames[(int)Scenes.Result] = "ResultScene";
    }
	
	// Update is called once per frame
	void Update () {
        // 暫定処理。
        // 後で変更。
        if (Input.GetKey(KeyCode.A))
        {
            SceneManager.LoadScene(SceneNames[NextScene]);
            NextScene++;
            if (NextScene >= (int)Scenes.Max)
            {
                NextScene = (int)Scenes.Title;
            }
        }
    }
}
