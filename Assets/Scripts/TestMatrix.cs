using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour {

    public GameObject[] vectorOne;
    public GameObject[] vectorTwo;
    private GameObject[][] matrix;

	// Use this for initialization
	void Start () {
        matrix = new GameObject[2][];
        matrix[0] = vectorOne;
        matrix[1] = vectorTwo;
        Print();
	}
	
    void Print()
    {
        for (int i = 0; i < vectorOne.Length; i++)
        {
            Debug.Log("" + matrix[0][i].name);
        }
        for (int i = 0; i < vectorTwo.Length; i++)
        {
            Debug.Log("" + matrix[1][i].name);
        }
    }
}
