using UnityEngine;
using System.Collections;

public class SHeartLabel : MonoBehaviour
{
    public UILabel[] HeartLabel;
    public MeshRenderer PlayerMesh;
    public Transform PlayerTrans;
    public HHeroMove PlayerScrp;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < HeartLabel.Length; i++)
        {
            HeartLabel[i].text = " " + HGameMng.I.nHeartCount;
        }
    }

    public void CountinueBtn()      // i should fix
    {
        if (HGameMng.I.nHeartCount >= 1)
        {
            if (PlayerScrp.bRCheck == true)
            {
                PlayerScrp.bRCheck = false;
                PlayerTrans.transform.localPosition -= new Vector3(PlayerScrp.fMoveLength, 0f, 0f);//transform.right * fMoveLength;
            }

            if (PlayerScrp.bLCheck == true)
            {
                PlayerScrp.bLCheck = false;
                PlayerTrans.transform.localPosition += new Vector3(PlayerScrp.fMoveLength, 0f, 0f);// transform.right * fMoveLength;
            }

            HGameMng.I.nHeartCount--;

            Debug.Log("WTF");
            if (HGameMng.I.nPlayerSpeed > 3)
                HGameMng.I.nPlayerSpeed -= 1;
            PlayerMesh.enabled = true;
            HGameMng.I.bPlayerDie = true;
        }
    }
}
