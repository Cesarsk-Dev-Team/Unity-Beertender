using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
   	public static UpgradeManager instance;

	private void Awake()
	{
	    if (instance != null) Destroy(gameObject);
        else 
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

    public static UpgradeManager GetInstance()
    {
        return instance;
    }

    //Upgrade Gravity Drinks
    [HideInInspector]
    public float UPGRADE_BEER_GRAVITY = 1;
    [HideInInspector]
    public float UPGRADE_WINE_GRAVITY = 1;
    [HideInInspector]
    public float UPGRADE_JUICE_GRAVITY = 1;
}