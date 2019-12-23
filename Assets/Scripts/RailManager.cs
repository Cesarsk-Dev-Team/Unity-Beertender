using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailManager : MonoBehaviour {

	public static bool isBusy = false; // if isBusy, the rail position is locked until it's served / cleaned the drink

	void Start () {
		//Simply enabling the rails in the right order
	    transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Renderer>().enabled = true;
		transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Renderer>().enabled = true;

		transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Renderer>().enabled = true;
		transform.GetChild(0).GetChild(1).GetChild(2).GetComponent<Renderer>().enabled = true;

	    transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Renderer>().enabled = true;
		transform.GetChild(0).GetChild(2).GetChild(2).GetComponent<Renderer>().enabled = true;

	    transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Renderer>().enabled = false;
		transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<Renderer>().enabled = false;

		transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Renderer>().enabled = false;
		transform.GetChild(1).GetChild(1).GetChild(2).GetComponent<Renderer>().enabled = false;

	    transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<Renderer>().enabled = false;
		transform.GetChild(1).GetChild(2).GetChild(2).GetComponent<Renderer>().enabled = false;

	    transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<Renderer>().enabled = false;
		transform.GetChild(2).GetChild(0).GetChild(2).GetComponent<Renderer>().enabled = false;

		transform.GetChild(2).GetChild(1).GetChild(1).GetComponent<Renderer>().enabled = false;
		transform.GetChild(2).GetChild(1).GetChild(2).GetComponent<Renderer>().enabled = false;

	    transform.GetChild(2).GetChild(2).GetChild(1).GetComponent<Renderer>().enabled = false;
		transform.GetChild(2).GetChild(2).GetChild(2).GetComponent<Renderer>().enabled = false;
	}
}
