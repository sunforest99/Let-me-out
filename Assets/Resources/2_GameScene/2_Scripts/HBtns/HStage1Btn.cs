using UnityEngine;
using System.Collections;

public class HStage1Btn : MonoBehaviour {

    public void OnClick()
    {
        HStageMng.I.ChangeScene("HStage1");
        string sNum = "100";
        
    }
}
