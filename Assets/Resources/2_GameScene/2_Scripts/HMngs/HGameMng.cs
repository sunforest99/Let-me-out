using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using MHomiLibrary;

enum E_Time
{
    E_SCORE_TIME,
    E_EFFECT_TIME,
    E_TEXT_TIME,
    E_MAX
}

public class HGameMng : HSingleton<HGameMng>
{
    protected HGameMng() { }
    void Awake()
    {
        if (m_Instance == null)
            m_Instance = this;
        else
            Destroy(gameObject);
    }

    [HideInInspector]
    public int nScore;
    public int nRandObejct;
    public int nWallCount;
    public int nPlayerSpeed;
    public int nHeartCount;

    public bool bPlayerDie;
    public bool bPuaseCheck;
    public bool bGameStartCheck;
    public bool bCameraCheck;
    public bool bCountinueCheck;
    public bool bEffectCheck;
    public bool bPlayerMoveCheck;
    public bool Check;

    public SBackGround BackgroundScrp;

    public UILabel ScoreLable;

    public Camera HGameCam = null;

    float[] fGetTime = new float[(int)E_Time.E_MAX];

    void Start()
    {

    }

    void Update()
    {
        if (bPlayerDie == true)
        { 
            if (bGameStartCheck == false)
            {
                BackgroundScrp.TouchtoStart();
            }
            if (bGameStartCheck == true)
            {
                if (TimeCtrl((int)E_Time.E_SCORE_TIME, 0.15f))
                {
                    nScore++;
                }
            }
            ScoreLable.text = " " + nScore;
        }
    }

    void OnDestroy()
    {
        Debug.Log("OnDestroy()/HGameMng.cs");
    }

    public bool TimeCtrl(int nIndex, float fDelTime)
    {
        if (fGetTime[nIndex] + fDelTime <= Time.time)
        {
            fGetTime[nIndex] = Time.time;
            return true;
        }
        else
            return false;
    }
}
