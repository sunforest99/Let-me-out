using UnityEngine;
using System.Collections;

public class HMenuSceneBtn : MonoBehaviour
{

    //public void asdf()
    //{
    //    HMng.I.nCarNum = 0;
    //    HSoundMng.I.Play("Tap");
    //    Application.LoadLevel("2_Gamescene");
    //}
    public void GamePlayer()
    {
        HMng.I.nCarNum = 0;
        Application.LoadLevel("2_Gamescene");
    }

    public void Bike()
    {
        HMng.I.nCarNum = 1;
        Application.LoadLevel("2_Gamescene");
    }

    public void Car()
    {
        HMng.I.nCarNum = 2;
        Application.LoadLevel("2_Gamescene");
    }
}
