using UnityEngine;
using System.Collections;
using MHomiLibrary;

public class HStage2 : HState {
    
    public override void Enter(params object[] oParams)
    {
        //MAudioPlayMng.I.Play("BGM", true, true);
        Debug.Log("Here is HSate2");
        HStageMng.I.ChangeInfo("현재 스테이지 는 HStage2");
    }

    public override void Execute()
    {
        
    }

    public override void Exit()
    {

    }

    void OnDestroy()
    {
        //Debug.Log("OnDestroy()/HStage2.cs");
    }
}
