using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementScript : MonoBehaviour {

    public void onStartButton()
    {
        SceneManager.UnloadScene("Title");
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);

        AudioSource audio = Camera.main.GetComponent<AudioSource>();

        audio.clip = Resources.Load("ayasiikuuki", typeof(AudioClip)) as AudioClip;
        audio.Play();
    }

    public void onHowtoButton()
    {
        SceneManager.UnloadScene("Title");
        SceneManager.LoadScene("Howto", LoadSceneMode.Additive);
    }

    public void onTitleButton()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Additive);
    }

    public void onBackButton()
    {
        SceneManager.UnloadScene("Howto");
        SceneManager.LoadScene("Title", LoadSceneMode.Additive);
    }
}
