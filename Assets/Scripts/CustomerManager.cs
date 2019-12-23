using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 *      Queue: 4 active elements + 2 waiting for seats.
 *      Size: max 6
 *      
 *      Game starts and algorithm start spawning customers (Add element on queue every ten seconds)
 *      SpawnCustomer: size++
 *      ServeBeer: size--, push queue
 * */

/*
 * TO DO: GameOver denies perfect
 * TO DO: Score Formula
 * 
 * */


public class CustomerManager : MonoBehaviour
{
    //Serialized Fields
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[][] customers;
    [SerializeField] private GameObject[] customersTierZero;
    [SerializeField] private GameObject[] customersTierOne;
    [SerializeField] private GameObject[] customersTierTwo;
    [SerializeField] private GameObject[] customersTierThree;
    [SerializeField] private GameObject[] customersTierFour;
    [SerializeField] private GameObject[] activeCustomers; //our active customers
    [SerializeField] private bool[] customersSeats; //locks for our seats
    [SerializeField] private GameObject service;

    //private variables
    private static CustomerManager instance;
    private int customersCounter = 0;

    public static CustomerManager GetInstance()
    {
        return instance;
    }
    public void ServeBeer(double RFID)
    {
        try
        {
            if (service.transform.GetChild(0).tag == "Glass" && service.transform.GetChild(0).GetComponent<Glass>().isBusy)
            {
                // Serve the client here
                for (int i = 0; i < activeCustomers.Length; i++)
                {
                    GameObject obj = activeCustomers[i];
                    if (obj != null)
                    {
                        if (obj.GetComponent<Customer>().RFID == RFID)
                        {
                            //Check if drink is the one asked
                            //Debug.Log("Serving Client: " + obj.name);
                            BarManager.GetInstance().CleanGlassNoSound(); // Deleting Pool Drink
                            if (CheckIfServiceRight(obj, service.transform.GetChild(0).gameObject))
                            {
                                Score.GetInstance().CalculateScore(obj); // Calculate and Display Score
                                                                         // Animate Customer (Customer is drinking)
                                                                         // Customer goes away after drinking
                            }

                            obj.GetComponent<Animator>().SetTrigger("Served"); // Client's Trigger
                            obj.transform.GetChild(0).GetChild(0).GetComponent<Animator>().SetTrigger("Served"); //Dialog Outline trigger

                            //reactions triggers
                            obj.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Served");

                            //obj.transform.GetChild(2).GetComponent<Animator>().SetTrigger("Served");
                            //obj.transform.GetChild(3).GetComponent<Animator>().SetTrigger("Served");

                            Destroy(service.transform.GetChild(0).gameObject); // Destroying Current Glass

                            Destroy(obj, 3.5f);     // CustomerManager destroys Customer
                            customersSeats[obj.GetComponent<Customer>().seat] = false; //freeing customer's seat

                            customersCounter--;
                        }
                    }
                }
            }
        }

        catch (UnityException e)
        {
            //Glass not found exception
            string s = e.StackTrace;
            //Debug.Log("Glass Not Found");
        }
    }
    public void CustomerLeaves(double RFID)
    {
        // Serve the client here
        for (int i = 0; i < activeCustomers.Length; i++)
        {
            GameObject obj = activeCustomers[i];

            if (obj != null)
            {
                if (obj.GetComponent<Customer>().RFID == RFID)
                {
                    Debug.Log(obj.GetComponentInParent<Customer>().RFID);
                    // Penalty
                    // Animate Customer (Customer is drinking)

                    obj.GetComponent<Animator>().SetTrigger("Served"); // Client's Trigger
                    obj.GetComponent<Animator>().SetTrigger("Wrong");
                    obj.transform.GetChild(0).GetChild(0).GetComponent<Animator>().SetTrigger("Served"); //Dialog Outline trigger

                    //reactions triggers
                    obj.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Served");
                    obj.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Wrong");
                    

                    Destroy(obj, 3.5f);     // CustomerManager destroys Customer
                    customersSeats[obj.GetComponent<Customer>().seat] = false; //freeing customer's seat

                    customersCounter--;

                    GameManager.GetInstance().DecreaseLife();
                }
            }
        }
    }

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }
    private void Start()
    {
        customers = new GameObject[5][];
        customers[0] = customersTierZero;
        customers[1] = customersTierOne;
        customers[2] = customersTierTwo;
        customers[3] = customersTierThree;
        customers[4] = customersTierFour;

        InvokeRepeating("SpawnCustomer", 1, 5);
    }

    private void SpawnCustomer()
    {
        if (customersCounter <= 3)
        {
            int randomCustomer = Random.Range(0, customers[GameManager.GetInstance().currentTier].Length);
            GameObject randomCustomerObj = customers[GameManager.GetInstance().currentTier][randomCustomer];
            int seat = Random.Range(0, 4); //check where to sit
            while (customersSeats[seat])
            {
                seat = Random.Range(0, 4);
            }
            long RFIDCustomer = Random.Range(1, 30000);
            activeCustomers[seat] = Instantiate(randomCustomerObj, spawnPoints[seat].transform.position, Quaternion.identity);
            activeCustomers[seat].transform.SetParent(spawnPoints[seat].transform);
            activeCustomers[seat].GetComponent<Customer>().GetCustomerManager(gameObject, RFIDCustomer, seat);
            customersCounter++;
            customersSeats[seat] = true;
        }
    }

    private bool CheckIfServiceRight(GameObject customer, GameObject glass)
    {
        if (customer.GetComponent<Customer>().drinkType == glass.GetComponent<Glass>().drinkType &&
            customer.GetComponent<Customer>().drinkSize == glass.GetComponent<Glass>().drinkSize &&
            customer.GetComponent<Customer>().drink == glass.GetComponent<Glass>().drink)
        {
            //serviceLabel.text = "SERVICE: RIGHT";
            return true;
        }
        else
        {
            customer.GetComponent<Animator>().SetTrigger("Served"); // Client's Trigger
            customer.transform.GetChild(0).GetChild(0).GetComponent<Animator>().SetTrigger("Served"); //Dialog Outline trigger

            //reactions triggers
            customer.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Served");
            customer.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Wrong");
            customer.GetComponent<Animator>().SetTrigger("Wrong");

            GameManager.GetInstance().DecreaseLife();
            return false;
        }
    }

    private void DebugLog()
    {
        Debug.Log("Debugging Variables: ");
        Debug.Log("Customer Counter: " + customersCounter);
    }
}
