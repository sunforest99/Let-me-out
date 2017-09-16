using UnityEngine;
using System.Collections;

public class SContinueGroup : MonoBehaviour
{
    public GameObject HeartGame;
 
    public UISprite HeartSprite;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (HGameMng.I.bPlayerDie == true)
        {
            HeartSprite.fillAmount = 1f;
            HeartGame.SetActive(false);
            transform.localPosition = new Vector3(1000f, 0f, 0f);
        }

        if (HGameMng.I.nHeartCount == 0)
        {
            HGameMng.I.bCountinueCheck = true;
        }
    }

    public void ShowCountinueScene()
    {
        HeartGame.SetActive(true);
        transform.localPosition = new Vector3(0f, 0f, 0f);
    }
}
