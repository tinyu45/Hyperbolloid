using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverSceneControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnContinueClick() {
        SceneManager.LoadScene("game");
    }

    public void OnExitClick() {
        Application.Quit();
    }
}
