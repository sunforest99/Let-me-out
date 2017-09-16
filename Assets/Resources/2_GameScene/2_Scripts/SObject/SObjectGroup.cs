using UnityEngine;
using System.Collections;

public class SObjectGroup : MonoBehaviour
{
    public GameObject[] RObjectGame;

    public GameObject[] LObjectGame;

    // Use this for initialization
    void Start()
    {
        HGameMng.I.nRandObejct = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Create();
        Del();
    }

    void Create()
    {
       if(HGameMng.I.nRandObejct == 0)
        {
            for(int i = 0; i < RObjectGame.Length; i ++)
            {
                RObjectGame[i].GetComponent<MeshRenderer>().enabled = true;
                RObjectGame[i].GetComponent<BoxCollider>().enabled = true;
            }
        }

        if (HGameMng.I.nRandObejct == 1)
        {
            for (int i = 0; i < LObjectGame.Length; i++)
            {
                LObjectGame[i].GetComponent<MeshRenderer>().enabled = true;
                LObjectGame[i].GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    void Del()
    {
        if (HGameMng.I.nWallCount == 0)
        {
            for (int i = 0; i < RObjectGame.Length; i++)
            {
                RObjectGame[i].GetComponent<MeshRenderer>().enabled = false;
                LObjectGame[i].GetComponent<MeshRenderer>().enabled = false;
                RObjectGame[i].GetComponent<BoxCollider>().enabled = false;
                LObjectGame[i].GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
