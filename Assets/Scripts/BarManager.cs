using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour
{
    public GameObject activeGlassObject;
    private int activeGlass = 0;
    private const int offset = 3;
    private int activeDrink = 0; // 0 = beer, 1 = wine, 2 = juice
    private static BarManager instance;
    //activeGlass = activeGlass + (offset * activeDrink);

    //0 = smallBeer, 1 = mediumBeer, 2 = largeBeer
    //3 = smallWine, 4 = mediumWine, 5 = largeWine
    //6 = smallJuice, 7 = mediumJuice, 8 = largeJuice

    //public variables
    public GameObject[] glasses;
    public GameObject[] rails;
    public GameObject service;
    public GameObject pool;

    private AudioSource[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        sounds = AudioManager.GetInstance().GetSounds();
    }
    public static BarManager GetInstance()
    {
        return instance;
    }
    public void CleanGlass()
    {
        foreach (Transform child in pool.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        sounds[6].Play();
        if (activeGlassObject != null) activeGlassObject.GetComponent<Glass>().ResetCounter();
    }

    public void CleanGlassNoSound()
    {
        foreach (Transform child in pool.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        if (activeGlassObject != null) activeGlassObject.GetComponent<Glass>().ResetCounter();
    }

    public void ChangeGlass(int selectedGlass)
    {
        if (activeGlassObject != null)
        {
            if (activeGlassObject.GetComponent<Glass>().isBusy) return;
        }
        Destroy(activeGlassObject);
        activeGlass = selectedGlass + (offset * activeDrink);
        activeGlassObject = Instantiate(glasses[activeGlass], service.transform.position, Quaternion.identity);
        activeGlassObject.SetActive(true);
        activeGlassObject.transform.SetParent(service.transform);
    }
    public int GetActiveGlass()
    {
        return activeGlass;
    }
    public void ChangeDrink(int selectedDrink)
    {
        if (activeGlassObject != null)
        {
            if (activeGlassObject.GetComponent<Glass>().isBusy) return;
        }
        activeDrink = selectedDrink;
        for (int i = 0; i < 3; i++)
        {
            if (i == selectedDrink)
            {
                //Hierarchy: Beer -> Beer Middle -> (Spawn, Container, Faucet)
                //rails[i].SetActive(true);

                //Enabling container's and faucet's renderers
                rails[i].transform.GetChild(0).GetChild(1).GetComponent<Renderer>().enabled = true;
                rails[i].transform.GetChild(0).GetChild(2).GetComponent<Renderer>().enabled = true;

                rails[i].transform.GetChild(1).GetChild(1).GetComponent<Renderer>().enabled = true;
                rails[i].transform.GetChild(1).GetChild(2).GetComponent<Renderer>().enabled = true;

                rails[i].transform.GetChild(2).GetChild(1).GetComponent<Renderer>().enabled = true;
                rails[i].transform.GetChild(2).GetChild(2).GetComponent<Renderer>().enabled = true;

            }
            else
            {
                //rails[i].SetActive(false);
                rails[i].transform.GetChild(0).GetChild(1).GetComponent<Renderer>().enabled = false;
                rails[i].transform.GetChild(0).GetChild(2).GetComponent<Renderer>().enabled = false;

                rails[i].transform.GetChild(1).GetChild(1).GetComponent<Renderer>().enabled = false;
                rails[i].transform.GetChild(1).GetChild(2).GetComponent<Renderer>().enabled = false;

                rails[i].transform.GetChild(2).GetChild(1).GetComponent<Renderer>().enabled = false;
                rails[i].transform.GetChild(2).GetChild(2).GetComponent<Renderer>().enabled = false;

            }
        }
    }
}
