using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public ParticleSystem blueExplosion;
    public ParticleSystem redExplosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "RedObj")
        {
            other.GetComponent<AsteriodBehavior>().Destroy();
            Instantiate(redExplosion, other.transform.position, new Quaternion());
        }

        if(other.tag == "BlueObj")
        {
            other.GetComponent<AsteriodBehavior>().Destroy();
            Instantiate(blueExplosion, other.transform.position, new Quaternion());
        }


    }
}
