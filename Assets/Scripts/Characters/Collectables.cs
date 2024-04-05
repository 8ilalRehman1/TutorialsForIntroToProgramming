using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public string nameCollectable;
    public int score;
    public int restorehp;
    public Collectables(string name, int scoreValue, int restorehpValue)
    {
        this.nameCollectable = name;
        this.score = scoreValue;
        this.restorehp = restorehpValue;
    }
    public void UpdateScore()
    {
        ScoreManager.scoreManager.UpdateScore(score);
    }

    public int _coinCounter;
    //this variable is for counting the coins collected
    private void OnTriggerEnter(Collider other)
        //this function is for when a coin is collided
    {
        _coinCounter++;
        //increases counter
        if (other.transform.tag == "Player")
            //if statement for colliding
        {
            Destroy(gameObject);
            //destroys
            Debug.Log ("Coin Collected");
            //prints
        }
        Debug.Log(_coinCounter);
        //prints counter
    }
}

