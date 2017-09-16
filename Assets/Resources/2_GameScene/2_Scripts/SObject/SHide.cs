using UnityEngine;
using System.Collections;

public class SHide : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (HGameMng.I.bPlayerMoveCheck == false)
        {
            if (col.tag == "Wall")
            {
                Debug.Log("ASDF");
                HGameMng.I.nWallCount = 1;
                HGameMng.I.nRandObejct = Random.Range(0, 2);
            }

            if (col.tag == "LastWall")
            {
                HGameMng.I.Check = false;
                HGameMng.I.nPlayerSpeed++;
                HGameMng.I.nWallCount = 0;
            }
        }

        if (HGameMng.I.bPlayerMoveCheck == true)
        {
            if (col.tag == "LastWall")
            {
                HGameMng.I.nWallCount = 1;
                HGameMng.I.nRandObejct = Random.Range(0, 2);
            }

            if (col.tag == "Wall")
            {
                HGameMng.I.Check = true;
                HGameMng.I.nPlayerSpeed--;
                HGameMng.I.nWallCount = 0;
            }
        }
    }
}
