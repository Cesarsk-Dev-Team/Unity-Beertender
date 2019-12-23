using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour {

    public bool isBusy = false; // if !isBusy the glass can be changed clicking on the UI. If not, you need to clean or serve the glass first.
    private int counter;

    public int drink, drinkSize, drinkType;

    // Use this for initialization
    void Start()
    {
        isBusy = false;
    }
    public void ResetCounter()
    {
        counter = 0;
        isBusy = false;
        RailManager.isBusy = false;
    }
    public int GetCounter()
    {
        return counter;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        counter++;
        isBusy = true;
        RailManager.isBusy = true;
        drinkType = collider.GetComponent<Drop>().type;
        //Debug.Log(" " +collider.gameObject.name+ ":" +counter);
        Score.GetInstance().UpdateCounter(counter);
        Score.GetInstance().UpdateDrink(collider.name);
    }
}
