using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public int speedCar = 10;
    public int Score = 0;
    public Text scoreText;
    public Text speedText;
    public Text totalScore;
    public Text highScoreText;
    public bool gameOver = false;
    public GameObject gameOverPanel;
    public bool pausedGame = false;
    public GameObject pausedMenu, quitMenu;
    public List<Button> buttons;
    public GameObject countDown;
    private Image countDownGUI;
    public List<Sprite> countImages;

    void Awake()
    {
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }
        else if (GameManager.instance != this)
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        setScoreText();
        setSpeedText();
        gameOverPanel.SetActive(false);
        pausedMenu.SetActive(false);
        quitMenu.SetActive(false);
        countDown.SetActive(false);
        countDownGUI = countDown.GetComponent<Image>();
        SoundManager.instance.playStart();
    }

    public void addScore(int score)
    {
        Score += score;
        setScoreText();
        if (Score % 6 == 0)
        {
            setCarSpeed(2);
        }
    }

    public void setCarSpeed(int speed)
    {
        speedCar += speed;
        setSpeedText();
    }

    public void GameOver()
    {
        StartCoroutine(DisplayGameOver());
    }

    IEnumerator DisplayGameOver()
    {
		gameOver = true;
        SoundManager.instance.audioSourceBackground.Stop();
        yield return new WaitForSeconds(1.2f);
		SoundManager.instance.playGameOver();
		gameOverPanel.SetActive(true);
		highScoreText.enabled = false;
		totalScore.text = "Score: " + Score.ToString();
		if (Score > PlayerPrefs.GetInt("HighScoreCar", 0))
		{
			PlayerPrefs.SetInt("HighScoreCar", Score);
			highScoreText.enabled = true;
			highScoreText.text = "New High Score: " + Score;
		}
    }

    private void setScoreText()
    {
        scoreText.text = "Score: " + Score;
    }

    private void setSpeedText()
    {
        speedText.text = speedCar + " Km/h";
    }

	public void restartScene()
	{
        SoundManager.instance.audioSourceBackground.Stop();
		StartCoroutine(ChangeLevel());
	}

	IEnumerator ChangeLevel()
	{
        SoundManager.instance.playAudioClip(3);
		float fadeTime = GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime + 0.3f);
		SceneManager.LoadScene(1);
	}

    public void pauseGame()
    {
        changeStateButton(false);
        pausedGame = true;
        SoundManager.instance.audioSourceBackground.volume = 0.1f;
        pausedMenu.SetActive(true);

    }

    public void resumeGame()
    {
        countDown.SetActive(true);

		pausedMenu.SetActive(false);
		if (quitMenu.activeSelf)
		{
			quitMenu.SetActive(false);
		}

        StartCoroutine(Resume());
    }

    IEnumerator Resume()
    {
        SoundManager.instance.playAudioClip(2);
        countDownGUI.sprite = countImages[0];
        yield return new WaitForSeconds(1);

		SoundManager.instance.playAudioClip(2);
		countDownGUI.sprite = countImages[1];
		yield return new WaitForSeconds(1);

		SoundManager.instance.playAudioClip(2);
		countDownGUI.sprite = countImages[2];
		yield return new WaitForSeconds(1);

        countDown.SetActive(false);

		changeStateButton(true);
		pausedGame = false;
		SoundManager.instance.audioSourceBackground.volume = 0.4f;
    }

    public void quitGame()
    {
        pausedMenu.SetActive(false);
        quitMenu.SetActive(true);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    private void changeStateButton(bool state)
    {
        foreach (Button button in buttons)
        {
            button.interactable = state;
        }
    }
}
