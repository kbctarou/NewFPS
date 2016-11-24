using UnityEngine;
using System.Collections;

public class KeyBoardComponent : InputComponent {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    // 押しっぱなし判定。
    public override bool IsPress_Up(){
        if (Input.GetKey(KeyCode.UpArrow))
        {
            return true;
        }
        return false;
    }
    public override bool IsPress_Down()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            return true;
        }
        return false;
    }
    public override bool IsPress_Right()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            return true;
        }
        return false;
    }
    public override bool IsPress_Left()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return true;
        }
        return false;
    }
    public override bool IsPress_Return()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            return true;
        }
        return false;
    }
    public override bool IsPress_Space()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            return true;
        }
        return false;
    }
    // 押した瞬間判定。
    public override bool IsTrigger_Up()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return true;
        }
        return false;
    }
    public override bool IsTrigger_Down()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return true;
        }
        return false;
    }
    public override bool IsTrigger_Right()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            return true;
        }
        return false;
    }
    public override bool IsTrigger_Left()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return true;
        }
        return false;
    }
    public override bool IsTrigger_Return()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            return true;
        }
        return false;
    }
    public override bool IsTrigger_Space()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        return false;
    }
}
