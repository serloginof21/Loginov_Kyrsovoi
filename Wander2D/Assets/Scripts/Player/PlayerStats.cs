using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int coinCount = 0;
    public int flowerCount = 0;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Coin")){
            coinCount += 1;
        }

        if(other.CompareTag("Flower")){
            flowerCount += 1;
        }
    }
}
