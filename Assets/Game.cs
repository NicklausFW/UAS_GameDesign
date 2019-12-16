using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public AppManager appManager;
    public SpaceShip player;
    //referensi ke UI
    public Text scoreText;
    public Text health;
    public Text scoreFinal;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        health.text = player.heath.ToString();
        {
            appManager.OnGameover();
            scoreFinal.text = scoreText.text;
            score = 0;
            player.heath = 5;
        }
    }
}
