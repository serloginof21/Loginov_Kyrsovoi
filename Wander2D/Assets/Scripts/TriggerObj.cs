using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerObj : MonoBehaviour
{
    public GameObject signs;
    public GameObject coin;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Vase")){
            signs.SetActive(true);
            coin.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Vase")){
            signs.SetActive(true);
            coin.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Vase")){
            signs.SetActive(false);
            coin.SetActive(false);
        }
    }
}
