using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {

    public int type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "GameOver Trigger")
        {
            StartCoroutine(DropsCollector());
            Score.GetInstance().PenaltyScore();
        }
    }

    IEnumerator DropsCollector()
    {
        //Debug.Log("Starting Garbage Collector Process...");
        yield return new WaitForSeconds(2f);
        //Debug.Log("Garbage Cleaned");
        Destroy(gameObject);
    }
}
