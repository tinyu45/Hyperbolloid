using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void  onStartClick() {
        SceneManager.LoadScene("game");
    }

    public void OnExitClick() {
        Application.Quit(); //退出程序
    }
}
