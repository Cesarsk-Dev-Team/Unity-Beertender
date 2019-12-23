using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utility : MonoBehaviour {

	public void LoadUpgradeScene()
	{
		SceneManager.LoadScene("Upgrade");
	}

	public void DeletePreferences()
	{
		PlayerPrefs.DeleteAll();
	}
}
