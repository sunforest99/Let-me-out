using UnityEngine;
using System.Collections;

public class SItem : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (HGameMng.I.Check == false)
        {
            if (col.tag == "Player" && HGameMng.I.bPlayerMoveCheck == false)
            {
                Debug.Log("ASDFASDFASDFASDf");
                HGameMng.I.nWallCount = 0;
                HGameMng.I.nPlayerSpeed = -4;
                HGameMng.I.bPlayerMoveCheck = true;
            }

        }
        if (HGameMng.I.Check == true)
        {
            if (col.tag == "Player" && HGameMng.I.bPlayerMoveCheck == true)
            {
                HGameMng.I.nWallCount = 1;
                HGameMng.I.nPlayerSpeed = 4;
                HGameMng.I.bPlayerMoveCheck = false;
            }
        }
    }
}
