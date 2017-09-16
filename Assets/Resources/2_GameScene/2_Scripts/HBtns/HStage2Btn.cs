using UnityEngine;
using System.Collections;

public class HStage2Btn : MonoBehaviour {

    public void OnClick()
    {
        HStageMng.I.ChangeScene("HStage2");
        
    }
}
