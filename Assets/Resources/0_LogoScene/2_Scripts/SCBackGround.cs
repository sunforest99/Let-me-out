using UnityEngine;
using System.Collections;

public class SCBackGround : MonoBehaviour {

    public Camera BGroundCam;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        BGroundCam.backgroundColor = new Color(0.52f, 0.8f, 0.92f);
    }
}
