using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int coinCount = 0;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Coin")){
            coinCount += 1;
        }
    }
}
