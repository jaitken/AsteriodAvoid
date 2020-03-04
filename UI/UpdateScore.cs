using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI score;
    private int playerScore;

    void Start()
    {
        playerScore = PlayerController.getScore();
        //score = GetComponent<TextMeshProUGUI>();
        score.text = "Score: " + playerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        playerScore = PlayerController.getScore();
        score.text = "Score: " + playerScore.ToString();
    }
}
