using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;
    public List<AudioClip> audioClips;

    public AudioSource audioSourceBackground;
    private AudioSource audioSource;

	void Awake()
	{
		if (SoundManager.instance == null)
		{
			SoundManager.instance = this;
		}
		else if (SoundManager.instance != this)
		{
			Destroy(gameObject);
		}

		//DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
	}

    public void playAudioClip(int index)
    {
        float volumen = 0.4f;
        if(index == 3){
            volumen = 0.3f;
        }
        audioSource.volume = volumen;
		audioSource.clip = null;
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

    public void playGameOver()
    {
        audioSourceBackground.clip = null;
        audioSourceBackground.volume = 0.3f;
        audioSourceBackground.clip = audioClips[4];
        audioSourceBackground.Play();
    }

    public void playStart()
    {
		audioSourceBackground.clip = null;
		audioSourceBackground.volume = 0.3f;
		audioSourceBackground.clip = audioClips[5];
        audioSourceBackground.Play();
    }

}
