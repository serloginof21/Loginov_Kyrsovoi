using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            changeScene(1);
        }
    }

    public void changeScene(int scene){
        SceneManager.LoadScene(scene + 1);
    }
}
