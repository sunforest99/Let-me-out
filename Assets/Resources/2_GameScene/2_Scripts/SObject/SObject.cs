using UnityEngine;
using System.Collections;

public class SObject : MonoBehaviour
{
    public ParticleSystem PDieParticle;
    public Transform PlayerTrans;
    public AudioSource DieAudio;
    public int nRand;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && HGameMng.I.bPlayerDie == true && HGameMng.I.bEffectCheck == false)
        {
            PDieParticle.transform.localPosition = PlayerTrans.localPosition;

            DieAudio.Play();
            PDieParticle.time = 0;
            PDieParticle.Play();

            HGameMng.I.bPlayerDie = false;
            HGameMng.I.bEffectCheck = true;
        }
    }
}
