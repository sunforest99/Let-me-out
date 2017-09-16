using UnityEngine;
using System.Collections;

public class SBtnCtrl : MonoBehaviour
{
    public void PuaseBtn()
    {
        HGameMng.I.bPuaseCheck = true;
        Time.timeScale = 0;
    }
    public void AgainBtn()
    {
        Debug.Log("fuck");
        HGameMng.I.bPuaseCheck = false;
        Time.timeScale = 1;
    }

    public void HomeBtn()
    {
        Application.LoadLevel("0_Logoscene");
    }

    public void BackBtn()
    {
        Application.LoadLevel("2_Gamescene");
    }
}
