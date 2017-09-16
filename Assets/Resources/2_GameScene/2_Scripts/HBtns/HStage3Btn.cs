using UnityEngine;
using System.Collections;

public class HStage3Btn : MonoBehaviour {

    public void OnClick()
    {
        HStageMng.I.ChangeScene("HStage3");
    }
}
