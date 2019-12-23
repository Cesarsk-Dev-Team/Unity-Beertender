using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{

    public int idUpdate = 0;
    private bool canLoad = false;
    private int idPrice = 100;

    private void Start()
    {
        SaveManager.SV_MONEY = 10000;
        //Loading Update Status
        switch (idUpdate)
        {
            case 0:
            //Life Upgrade
                transform.GetComponentInChildren<Slider>().value = SaveManager.SV_UPGRADE_LIFE;
                idPrice = Constants.UPGRADE_LIFE_COST_MULTIPLIER * SaveManager.SV_UPGRADE_LIFE + 100;
                transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";
                //IF MAX UPDATE REACHED, BLOCK
                break;
            case 1:
            //Beer Capacity Upgrade
                transform.GetComponentInChildren<Slider>().value = SaveManager.SV_UPGRADE_CAPACITY_BEER;
                idPrice = Constants.UPGRADE_BEER_CAPACITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_CAPACITY_BEER + 100;
                transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";
                break;
            case 2:
            //Wine Capacity Upgrade
                transform.GetComponentInChildren<Slider>().value = SaveManager.SV_UPGRADE_CAPACITY_WINE;
                idPrice = Constants.UPGRADE_WINE_CAPACITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_CAPACITY_WINE + 100;
                transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";
                break;
            case 3:
            //Juice Capacity Upgrade
                transform.GetComponentInChildren<Slider>().value = SaveManager.SV_UPGRADE_CAPACITY_JUICE;
                idPrice = Constants.UPGRADE_JUICE_CAPACITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_CAPACITY_JUICE + 100;
                transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";
                break;
        }
    }

    public void PurchaseUpgrade()
    {
        switch (idUpdate)
        {
            case 0:
                SaveManager.SV_UPGRADE_LIFE++;
                SaveManager.GetInstance().SavePreference(SaveManager.SV_UPGRADE_LIFE_KEY, SaveManager.SV_UPGRADE_LIFE);
                transform.GetComponentInChildren<Slider>().value = SaveManager.SV_UPGRADE_LIFE;
                idPrice = Constants.UPGRADE_LIFE_COST_MULTIPLIER * SaveManager.SV_UPGRADE_LIFE + 100;
                transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";
                //TODO decrease money (if money are not enough: error message + error sound)
                break;
            case 1:
                SaveManager.SV_UPGRADE_CAPACITY_BEER++;
                SaveManager.GetInstance().SavePreference(SaveManager.SV_UPGRADE_CAPACITY_BEER_KEY, SaveManager.SV_UPGRADE_CAPACITY_BEER);
                transform.GetComponentInChildren<Slider>().value = SaveManager.SV_UPGRADE_CAPACITY_BEER;
                idPrice = Constants.UPGRADE_BEER_CAPACITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_CAPACITY_BEER + 100;
                transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";
                //TODO decrease money (if money are not enough: error message + error sound)
                break;
            case 2:
                SaveManager.SV_UPGRADE_CAPACITY_WINE++;
                SaveManager.GetInstance().SavePreference(SaveManager.SV_UPGRADE_CAPACITY_WINE_KEY, SaveManager.SV_UPGRADE_CAPACITY_WINE);
                transform.GetComponentInChildren<Slider>().value = SaveManager.SV_UPGRADE_CAPACITY_WINE;
                idPrice = Constants.UPGRADE_WINE_CAPACITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_CAPACITY_WINE + 100;
                transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";
                //TODO decrease money (if money are not enough: error message + error sound)
                break;
            case 3:
                SaveManager.SV_UPGRADE_CAPACITY_JUICE++;
                SaveManager.GetInstance().SavePreference(SaveManager.SV_UPGRADE_CAPACITY_JUICE_KEY, SaveManager.SV_UPGRADE_CAPACITY_JUICE);
                transform.GetComponentInChildren<Slider>().value = SaveManager.SV_UPGRADE_CAPACITY_JUICE;
                idPrice = Constants.UPGRADE_JUICE_CAPACITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_CAPACITY_JUICE + 100;
                transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";
                //TODO decrease money (if money are not enough: error message + error sound)
                break;
        }
    }
}
