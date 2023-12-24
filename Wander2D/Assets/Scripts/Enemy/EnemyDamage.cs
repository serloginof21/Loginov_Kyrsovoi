using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerStats playerHealth;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            playerHealth.health -= 1;
        }
    }
}
