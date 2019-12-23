using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermediaryWrapper : MonoBehaviour {

	private AudioSource[] sounds;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		sounds = AudioManager.GetInstance().GetSounds();
	}

	public void PlaySound(int sound)
	{
		sounds[sound].Play();
	}
	
	public void GameOverWrapper()
	{
		GameManager.GetInstance().GameOver();
	}
	public void CustomerBoredWrapper()
	{
		CustomerManager.GetInstance().CustomerLeaves(gameObject.GetComponentInParent<Customer>().RFID);
	}
}
