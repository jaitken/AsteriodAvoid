using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject redAsteriod;
    public GameObject blueAsteriod;
    private float counter = 0;
    float spawn = 0;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float rate = 80;
        rate = rate - UpdateTimer.seconds;
        Debug.Log(rate);
        if (counter % rate == 0)    
        {
            switch (spawn)
            {
                case 0:
                    Instantiate(redAsteriod);
                    spawn = 1;
                    break;
                case 1:
                    Instantiate(blueAsteriod);
                    spawn = 0;
                    break;
             
            }
           
        }

        
        rate = rate - UpdateTimer.seconds;
        counter++;
        
    }
}
