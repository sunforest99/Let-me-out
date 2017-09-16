using UnityEngine;
using System.Collections;

public class SBackGround : MonoBehaviour
{

    public Camera BgCam;
    public UILabel StartLabel;
    public ParticleSystem Effectparticle;
    public GameObject GoGame;
    public SContinueGroup CountinueScrp;

    void Awake()
    {
        BgCam.backgroundColor = new Color(0.34f, 0.71f, 0.34f);
    }
    // Use this for initialization
    void Start()
    {
        StartLabel.enabled = true;
        Time.timeScale = 0;
        HGameMng.I.bPlayerDie = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (HGameMng.I.bPlayerDie == false)
        {
            HeroDIe();
        }

        if (HGameMng.I.bPlayerDie == true)
        {
            HGameMng.I.bEffectCheck = false;
            BgCam.fieldOfView = 80f;
        }
    }

    void HeroDIe()
    {
        if (BgCam.fieldOfView >= 50f)
        {
            BgCam.fieldOfView -= 1f;
        }
        if (HGameMng.I.TimeCtrl((int)E_Time.E_EFFECT_TIME, 1f) && BgCam.fieldOfView <= 50f)
        {
            HGameMng.I.bCameraCheck = true;
            if (HGameMng.I.nHeartCount != 0)
                CountinueScrp.ShowCountinueScene();
            Effectparticle.Stop();
            Effectparticle.Clear();
        }

    }

    public void TouchtoStart()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GoGame.SetActive(true);
            StartLabel.enabled = false;
            Time.timeScale = 1;
            HGameMng.I.bGameStartCheck = true;
            HGameMng.I.bPuaseCheck = false;
        }
    }
}
