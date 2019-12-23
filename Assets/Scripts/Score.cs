using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //private variables
    private static Score instance;
    public double score;
    private int counter = 0;
    private string drink;
    private float serviceQuality;
    private float drinkScore = 1f;
    private float drinkTypeScore = 1f;
    private float customerTierScore = 1f;

    private const float BAD_SERVICE_QUALITY = 0.5f;
    private const float GOOD_SERVICE_QUALITY = 1f;
    private const float PERFECT_SERVICE_QUALITY = 1.3f;

    private const int SMALL_BEER_LOWER_LIMIT = 20;
    private const int SMALL_BEER_UPPER_LIMIT = 40;
    private const int MEDIUM_BEER_LOWER_LIMIT = 30;
    private const int MEDIUM_BEER_UPPER_LIMIT = 50;
    private const int LARGE_BEER_LOWER_LIMIT = 35;
    private const int LARGE_BEER_UPPER_LIMIT = 60;

    private const int SMALL_WINE_LOWER_LIMIT = 15;
    private const int SMALL_WINE_UPPER_LIMIT = 24;
    private const int MEDIUM_WINE_LOWER_LIMIT = 33;
    private const int MEDIUM_WINE_UPPER_LIMIT = 41;
    private const int LARGE_WINE_LOWER_LIMIT = 40;
    private const int LARGE_WINE_UPPER_LIMIT = 52;

    private const int SMALL_JUICE_LOWER_LIMIT = 30;
    private const int SMALL_JUICE_UPPER_LIMIT = 45;
    private const int MEDIUM_JUICE_LOWER_LIMIT = 40;
    private const int MEDIUM_JUICE_UPPER_LIMIT = 60;
    private const int LARGE_JUICE_LOWER_LIMIT = 100;
    private const int LARGE_JUICE_UPPER_LIMIT = 120;

    private const int PERCENTAGE_PENALTY = 5;

    private string customerSatisfaction;
    //public variables
    public Text customerHappiness;
    public Text scoreLabel;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public static Score GetInstance()
    {
        return instance;
    }

    public void UpdateCounter(int payload)
    {
        counter = payload;
    }

    public void UpdateDrink(string payload)
    {
        drink = payload;
    }

    public void CalculateScore(GameObject customer)
    {
        int activeGlass = BarManager.GetInstance().GetActiveGlass();
        switch (activeGlass)
        {
            case 0:
                //Small Beer
                if (counter <= SMALL_BEER_LOWER_LIMIT)
                {
                    customerSatisfaction = "Bad";
                    serviceQuality = BAD_SERVICE_QUALITY;
                    GameManager.GetInstance().ResetStreak();
                }
                else if (counter > SMALL_BEER_LOWER_LIMIT && counter <= SMALL_BEER_UPPER_LIMIT)
                {
                    customerSatisfaction = "Good";
                    serviceQuality = GOOD_SERVICE_QUALITY;
                    GameManager.GetInstance().ResetStreak();
                }
                else if (counter > SMALL_BEER_UPPER_LIMIT)
                {
                    customerSatisfaction = "Great";
                    serviceQuality = PERFECT_SERVICE_QUALITY;
                    GameManager.GetInstance().IncreaseStreak();
                }
                break;

            case 1:
                //Medium Beer
                if (counter <= MEDIUM_BEER_LOWER_LIMIT)
                {
                    customerSatisfaction = "Bad";
                    serviceQuality = BAD_SERVICE_QUALITY;
                    GameManager.GetInstance().ResetStreak();
                }
                else if (counter > MEDIUM_BEER_LOWER_LIMIT && counter <= MEDIUM_BEER_UPPER_LIMIT)
                {
                    customerSatisfaction = "Good";
                    serviceQuality = GOOD_SERVICE_QUALITY;
                    GameManager.GetInstance().ResetStreak();
                }
                else if (counter > MEDIUM_BEER_UPPER_LIMIT)
                {
                    customerSatisfaction = "Great";
                    serviceQuality = PERFECT_SERVICE_QUALITY;
                    GameManager.GetInstance().IncreaseStreak();
                }
                break;

            case 2:
                //Large Beer
                if (counter <= LARGE_BEER_LOWER_LIMIT)
                {
                    customerSatisfaction = "Bad";
                    serviceQuality = BAD_SERVICE_QUALITY;
                    GameManager.GetInstance().ResetStreak();
                }
                else if (counter > LARGE_BEER_LOWER_LIMIT && counter <= LARGE_BEER_UPPER_LIMIT)
                {
                    customerSatisfaction = "Good";
                    serviceQuality = GOOD_SERVICE_QUALITY;
                    GameManager.GetInstance().ResetStreak();
                }
                else if (counter > LARGE_BEER_UPPER_LIMIT)
                {
                    customerSatisfaction = "Great";
                    serviceQuality = PERFECT_SERVICE_QUALITY;
                    GameManager.GetInstance().IncreaseStreak();
                }
                break;

            case 3:
                //Small Wine
                if (counter <= SMALL_WINE_LOWER_LIMIT)
                {
                    customerSatisfaction = "Bad";
                    serviceQuality = BAD_SERVICE_QUALITY;
                    GameManager.GetInstance().ResetStreak();
                }
                else if (counter > SMALL_WINE_LOWER_LIMIT && counter <= SMALL_WINE_UPPER_LIMIT)
                {
                    customerSatisfaction = "Good";
                    serviceQuality = GOOD_SERVICE_QUALITY;
                    GameManager.GetInstance().ResetStreak();
                }
                else if (counter > SMALL_WINE_UPPER_LIMIT)
                {
                    customerSatisfaction = "Great";
                    serviceQuality = PERFECT_SERVICE_QUALITY;
                    GameManager.GetInstance().IncreaseStreak();
                }
                break;

            case 4:
                //Medium Wine
                if (counter <= MEDIUM_WINE_LOWER_LIMIT)
                {
                    customerSatisfaction = "Bad";
                    serviceQuality = BAD_SERVICE_QUALITY;
                    GameManager.GetInstance().ResetStreak();
                }
                else if (counter > MEDIUM_WINE_LOWER_LIMIT && counter <= MEDIUM_WINE_UPPER_LIMIT)
                {
                    customerSatisfaction = "Good";
                    serviceQuality = GOOD_SERVICE_QUALITY;
                    GameManager.GetInstance().ResetStreak();
                }
                else if (counter > MEDIUM_WINE_UPPER_LIMIT)
                {
                    customerSatisfaction = "Great";
                    serviceQuality = PERFECT_SERVICE_QUALITY;
                    GameManager.GetInstance().IncreaseStreak();
                }
                break;

            case 5:
                //Large Wine
                if (counter <= LARGE_WINE_LOWER_LIMIT)
                {
                    customerSatisfaction = "Bad";
                    serviceQuality = BAD_SERVICE_QUALITY;
                    GameManager.GetInstance().ResetStreak();
                }
                else if (counter > LARGE_WINE_LOWER_LIMIT && counter <= LARGE_WINE_UPPER_LIMIT)
                {
                    customerSatisfaction = "Good";
                    serviceQuality = GOOD_SERVICE_QUALITY;
                    GameManager.GetInstance().ResetStreak();
                }
                else if (counter > LARGE_WINE_UPPER_LIMIT)
                {
                    customerSatisfaction = "Great";
                    serviceQuality = PERFECT_SERVICE_QUALITY;
                    GameManager.GetInstance().IncreaseStreak();
                }
                break;

            case 6:
                //Small Juice
                if (counter <= SMALL_JUICE_LOWER_LIMIT)
                {
                    customerSatisfaction = "Bad";
                    serviceQuality = BAD_SERVICE_QUALITY;
                    GameManager.GetInstance().ResetStreak();
                }
                else if (counter > SMALL_JUICE_LOWER_LIMIT && counter <= SMALL_JUICE_UPPER_LIMIT)
                {
                    customerSatisfaction = "Good";
                    serviceQuality = GOOD_SERVICE_QUALITY;
                    GameManager.GetInstance().ResetStreak();
                }
                else if (counter > SMALL_JUICE_UPPER_LIMIT)
                {
                    customerSatisfaction = "Great";
                    serviceQuality = PERFECT_SERVICE_QUALITY;
                    GameManager.GetInstance().IncreaseStreak();
                }
                break;

            case 7:
                //Medium Juice
                if (counter <= MEDIUM_JUICE_LOWER_LIMIT)
                {
                    customerSatisfaction = "Bad";
                    serviceQuality = BAD_SERVICE_QUALITY;
                    GameManager.GetInstance().ResetStreak();
                }
                else if (counter > MEDIUM_JUICE_LOWER_LIMIT && counter <= MEDIUM_JUICE_UPPER_LIMIT)
                {
                    customerSatisfaction = "Good";
                    serviceQuality = GOOD_SERVICE_QUALITY;
                    GameManager.GetInstance().ResetStreak();
                }
                else if (counter > MEDIUM_JUICE_UPPER_LIMIT)
                {
                    customerSatisfaction = "Great";
                    serviceQuality = PERFECT_SERVICE_QUALITY;
                    GameManager.GetInstance().IncreaseStreak();
                }
                break;

            case 8:
                //Large Juice
                if (counter <= LARGE_JUICE_LOWER_LIMIT)
                {
                    customerSatisfaction = "Bad";
                    serviceQuality = BAD_SERVICE_QUALITY;
                    GameManager.GetInstance().ResetStreak();
                }
                else if (counter > LARGE_JUICE_LOWER_LIMIT && counter <= LARGE_JUICE_UPPER_LIMIT)
                {
                    customerSatisfaction = "Good";
                    serviceQuality = GOOD_SERVICE_QUALITY;
                    GameManager.GetInstance().ResetStreak();
                }
                else if (counter > LARGE_JUICE_UPPER_LIMIT)
                {
                    customerSatisfaction = "Great";
                    serviceQuality = PERFECT_SERVICE_QUALITY;
                    GameManager.GetInstance().IncreaseStreak();
                }
                break;
        }


        EvaluateScore(customer);
        customer.transform.GetChild(1).GetComponent<Animator>().SetTrigger(customerSatisfaction);
        customer.GetComponent<Animator>().SetTrigger(customerSatisfaction);
    }

    public void PenaltyScore()
    {
        score -= (score * PERCENTAGE_PENALTY) / 100;
        scoreLabel.text = "SCORE: " +score.ToString();
    }

    private void EvaluateScore(GameObject customer)
    {
        score += serviceQuality * counter * CalculateDrinkScore() * CalculateDrinkType() * CalculateCustomerTier(customer) + CalculateUpgradeBonus();
        score = Mathf.Round((float)score);
        scoreLabel.text = "SCORE: "+score.ToString();
        //score += serviceQuality * counter * drink * type * tier * tip [?] * service[0,1]
        /*
        La mancia è definita da upgrade (più upgrade, più chance) di ottenere una mancia, definita da: n% dello score attuale o dell'ultimo ordine
        La qualità del servizio è data: Perfetto (x1.3), Buono (x1.0), Scarso (x0.5)
        */

        //0 = smallBeer, 1 = mediumBeer, 2 = largeBeer
        //3 = smallWine, 4 = mediumWine, 5 = largeWine
        //6 = smallJuice, 7 = mediumJuice, 8 = largeJuice

    }

    private double CalculateUpgradeBonus()
    {
        double bonus = (score * SaveManager.SV_UPGRADE_BONUS_PIPES) / 100 + (score * SaveManager.SV_UPGRADE_BONUS_DRINKS) / 100 
        +   (score * SaveManager.SV_UPGRADE_BONUS_CASH) / 100;
        return bonus;
    }

    private float CalculateDrinkScore()
    {
        //Calculating drink (wine, beer, juice)
        int activeGlass = BarManager.GetInstance().GetActiveGlass();
        if (activeGlass >= 0 && activeGlass <= 2) drinkScore = 1.4f;
        else if (activeGlass >= 3 && activeGlass <= 5) drinkScore = 1.5f;
        else if (activeGlass >= 6 && activeGlass <= 8) drinkScore = 1f;

        return drinkScore;
    }

    private float CalculateDrinkType()
    {
        //Calculate type (left, middle, right)
        int drinkType = BarManager.GetInstance().activeGlassObject.GetComponent<Glass>().drinkType;
        if (drinkType == 0) drinkTypeScore = 1.15f;
        else if (drinkType == 1) drinkTypeScore = 1f;
        else if (drinkType == 2) drinkTypeScore = 1.25f;

        return drinkTypeScore;
    }

    private float CalculateCustomerTier(GameObject customer)
    {
        switch(GameManager.GetInstance().currentTier)
        {
            case 0:
                customerTierScore = 1f;
                break;
            case 1:
                customerTierScore = 1.3f;
                break;
            case 2:
                customerTierScore = 1.8f;
                break;
            case 3:
                customerTierScore = 2.5f;
                break;
        }
        return customerTierScore;
    }
}
