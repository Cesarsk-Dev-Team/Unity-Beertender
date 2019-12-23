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
        SaveManager.SV_MONEY = 1000000;
        myWallet.text = "Your Wallet: "+SaveManager.SV_MONEY+"$";
        //Loading Update Status
        switch (idUpdate)
        {
            case 0:
                //Life Upgrade
                transform.GetComponentInChildren<Slider>().value = SaveManager.SV_UPGRADE_LIFE;
                idPrice = Constants.UPGRADE_LIFE_COST_MULTIPLIER * SaveManager.SV_UPGRADE_LIFE + 100;
                transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";
                if (transform.GetComponentInChildren<Slider>().value == transform.GetComponentInChildren<Slider>().maxValue) MaxUpdateReached();

                break;
            case 1:
                //Beer Capacity Upgrade
                transform.GetComponentInChildren<Slider>().value = SaveManager.SV_UPGRADE_CAPACITY_BEER;
                idPrice = Constants.UPGRADE_BEER_CAPACITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_CAPACITY_BEER + 100;
                transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";
                if (transform.GetComponentInChildren<Slider>().value == transform.GetComponentInChildren<Slider>().maxValue) MaxUpdateReached();
                
                break;
            case 2:
                //Wine Capacity Upgrade
                transform.GetComponentInChildren<Slider>().value = SaveManager.SV_UPGRADE_CAPACITY_WINE;
                idPrice = Constants.UPGRADE_WINE_CAPACITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_CAPACITY_WINE + 100;
                transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";
                if (transform.GetComponentInChildren<Slider>().value == transform.GetComponentInChildren<Slider>().maxValue) MaxUpdateReached();
                
                break;
            case 3:
                //Juice Capacity Upgrade
                Debug.Log("Juice Cap: "+SaveManager.SV_UPGRADE_CAPACITY_JUICE);
                transform.GetComponentInChildren<Slider>().value = SaveManager.SV_UPGRADE_CAPACITY_JUICE;
                idPrice = Constants.UPGRADE_JUICE_CAPACITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_CAPACITY_JUICE + 100;
                transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";
                if (transform.GetComponentInChildren<Slider>().value == transform.GetComponentInChildren<Slider>().maxValue) MaxUpdateReached();
                
                break;
            case 4:
                //Beer Gravity Upgrade
                Debug.Log("Beer Speed: "+SaveManager.SV_UPGRADE_GRAVITY_BEER);
                transform.GetComponentInChildren<Slider>().value = SaveManager.SV_UPGRADE_GRAVITY_BEER-1;
                idPrice = Mathf.RoundToInt(Constants.UPGRADE_BEER_GRAVITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_GRAVITY_BEER + 100);
                transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";
                if (transform.GetComponentInChildren<Slider>().value == transform.GetComponentInChildren<Slider>().maxValue) MaxUpdateReached();

                break;
            case 5:
                //Wine Gravity Upgrade

                break;
            
            case 6:
                //Juice Gravity Upgrade

                break;
        }
    }

    public void PurchaseUpgrade()
    {
        switch (idUpdate)
        {
            case 0:
                if (SaveManager.SV_MONEY > Constants.UPGRADE_LIFE_COST_MULTIPLIER * SaveManager.SV_UPGRADE_LIFE)
                {
                    //if money are enough, proceed with the purchase
                    SaveManager.SV_UPGRADE_LIFE++;
                    SaveManager.GetInstance().SavePreference(SaveManager.SV_UPGRADE_LIFE_KEY, SaveManager.SV_UPGRADE_LIFE);
                    transform.GetComponentInChildren<Slider>().value = SaveManager.SV_UPGRADE_LIFE;
                    idPrice = Constants.UPGRADE_LIFE_COST_MULTIPLIER * SaveManager.SV_UPGRADE_LIFE + 100;
                    transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";

                    SaveManager.SV_MONEY -= Constants.UPGRADE_LIFE_COST_MULTIPLIER * SaveManager.SV_UPGRADE_LIFE;
                    PlayerPrefs.SetInt("money", SaveManager.SV_MONEY);
                    myWallet.text = "YOUR WALLET: "+SaveManager.SV_MONEY+"$";
                    if (transform.GetComponentInChildren<Slider>().value == transform.GetComponentInChildren<Slider>().maxValue) MaxUpdateReached();
                }
                break;

            case 1:
                if (SaveManager.SV_MONEY > Constants.UPGRADE_BEER_CAPACITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_CAPACITY_BEER)
                {
                    //if money are enough, proceed with the purchase
                    SaveManager.SV_UPGRADE_CAPACITY_BEER++;
                    SaveManager.GetInstance().SavePreference(SaveManager.SV_UPGRADE_CAPACITY_BEER_KEY, SaveManager.SV_UPGRADE_CAPACITY_BEER);
                    transform.GetComponentInChildren<Slider>().value = SaveManager.SV_UPGRADE_CAPACITY_BEER;
                    idPrice = Constants.UPGRADE_BEER_CAPACITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_CAPACITY_BEER + 100;
                    transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";

                    SaveManager.SV_MONEY -= Constants.UPGRADE_BEER_CAPACITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_CAPACITY_BEER;
                    PlayerPrefs.SetInt("money", SaveManager.SV_MONEY);
                    myWallet.text = "YOUR WALLET: "+SaveManager.SV_MONEY+"$";
                    if (transform.GetComponentInChildren<Slider>().value == transform.GetComponentInChildren<Slider>().maxValue) MaxUpdateReached();
                }
                break;

            case 2:
                if (SaveManager.SV_MONEY > Constants.UPGRADE_WINE_CAPACITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_CAPACITY_WINE)
                {
                    SaveManager.SV_UPGRADE_CAPACITY_WINE++;
                    SaveManager.GetInstance().SavePreference(SaveManager.SV_UPGRADE_CAPACITY_WINE_KEY, SaveManager.SV_UPGRADE_CAPACITY_WINE);
                    transform.GetComponentInChildren<Slider>().value = SaveManager.SV_UPGRADE_CAPACITY_WINE;
                    idPrice = Constants.UPGRADE_WINE_CAPACITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_CAPACITY_WINE + 100;
                    transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";

                    SaveManager.SV_MONEY -= Constants.UPGRADE_WINE_CAPACITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_CAPACITY_WINE;
                    PlayerPrefs.SetInt("money", SaveManager.SV_MONEY);
                    myWallet.text = "YOUR WALLET: "+SaveManager.SV_MONEY+"$";
                    if (transform.GetComponentInChildren<Slider>().value == transform.GetComponentInChildren<Slider>().maxValue) MaxUpdateReached();
                }
                break;

            case 3:
                if (SaveManager.SV_MONEY > Constants.UPGRADE_JUICE_CAPACITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_CAPACITY_JUICE)
                {
                    SaveManager.SV_UPGRADE_CAPACITY_JUICE++;
                    SaveManager.GetInstance().SavePreference(SaveManager.SV_UPGRADE_CAPACITY_JUICE_KEY, SaveManager.SV_UPGRADE_CAPACITY_JUICE);
                    transform.GetComponentInChildren<Slider>().value = SaveManager.SV_UPGRADE_CAPACITY_JUICE;
                    idPrice = Constants.UPGRADE_JUICE_CAPACITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_CAPACITY_JUICE + 100;
                    transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";
                    SaveManager.SV_MONEY -= Constants.UPGRADE_JUICE_CAPACITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_CAPACITY_JUICE;
                    PlayerPrefs.SetInt("money", SaveManager.SV_MONEY);
                    myWallet.text = "YOUR WALLET: "+SaveManager.SV_MONEY+"$";
                    if (transform.GetComponentInChildren<Slider>().value == transform.GetComponentInChildren<Slider>().maxValue) MaxUpdateReached();
                }
                break;

            case 4:
                if (SaveManager.SV_MONEY > Constants.UPGRADE_BEER_GRAVITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_GRAVITY_BEER)
                {
                    SaveManager.SV_UPGRADE_GRAVITY_BEER++;
                    SaveManager.GetInstance().SavePreference(SaveManager.SV_UPGRADE_GRAVITY_BEER_KEY, SaveManager.SV_UPGRADE_GRAVITY_BEER);
                    transform.GetComponentInChildren<Slider>().value = SaveManager.SV_UPGRADE_GRAVITY_BEER-1;
                    idPrice =  Mathf.RoundToInt(Constants.UPGRADE_BEER_GRAVITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_GRAVITY_BEER + 100);
                    transform.GetChild(2).GetComponent<Text>().text = "" + idPrice + "$";
                    SaveManager.SV_MONEY -= Mathf.RoundToInt(Constants.UPGRADE_BEER_GRAVITY_COST_MULTIPLIER * SaveManager.SV_UPGRADE_GRAVITY_BEER);
                    PlayerPrefs.SetInt("money", SaveManager.SV_MONEY);
                    myWallet.text = "YOUR WALLET: "+SaveManager.SV_MONEY+"$";
                    if (transform.GetComponentInChildren<Slider>().value == transform.GetComponentInChildren<Slider>().maxValue) MaxUpdateReached();
                }
                break;

            case 5:
                break;

            case 6:
                break;
        }
    }

    void MaxUpdateReached()
    {
        gameObject.GetComponent<Button>().interactable = false;
        transform.GetChild(1).GetComponent<Text>().text = "Bravo! Max Update Reached";
        transform.GetChild(2).GetComponent<Text>().text = "MAXED";
    }
}
