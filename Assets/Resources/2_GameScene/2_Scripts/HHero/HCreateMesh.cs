using UnityEngine;
using System.Collections;

public class HCreateMesh : MonoBehaviour {


    public BuildMeshAlongPath HBMAPath = null;

	// Use this for initialization
	void Start () {
        HBMAPath.Build();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
