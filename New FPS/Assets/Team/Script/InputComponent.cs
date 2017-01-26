using UnityEngine;
using System.Collections;

public class InputComponent : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    // 押しっぱなし判定。
    public virtual bool IsPress_Up() { return false; }
    public virtual bool IsPress_Down() { return false; }
    public virtual bool IsPress_Right() { return false; }
    public virtual bool IsPress_Left() { return false; }
    public virtual bool IsPress_Return() { return false; }
    public virtual bool IsPress_Space() { return false; }
    public virtual bool IsPress_Cancel() { return false; }
    // 押した瞬間判定。
    public virtual bool IsTrigger_Up() { return false; }
    public virtual bool IsTrigger_Down() { return false; }
    public virtual bool IsTrigger_Right() { return false; }
    public virtual bool IsTrigger_Left() { return false; }
    public virtual bool IsTrigger_Return() { return false; }
    public virtual bool IsTrigger_Space() { return false; }
    public virtual bool IsTrigger_Cancel() { return false; }
}
