using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public CoinsText CoinsText { get; set; }
    public void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            CoinsText.Coin += 1;
            Destroy(gameObject);
        }
    }
}
