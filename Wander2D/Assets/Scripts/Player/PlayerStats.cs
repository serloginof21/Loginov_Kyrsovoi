using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int health = 1;
    public int coinCount = 0;
    public int flowerCount = 0;
    public CoinsText coinsText;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Coin")){
            coinCount += 1;
        }

        if(other.CompareTag("Flower")){
            flowerCount += 1;
        }
    }

    private void Update() {
        if(health <= 0){
            coinsText.ResetCoinCount();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
