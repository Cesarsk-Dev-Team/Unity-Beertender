using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{

    public int idUpdate = 0;
    public Text myWallet;
    private bool canLoad = false;
    private int idPrice = 100;

    private void Start()
    {
        //DEBUG PURPOSE, INFINITE MONEY
        SaveManager.SV_MONEY = 1000000;
        myWallet.text = "Your Wallet: " + SaveManager.SV_MONEY + "$";
        //Loading Update Status
        switch (idUpdate)
        {
            case 0: //Life Upgrade
                InitUpgrade(SaveManager.SV_UPGRADE_LIFE, Constants.UPGRADE_LIFE_COST_MULTIPLIER, 0, 100);
                break;
            case 1: //Beer Capacity Upgrade
                InitUpgrade(SaveManager.SV_UPGRADE_CAPACITY_BEER, Constants.UPGRADE_BEER_CAPACITY_COST_MULTIPLIER, 1, 100);
                break;
            case 2: //Wine Capacity Upgrade
                InitUpgrade(SaveManager.SV_UPGRADE_CAPACITY_WINE, Constants.UPGRADE_WINE_CAPACITY_COST_MULTIPLIER, 1, 100);
                break;
            case 3: //Juice Capacity Upgrade
                InitUpgrade(SaveManager.SV_UPGRADE_CAPACITY_JUICE, Constants.UPGRADE_JUICE_CAPACITY_COST_MULTIPLIER, 1, 100);
                break;
            case 4: //Beer Gravity Upgrade
                InitUpgrade(SaveManager.SV_UPGRADE_GRAVITY_BEER, Constants.UPGRADE_BEER_GRAVITY_COST_MULTIPLIER, 1, 100);
                break;
            case 5: //Wine Gravity Upgrade
                InitUpgrade(SaveManager.SV_UPGRADE_GRAVITY_WINE, Constants.UPGRADE_WINE_GRAVITY_COST_MULTIPLIER, 1, 100);
                break;
            case 6: //Juice Gravity Upgrade
                InitUpgrade(SaveManager.SV_UPGRADE_GRAVITY_JUICE, Constants.UPGRADE_JUICE_GRAVITY_COST_MULTIPLIER, 1, 100);
                break;
            case 7: //Juice Gravity Upgrade
                InitUpgrade(SaveManager.SV_UPGRADE_TIER, Constants.UPGRADE_TIER_COST_MULTIPLIER, 0, 100);
                break;
            case 8: //Pipes Level
                InitUpgrade(SaveManager.SV_UPGRADE_BONUS_PIPES, Constants.UPGRADE_BONUS_PIPES_COST_MULTIPLIER, 0, 100);
                break;
            case 9: //Drinks Level
                InitUpgrade(SaveManager.SV_UPGRADE_BONUS_DRINKS, Constants.UPGRADE_BONUS_DRINKS_COST_MULTIPLIER, 0, 100);
                break;
            case 10: //Cash Level
                InitUpgrade(SaveManager.SV_UPGRADE_BONUS_CASH, Constants.UPGRADE_BONUS_CASH_COST_MULTIPLIER, 0, 100);
                break;
        }
    }

    public void PurchaseUpgrade()
    {
        switch (idUpdate)
        {
            case 0: //Life Upgrade
                InitPurchaseUpgrade(ref SaveManager.SV_UPGRADE_LIFE, SaveManager.SV_UPGRADE_LIFE_KEY, Constants.UPGRADE_LIFE_COST_MULTIPLIER, 0, 100);
                break;
            case 1: //Beer Capacity Upgrade
                InitPurchaseUpgrade(ref SaveManager.SV_UPGRADE_CAPACITY_BEER, SaveManager.SV_UPGRADE_CAPACITY_BEER_KEY, Constants.UPGRADE_BEER_CAPACITY_COST_MULTIPLIER, 1, 100);
                break;
            case 2: //Wine Capacity Upgrade
                InitPurchaseUpgrade(ref SaveManager.SV_UPGRADE_CAPACITY_WINE, SaveManager.SV_UPGRADE_CAPACITY_WINE_KEY, Constants.UPGRADE_WINE_CAPACITY_COST_MULTIPLIER, 1, 100);
                break;
            case 3: //Juice Capacity Upgrade
                InitPurchaseUpgrade(ref SaveManager.SV_UPGRADE_CAPACITY_JUICE, SaveManager.SV_UPGRADE_CAPACITY_JUICE_KEY, Constants.UPGRADE_JUICE_CAPACITY_COST_MULTIPLIER, 1, 100);
                break;
            case 4: //Beer Gravity Upgrade
                InitPurchaseUpgrade(ref SaveManager.SV_UPGRADE_GRAVITY_BEER, SaveManager.SV_UPGRADE_GRAVITY_BEER_KEY, Constants.UPGRADE_BEER_GRAVITY_COST_MULTIPLIER, 1, 100);
                break;
            case 5: //Wine Gravity Upgrade
                InitPurchaseUpgrade(ref SaveManager.SV_UPGRADE_GRAVITY_WINE, SaveManager.SV_UPGRADE_GRAVITY_WINE_KEY, Constants.UPGRADE_WINE_GRAVITY_COST_MULTIPLIER, 1, 100);
                break;
            case 6: //Juice Gravity Upgrade
                InitPurchaseUpgrade(ref SaveManager.SV_UPGRADE_GRAVITY_JUICE, SaveManager.SV_UPGRADE_GRAVITY_JUICE_KEY, Constants.UPGRADE_JUICE_GRAVITY_COST_MULTIPLIER, 1, 100);
                break;
            case 7: //Juice Gravity Upgrade
                InitPurchaseUpgrade(ref SaveManager.SV_UPGRADE_TIER, SaveManager.SV_UPGRADE_TIER_KEY, Constants.UPGRADE_TIER_COST_MULTIPLIER, 0, 100);
                break;
            case 8:
                InitPurchaseUpgrade(ref SaveManager.SV_UPGRADE_BONUS_PIPES, SaveManager.SV_UPGRADE_BONUS_PIPES_KEY, Constants.UPGRADE_BONUS_PIPES_COST_MULTIPLIER, 0, 100);
                break;
            case 9:
                InitPurchaseUpgrade(ref SaveManager.SV_UPGRADE_BONUS_DRINKS, SaveManager.SV_UPGRADE_BONUS_DRINKS_KEY, Constants.UPGRADE_BONUS_DRINKS_COST_MULTIPLIER, 0, 100);
                break;
            case 10:
                InitPurchaseUpgrade(ref SaveManager.SV_UPGRADE_BONUS_CASH, SaveManager.SV_UPGRADE_BONUS_CASH_KEY, Constants.UPGRADE_BONUS_CASH_COST_MULTIPLIER, 0, 100);
                break;
        }
    }

    private void InitUpgrade(int saveManagerUpgrade, int constantsUpgradeCost, int margin, int sumBase)
    {
        transform.GetComponentInChildren<Slider>().value = saveManagerUpgrade - margin;
        idPrice = Mathf.RoundToInt(constantsUpgradeCost * (saveManagerUpgrade - margin) + sumBase);
        transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";
        if (transform.GetComponentInChildren<Slider>().value == transform.GetComponentInChildren<Slider>().maxValue) MaxUpdateReached();
    }

    private void InitPurchaseUpgrade(ref int saveManagerUpgrade, string saveManagerUpgradeKey, 
                int constantsUpgradeCost, int margin, int sumBase)
    {
        if (SaveManager.SV_MONEY > constantsUpgradeCost * saveManagerUpgrade)
        {
            saveManagerUpgrade++;
            SaveManager.GetInstance().SavePreference(saveManagerUpgradeKey, saveManagerUpgrade);
            idPrice = Mathf.RoundToInt(constantsUpgradeCost * (saveManagerUpgrade - margin) + 100);
            transform.GetComponentInChildren<Slider>().value = saveManagerUpgrade - margin;
            transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";
            SaveManager.SV_MONEY -= Mathf.RoundToInt(constantsUpgradeCost * saveManagerUpgrade);
            PlayerPrefs.SetInt(SaveManager.SV_MONEY_KEY, SaveManager.SV_MONEY);
            myWallet.text = "YOUR WALLET: " + SaveManager.SV_MONEY + "$";
            if (transform.GetComponentInChildren<Slider>().value == transform.GetComponentInChildren<Slider>().maxValue) MaxUpdateReached();
        }
    }

    private void MaxUpdateReached()
    {
        gameObject.GetComponent<Button>().interactable = false;
        transform.GetChild(1).GetComponent<Text>().text = "Bravo! Max Update Reached";
        transform.GetChild(2).GetComponent<Text>().text = "MAXED";
    }
}
