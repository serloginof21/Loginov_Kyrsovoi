using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    public GameObject coin;
    public PlayerStats playerStats;
    public GameObject flowerNearStatue;

        private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(playerStats.flowerCount >= 1){
                coin.SetActive(true);
                playerStats.flowerCount -= 1;
                flowerNearStatue.SetActive(true);
            }
        }
    }
}
