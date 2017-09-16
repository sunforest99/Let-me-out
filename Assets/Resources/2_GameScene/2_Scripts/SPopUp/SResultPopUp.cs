using UnityEngine;
using System.Collections;

public class SResultPopUp : MonoBehaviour
{
    public GameObject[] ResultGame;

    public GameObject CountinueGame;

    // Use this for initialization
    void Start()
    {
        HGameMng.I.bCameraCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (HGameMng.I.bPlayerDie == false && HGameMng.I.bCountinueCheck == true)
        {
            CountinueGame.SetActive(false);
            transform.localPosition = new Vector3(0f, 0f, 0f);
        }

        if (HGameMng.I.bPlayerDie == true && HGameMng.I.bCameraCheck == false)
        {
            transform.localPosition = new Vector3(-1000f, 0f, 0f);
        }
    }
}
