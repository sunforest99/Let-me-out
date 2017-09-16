using UnityEngine;
using System.Collections;

public class SCarSelectBar : MonoBehaviour
{
    public UIScrollBar GroundScrol;
    public Transform CarGroupTrans;

    // Use this for initialization
    void Start()
    {
        GroundScrol.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GroundScrol.value);

        if (GroundScrol.value < 0.1f)
        {
            GroundScrol.value = 0;
        }

        if (GroundScrol.value > 0.45f && GroundScrol.value < 0.55f)
        {
            GroundScrol.value = 0.5f;
        }

        if (GroundScrol.value > 0.9f)
        {
            GroundScrol.value = 1f;
         }
        CarGroupTrans.localPosition = new Vector3(GroundScrol.value * -1000f, 0f);
    }
}
