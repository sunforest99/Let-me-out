using UnityEngine;
using System.Collections;

public class SPausePopUp : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShowPause();
    }

    void ShowPause()
    {
        if (HGameMng.I.bPuaseCheck == true)
        {
            transform.localPosition = new Vector3(0f, 0f, 0f);
        }

        else
        {
            transform.localPosition = new Vector3(0f, 2000f, 0f);
        }
    }
}
