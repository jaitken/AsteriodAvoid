using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UpdateFinalScore : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI highScore;
    private int playerScore;

    void Start()
    {
        playerScore = PlayerController.getScore();
        if (playerScore > PlayerPrefs.GetInt("highScore")){
            PlayerPrefs.SetInt("highScore", playerScore);
        }
        //score = GetComponent<TextMeshProUGUI>();
        highScore.text = "Highscore: " + PlayerPrefs.GetInt("highScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        highScore.text = "Highscore: " + PlayerPrefs.GetInt("highScore").ToString();
    }
}
