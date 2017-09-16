using UnityEngine;
using System.Collections;

public class SContinue : MonoBehaviour
{
    public UISprite HeartSprite;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (HeartSprite.fillAmount >= 0f)
        {
            HeartSprite.fillAmount -= 0.01f;
        }

        if (HeartSprite.fillAmount == 0f)
        {
            HGameMng.I.bCountinueCheck = true;
            HeartSprite.fillAmount = 1f;
        }
    }
}
