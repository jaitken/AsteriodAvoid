using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UpdateTimer : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 0.0f;
    public static int seconds;
    public TextMeshProUGUI time;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)(timer % 60);
        int countdown = 59 - seconds;
        time.text = countdown.ToString();
        
        if(seconds >= 59)
        {
            if (PlayerController.score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", PlayerController.score);
            }

            SceneManager.LoadScene(3);

        }
    }
}
