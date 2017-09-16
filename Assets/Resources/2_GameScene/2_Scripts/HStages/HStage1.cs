using UnityEngine;
using System.Collections;
using MHomiLibrary;

public class HStage1 : HState {
    
    public override void Enter(params object[] oParams)
    {
        //MAudioPlayMng.I.Play("BGM", true, true);
        Debug.Log("Here is HSate1");
        HStageMng.I.ChangeInfo("현재 스테이지 는 HStage1");
    }

    public override void Execute()
    {
        //Debug.Log("fuck111");
    }

    public override void Exit()
    {

    }

    void OnDestroy()
    {
        //Debug.Log("OnDestroy()/HStage1.cs");
    }
}
