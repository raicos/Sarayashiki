using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using TMPro;

public class CountDownScript : MonoBehaviour {

    Animator anim;
    GameScript script;

    public Button tariru;
    public Button tarinai;


	// Use this for initialization
	void Start () {
        script = GameObject.Find("GameScript").GetComponent<GameScript>();
        anim = gameObject.GetComponent<Animator>();
        tariru.enabled = false;
        tarinai.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void finAnim()
    {
        int c = anim.GetInteger("count");
        if(c > 0)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = c.ToString();

            anim.SetInteger("count", c - 1);
        }
        else
        {
            gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
            anim.SetBool("toIdle", true);
            tariru.enabled = true;
            tarinai.enabled = true;
            script.changeFlag();
            script.nextProb();
            
        }
    }


}
