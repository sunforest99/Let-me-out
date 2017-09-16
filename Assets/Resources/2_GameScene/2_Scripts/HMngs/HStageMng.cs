using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using MHomiLibrary;

public class HStageMng : HSingletonScene<HStageMng> {

    protected HStageMng() { }

    void Awake()
    {
        cSceneList = new Dictionary<string, HState>();

        for (int i = 0; i < SceneList.Count; i++)
            cSceneList.Add(GetClassName(SceneList[i].ToString()), SceneList[i]);
    }

    //public UILabel StageInfoLabel = null;

    void Start()
    {
        ChangeScene("HStage1");        
    }

    void OnDestroy()
    {
        cSceneList.Clear();
        cSceneList = null;
    }

    public void ChangeInfo(string sText)
    {
        //StageInfoLabel.text = sText;
    }
}
