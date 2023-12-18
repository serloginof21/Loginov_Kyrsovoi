using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPanel : MonoBehaviour
{
    public Animator[] panel;
    public PlayerStats playerStats;
    public GameObject door, openDoor;

    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            foreach(Animator animator in panel){
                animator.SetTrigger("IsTrigger");
            }
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

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            foreach(Animator animator in panel){
                animator.SetTrigger("IsTrigger");
            }
        }
    }
}
