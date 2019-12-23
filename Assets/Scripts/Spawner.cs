using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    //Public variables
    public Transform spawnPoint;
    public GameObject prefab;
    public GameObject pool;
    public int spawnMultiplier = 1;
    public int capacity;
    public int type; // 0=beer, 1=wine, 2=juice
    public Button refillButton;
    public Animator capacityAnimator;

    //Private variables
    private int maxCapacity;
    private float thresholdCapacityInPercentage;
    private const int REFILL_TIME = 10; //needs to be the same as the animation's length
    private bool isDispenserEnabled = false;
    private int percentage = 9; //this is for handling the capacity animator and its animation
    private bool isRefilling = false;

    //Methods
    private void Start()
    {
        switch(type)
        {
            case 0:
            //Debug.Log("["+gameObject.name+"] Beer Set Capacity: "+SaveManager.SV_UPGRADE_CAPACITY_BEER);
            capacity = SaveManager.SV_UPGRADE_CAPACITY_BEER * Constants.UPGRADE_BEER_CAPACITY_MULTIPLIER;
            break;

            case 1:
            //Debug.Log("["+gameObject.name+"] Wine Set Capacity: "+SaveManager.SV_UPGRADE_CAPACITY_WINE);
            capacity = SaveManager.SV_UPGRADE_CAPACITY_WINE * Constants.UPGRADE_WINE_CAPACITY_MULTIPLIER;
            break;

            case 2:
            //Debug.Log("["+gameObject.name+"] Juice Set Capacity: "+SaveManager.SV_UPGRADE_CAPACITY_JUICE);
            capacity = SaveManager.SV_UPGRADE_CAPACITY_JUICE * Constants.UPGRADE_JUICE_CAPACITY_MULTIPLIER;
            break;
        }
        maxCapacity = capacity;
    }
    void Update()
    {
        CheckPosition();
        if (isDispenserEnabled)
        {
            if(isSpilling) SpillDrink();
        }
    }
	private void CheckPosition()
	{
        float x = transform.position.x;
		if (x > -0.8f && x < 0.8f) isDispenserEnabled = true;
		else isDispenserEnabled = false;
	}
    private bool isSpilling = false;
    private void SpawnPrefab(GameObject liquid, Vector3 position)
    {
        GameObject block = Instantiate(liquid, position, Quaternion.identity);
        block.transform.SetParent(pool.transform);
        capacity--;
        
        if(capacity <= (maxCapacity * percentage) / 10)
        {
            capacityAnimator.SetInteger("Capacity", percentage);
            percentage--;
            if(percentage == -1)
            {
                refillButton.gameObject.SetActive(true);
            }
        }

        //Gravity Upgrades
        if(type == 0) block.GetComponent<Rigidbody2D>().gravityScale = UpgradeManager.GetInstance().UPGRADE_BEER_GRAVITY;
        else if(type == 1) block.GetComponent<Rigidbody2D>().gravityScale = UpgradeManager.GetInstance().UPGRADE_WINE_GRAVITY;
        else if(type == 2) block.GetComponent<Rigidbody2D>().gravityScale = UpgradeManager.GetInstance().UPGRADE_JUICE_GRAVITY;
        Debug.Log(block.GetComponent<Rigidbody2D>().gravityScale);
    }

    public void EnableSpill()
    {
        isSpilling = true;
    }
    public void DisableSpill()
    {
        isSpilling = false;
    }
    public void SpillDrink()
    {
        for (int i = 0; i < spawnMultiplier; i++)
        {
            Debug.Log("capacity: "+capacity);
            Debug.Log("Enabled: "+transform.GetChild(1).GetComponent<Renderer>().enabled);
            if (capacity > 0 && !isRefilling && transform.GetChild(1).GetComponent<Renderer>().enabled == true)
            {
                SpawnPrefab(prefab, spawnPoint.position);
            }
        }
    }

    public void RefillButton()
    {
        //TO DO SUBTRACT SCORE TO REFILL
        if(!isRefilling) StartCoroutine(RefillTimer());
        isRefilling = true;
        percentage = 9;
        capacityAnimator.SetInteger("Capacity", 10);
    }

    private IEnumerator RefillTimer()
    {
        refillButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(REFILL_TIME);
        capacity = maxCapacity;
        isRefilling = false;
    }
}
