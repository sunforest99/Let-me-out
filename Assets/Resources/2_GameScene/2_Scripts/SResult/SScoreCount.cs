using UnityEngine;
using System.Collections;

public class SScoreCount : MonoBehaviour {

    public UILabel ScoreLabel;

    public UILabel HScoreLabel;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ScoreLabel.text = "SCORE : " + HGameMng.I.nScore;
        HScoreLabel.text = "Best : " + HGameMng.I.nScore;
    }
}
