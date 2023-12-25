using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinsText : MonoBehaviour
{
    public static int Coin = 0;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = Coin.ToString();
    }
    public void ResetCoinCount() {
        Coin = 0;
    }
}
