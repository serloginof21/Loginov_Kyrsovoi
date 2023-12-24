using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameObject door, openDoor;

    private void OnTriggerEnter2D(Collider2D other) {
        if(playerStats.coinCount >= 3){
            door.SetActive(false);
            openDoor.SetActive(true);
        }
        else{
            door.SetActive(true);
            openDoor.SetActive(false);
        }
    }
}
