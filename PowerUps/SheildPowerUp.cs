using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildPowerUp : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.setShielded(true);
            Destroy();
        }
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - .25f);

        if(transform.position.z < -68)
        {
            Destroy();
        }
        if (transform.position.x < -89)
        {
            Destroy();
        }
        if (transform.position.x > 89)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        
        Destroy(gameObject);
    }
}
