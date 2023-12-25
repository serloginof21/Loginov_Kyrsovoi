using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;
    int sceneIndex;
    int levelComplete;
    public CoinsText coinsText;

    void Start()
    {
        if(instance == null){
            instance = this;
        }

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }

    public void IsEndGame(){
        if(sceneIndex == 2){
            Invoke("LoadMainMenu", 1f);
        }
        else{
            if(levelComplete < sceneIndex){
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
            }
            Invoke("NextLevel", 1f);
        }
    }

    void NextLevel(){
        SceneManager.LoadScene(sceneIndex + 1);
        coinsText.ResetCoinCount();
    }

    void LoadMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
