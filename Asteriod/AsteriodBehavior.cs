using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private float minSpeed = 20;
    private float maxSpeed = 60;
    protected bool explosion = false;
    public GameObject shieldPowerUp;
    public bool magnetized;

    protected Vector3 startPosition;

    public static float particlesDestroyed = 0;

    public virtual void Start()
    {
        //set start positon(decided in Asteriod class)
        transform.position = startPosition;

        //set a random size 
        float size = Random.Range(4f, 8f);
        transform.localScale = new Vector3(size, size, size);

        //assign rigidbody to var rb
        rb = gameObject.GetComponent<Rigidbody>();

        //add mass relative to size
        rb.mass = size/3;

        //add a random force for initial direction
        rb.AddForce(Random.Range(-75f, 75f)*50, 0f, Random.Range(-70f, -30f)*50);
        rb.AddTorque(Random.Range(5, 10f)*100, Random.Range(5f, 10f)*100, Random.Range(5f, 10f)*100);
    }


    // Update is called once per frame
    protected void Update()
    {
        PlayerController.score = (int)particlesDestroyed;
    }

    protected virtual void FixedUpdate()
    {
        
        //increase speed if below max speed
        if(rb.velocity.magnitude < minSpeed)
        {
            rb.velocity = rb.velocity * 1.05f;
        }

        //decrease speed if above max speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity * .90f;
        }

        if(transform.position.z < -70)
        {
            Destroy();
        }

        if (transform.position.z > 100)
        {
            Destroy();
        }

        if (transform.position.x < -90)
        {
            Destroy();
        }

        if (transform.position.x > 90)
        {
            Destroy();
        }


    }

    public virtual void Destroy()
    {
        //asteriods may spawn a shield when destroyed
        float x = Random.Range(0f, 100f);
        if(x > 98)
        {
            Instantiate(shieldPowerUp, transform.position, new Quaternion());
        }
        Destroy(gameObject);
    }
}
