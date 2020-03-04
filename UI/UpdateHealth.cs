using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Text currHP;
    public GameObject Player;
    private float playerHP;
    
    void Start()
    {
        playerHP = Player.GetComponent<PlayerController>().hp;
        currHP.text = "HP: " + playerHP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        playerHP = Player.GetComponent<PlayerController>().hp;
        currHP.text = "HP: " + playerHP.ToString();
    }
}
