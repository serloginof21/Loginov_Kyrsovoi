using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public Button levelTwo;
    int levelComplete;

    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        levelTwo.interactable = false;

        switch(levelComplete){
            case 1:
                levelTwo.interactable = true;
                break;
        }
    }

    public void LoadTo(int level){
        SceneManager.LoadScene(level);
    }

    public void Reset(){
        levelTwo.interactable = false;
        PlayerPrefs.DeleteAll();
    }

    public void Exit(){
        Application.Quit();
    }
}
