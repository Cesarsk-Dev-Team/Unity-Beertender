using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{

    //Private variables
    private GameObject customerManager;
    private IEnumerator coroutine;
    [SerializeField] private int[] chanceDrink = { 0, 0, 0 };
    [SerializeField] private int[] chanceType = { 0, 0, 0 };
    [SerializeField] private int[] chanceSize = { 0, 0, 0 };

    //Public variabless
    [HideInInspector]
    public int drink, drinkSize, drinkType;
    [HideInInspector]
    public long RFID;

    public int seat;

    //Methods
    void Start()
    {
        //pick randomly drink, size and type
        PickOrder();
    }

    void SetDrinkDialog(Sprite sprite)
    {
        GameObject drinkDialog = transform.GetChild(0).GetChild(1).gameObject;

        drinkDialog.transform.SetParent(gameObject.transform.GetChild(0));
        if (drinkDialog == null) drinkDialog.AddComponent<SpriteRenderer>();
        drinkDialog.GetComponent<SpriteRenderer>().sortingOrder = 1;
        drinkDialog.GetComponent<SpriteRenderer>().sprite = sprite;
        drinkDialog.transform.localScale = new Vector2(0.31f, 0.22f);
        drinkDialog.transform.position =
            new Vector2(gameObject.transform.GetChild(0).transform.position.x,
            gameObject.transform.GetChild(0).transform.position.y + 0.1f);
    }

    void FindCustomerType()
    {
        //Finding customer's category by its prefab name
        //Maid(clone) -> Maid
        /*type = gameObject.name;
        type = type.Substring(0, type.IndexOf('('));
        Debug.Log(type);*/
    }

    private void PickOrder()
    {
        int random_drink = Random.Range(0, 100);
        int random_type = Random.Range(0, 100);
        int random_size = Random.Range(0, 100);


        //0-33 drink = 0, 33-66 drink = 1, 66-100 drink = 2
        if (random_drink < chanceDrink[0]) drink = 0;
        if (random_drink >= chanceDrink[0] && random_drink < (chanceDrink[0] + chanceDrink[1])) drink = 1;
        if (random_drink >= (chanceDrink[0] + chanceDrink[1]) && random_drink <= (chanceDrink[0] + chanceDrink[1] + chanceDrink[2])) drink = 2;

        if (random_type < chanceType[0]) drinkType = 0;
        if (random_type >= chanceType[0] && random_type < (chanceType[0] + chanceType[1])) drinkType = 1;
        if (random_type >= (chanceType[0] + chanceType[1]) && random_type <= (chanceType[0] + chanceType[1] + chanceType[2])) drinkType = 2;

        if (random_size < chanceSize[0]) drinkSize = 0;
        if (random_size >= chanceSize[0] && random_size < (chanceSize[1] + chanceSize[0])) drinkSize = 1;
        if (random_size >= (chanceSize[1] + chanceSize[0]) && random_size <= (chanceSize[1] + chanceSize[0] + chanceSize[2])) drinkSize = 2;


        PickSprite(drink, drinkSize, drinkType);
    }
    void PickSprite(int drink, int size, int color)
    {
        //drink = 0,1,2 (beer, wine, juice)
        //color = 0,1,2 (left, middle, right)
        //size = 0,1,2 (small, medium, large)

        int index = color * 3 + size;
        Sprite sprite = Resources.Load("Drinks/" + drink + "/" + index, typeof(Sprite)) as Sprite;

        SetDrinkDialog(sprite);
    }

    public void ServeButton() 
    { 
        customerManager.SendMessage("ServeBeer", RFID);
    }

    public void GetCustomerManager(GameObject manager, long id, int table)
    {
        customerManager = manager;
        RFID = id;
        seat = table;
    }
}
