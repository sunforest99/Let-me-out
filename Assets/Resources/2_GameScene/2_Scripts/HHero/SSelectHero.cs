using UnityEngine;
using System.Collections;

public class SSelectHero : MonoBehaviour {

    public GameObject[] HeroGame;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (HMng.I.nCarNum == 0)
        {
            HeroGame[0].SetActive(true);
        }

        if (HMng.I.nCarNum == 1)
        {
            HeroGame[1].SetActive(true);
        }
        if (HMng.I.nCarNum == 2)
        {
            HeroGame[2].SetActive(true);
        }

    }
}
