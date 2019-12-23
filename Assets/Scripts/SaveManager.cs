using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour {

	//This class handles SAVE DATA and UPGRADES
	public static int SV_UPGRADE_CAPACITY_BEER = 1;
	public static int SV_UPGRADE_CAPACITY_WINE = 1;
	public static int SV_UPGRADE_CAPACITY_JUICE = 1;
	public static int SV_UPGRADE_GRAVITY_BEER = 1;
	public static int SV_UPGRADE_GRAVITY_WINE = 1;
	public static int SV_UPGRADE_GRAVITY_JUICE = 1;
	public static int SV_UPGRADE_LIFE = 0;
	public static int SV_UPGRADE_TIER = 0;
	public static int SV_UPGRADE_BONUS_PIPES = 0;
	public static int SV_UPGRADE_BONUS_DRINKS = 0;
	public static int SV_UPGRADE_BONUS_CASH = 0;

	public static int SV_RECORD = 0;
	public static int SV_MONEY = 0;

	public const string SV_UPGRADE_CAPACITY_BEER_KEY = "upgrade_capacity_beer";
	public const string SV_UPGRADE_CAPACITY_WINE_KEY = "upgrade_capacity_wine";
	public const string SV_UPGRADE_CAPACITY_JUICE_KEY = "upgrade_capacity_juice";
	public const string SV_UPGRADE_GRAVITY_BEER_KEY = "upgrade_gravity_beer";
	public const string SV_UPGRADE_GRAVITY_WINE_KEY = "upgrade_gravity_wine";
	public const string SV_UPGRADE_GRAVITY_JUICE_KEY = "upgrade_gravity_juice";
	public const string SV_UPGRADE_LIFE_KEY = "upgrade_life";
	public const string SV_UPGRADE_TIER_KEY = "tier";
	public const string SV_UPGRADE_BONUS_PIPES_KEY = "upgrade_bonus_pipes";
	public const string SV_UPGRADE_BONUS_DRINKS_KEY = "upgrade_bonus_drinks";
	public const string SV_UPGRADE_BONUS_CASH_KEY = "upgrade_bonus_cash";

	public const string SV_RECORD_KEY = "record";
	public const string SV_MONEY_KEY = "money";

	public static bool canLoad = false;

	public static SaveManager instance;

	private void Awake()
	{
	    if (instance != null) Destroy(gameObject);
        else 
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	private void Start()
	{
		LoadStartup();
		canLoad = true;
	}

	public static SaveManager GetInstance()
    {
        return instance;
    }

	private int LoadPreference(string key)
	{
		return PlayerPrefs.GetInt(key);
	}

	private void LoadStartup()
	{
		SV_UPGRADE_CAPACITY_BEER = PlayerPrefs.GetInt(SV_UPGRADE_CAPACITY_BEER_KEY, 1);
		SV_UPGRADE_CAPACITY_WINE = PlayerPrefs.GetInt(SV_UPGRADE_CAPACITY_WINE_KEY, 1);
		SV_UPGRADE_CAPACITY_JUICE = PlayerPrefs.GetInt(SV_UPGRADE_CAPACITY_JUICE_KEY, 1);
		SV_UPGRADE_LIFE = PlayerPrefs.GetInt(SV_UPGRADE_LIFE_KEY, 0);

	    SV_UPGRADE_GRAVITY_BEER = PlayerPrefs.GetInt(SV_UPGRADE_GRAVITY_BEER_KEY, 1);
		UpgradeManager.GetInstance().UPGRADE_BEER_GRAVITY = (SV_UPGRADE_GRAVITY_BEER + 1f) / 2f;
		
	    SV_UPGRADE_GRAVITY_WINE = PlayerPrefs.GetInt(SV_UPGRADE_GRAVITY_WINE_KEY, 1);
		UpgradeManager.GetInstance().UPGRADE_WINE_GRAVITY = (SV_UPGRADE_GRAVITY_WINE + 1f) / 2f;

	    SV_UPGRADE_GRAVITY_JUICE = PlayerPrefs.GetInt(SV_UPGRADE_GRAVITY_JUICE_KEY, 1);
		UpgradeManager.GetInstance().UPGRADE_JUICE_GRAVITY = (SV_UPGRADE_GRAVITY_JUICE + 1f) / 2f;

		SV_UPGRADE_TIER = PlayerPrefs.GetInt(SV_UPGRADE_TIER_KEY, 0);

		SV_UPGRADE_BONUS_PIPES = PlayerPrefs.GetInt(SV_UPGRADE_BONUS_PIPES_KEY, 0);
		SV_UPGRADE_BONUS_DRINKS = PlayerPrefs.GetInt(SV_UPGRADE_BONUS_DRINKS_KEY, 0);
		SV_UPGRADE_BONUS_CASH = PlayerPrefs.GetInt(SV_UPGRADE_BONUS_CASH_KEY, 0);

		SV_RECORD = PlayerPrefs.GetInt(SV_RECORD_KEY);
		SV_MONEY = PlayerPrefs.GetInt(SV_MONEY_KEY);
	}

	public void SavePreference(string key, int value)
	{
		PlayerPrefs.SetInt(key, value);
	}

	public void SavePreference(string key, float value)
	{
		PlayerPrefs.SetFloat(key, value);
	}

	public void DeletePreference()
	{
		PlayerPrefs.DeleteAll();
		Debug.Log("Preference deleted");
	}

	private void SaveGameOver()
	{
	}

	public void RestartScene()
	{
		SceneManager.LoadScene("Upgrade");
	}
}
