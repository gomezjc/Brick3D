using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Text maxScoreText;
    public AudioSource audioStart;

	void Start () 
    {
        maxScoreText.text = "Max Score: "+PlayerPrefs.GetInt("HighScoreCar", 0).ToString();
	}
	
    public void playGame()
    {
        GetComponent<AudioSource>().enabled = false;
        audioStart.enabled = true;
        StartCoroutine(ChangeLevel());
    }

    IEnumerator ChangeLevel()
    {
        float fadeTime = GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime + 0.3f);
        SceneManager.LoadScene(1);
    }

	public void exitGame()
	{
		Application.Quit();
	}
}
 