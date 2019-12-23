using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

    public static bool isAudioMuted = false;
    public static bool isMusicMuted = false;

    void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			//DontDestroyOnLoad(gameObject);
		}
    }

    public AudioSource[] GetSounds()
    {
        return gameObject.GetComponents<AudioSource>();
    }

    public static AudioManager GetInstance()
    {
        return instance;
    }
}
