using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManager.LoadScene("Title", LoadSceneMode.Additive);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onBackButton()
    {
        SceneManager.LoadScene("Main");
    }
}
