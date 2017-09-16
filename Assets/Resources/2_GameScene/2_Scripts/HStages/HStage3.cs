using UnityEngine;
using System.Collections;
using MHomiLibrary;

public class HStage3 : HState {
    
    public override void Enter(params object[] oParams)
    {
        //MAudioPlayMng.I.Play("BGM", true, true);
        Debug.Log("Here is HSate3");
        HStageMng.I.ChangeInfo("현재 스테이지 는 HStage3");
    }

    public override void Execute()
    {

    }

    public override void Exit()
    {

    }

    void OnDestroy()
    {
        //Debug.Log("OnDestroy()/HStage1.cs");
    }
}
