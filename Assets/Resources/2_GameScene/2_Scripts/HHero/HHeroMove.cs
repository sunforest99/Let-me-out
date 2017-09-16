using UnityEngine;
using WhiteCat.Paths;
using System.Collections;

public class HHeroMove : MonoBehaviour
{
    public Vector3 WayVec;
    public Camera TouchCam;
    public MoveAlongPath PlayerMove;
    public float fMoveLength = 500f;
    public MeshRenderer PlayerMesh;
    public bool bRCheck;
    public bool bLCheck;

    // Use this for initialization
    void Start()
    {
        HGameMng.I.nPlayerSpeed = 3;
    }

    // Update is called once per frame
    void Update()
    {

        if (HGameMng.I.bPlayerDie == false)
        {
            if (bRCheck == true)
            {
                bRCheck = false;
                if(HMng.I.nCarNum == 0)
                transform.localPosition -= new Vector3(fMoveLength, 0f, 0f);

                if (HMng.I.nCarNum != 0)
                    transform.localPosition += new Vector3(0f, 0f, fMoveLength);

            }
            if (bLCheck == true)
            {
                bLCheck = false;
                if (HMng.I.nCarNum == 0)
                    transform.localPosition += new Vector3(fMoveLength, 0f, 0f);
                if (HMng.I.nCarNum != 0)
                    transform.localPosition -= new Vector3(0f, 0f, fMoveLength);
            }
            PlayerMove.speed = 0;

            PlayerMesh.enabled = false;
        }
        if (HGameMng.I.bPlayerDie == true)
        {
            Move();
        }
    }

    void Move()
    {
        PlayerMesh.enabled = true;
        PlayerMove.speed = HGameMng.I.nPlayerSpeed;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && HGameMng.I.bPuaseCheck == false)
        {
            if (bLCheck == false)
            {
                //transform.rotation = Quaternion.AngleAxis(WayVec.y, transform.localPosition);
                bLCheck = true;
                if(HMng.I.nCarNum == 0)
                transform.localPosition -= new Vector3(fMoveLength, 0f, 0f);

                if (HMng.I.nCarNum != 0)
                    transform.localPosition += new Vector3(0f, 0f, fMoveLength);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && HGameMng.I.bPuaseCheck == false)
        {
            if (bRCheck == false)
            {
                bRCheck = true;
                if (HMng.I.nCarNum == 0)
                    transform.localPosition += new Vector3(fMoveLength, 0f, 0f);

                if (HMng.I.nCarNum != 0)
                    transform.localPosition -= new Vector3(0f, 0f, fMoveLength);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            HGameMng.I.nPlayerSpeed++;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && HGameMng.I.bPuaseCheck == false)
        {
            if (bRCheck == true)
            {
                bRCheck = false;
                if (HMng.I.nCarNum == 0)
                    transform.localPosition -= new Vector3(fMoveLength, 0f, 0f);

                if (HMng.I.nCarNum != 0)
                    transform.localPosition += new Vector3(0f, 0f, fMoveLength);

            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && HGameMng.I.bPuaseCheck == false)
        {
            if (bLCheck == true)
            {
                bLCheck = false;
                if (HMng.I.nCarNum == 0)
                    transform.localPosition += new Vector3(fMoveLength, 0f, 0f);

                if (HMng.I.nCarNum != 0)
                    transform.localPosition -= new Vector3(0f, 0f, fMoveLength);
            }
        }
    }
}
