using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private float angle;
    public static int score;
    private int gameMode;

    private Vector3 movement;
    private float moveV;
    private float moveH;
    private Vector3 boosterSpeed = new Vector3(0f,0f,2000f);
    private bool boost = false;
    private bool boostReady = true;
    private float boostTimer;

    private bool flip = false;
    private Vector3 dir;

    public float speed;
    public Camera cam;

    public float hp;
    private float maxHp = 6;
    private float ShieldTimer = 700;
    private float shield = 0;
    private static bool shielded = false;
    public GameObject playerShieldAsset;
    private GameObject playerShield;



    void Start()
    {
        gameMode = SceneManager.GetActiveScene().buildIndex;
        AsteriodBehavior.particlesDestroyed = 0;    
        score = 0;
        hp = maxHp;
        rb = GetComponent<Rigidbody>();
        Renderer r = gameObject.GetComponent<Renderer>();
        r.material.color = Color.magenta;
    }

    //regular update to recieve controls
    void Update()
    {

        //calculate player rotation
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = cam.WorldToScreenPoint(transform.position);
        if (!flip)
        {
            dir = mousePos - playerPos;
        }
        else
        {
            dir = playerPos - mousePos;
        }
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;


        //capturing player movement, boosting, and flipping
        moveV = Input.GetAxis("Vertical");
        moveH = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown("space") && boostReady)
        {
            boost = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {


            if (flip)
            {
                flip = false;
            }
            else
            {
                flip = true;
            }

          
            
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //take away health if hit
        if(collision.collider.tag == "RedObj" || collision.collider.tag == "BlueObj")
        {
            if(!shielded)
            hp--;
        }

        //end the game if HP == 0, check and update highscore
       if(gameMode == 1)
        {
            if (hp == 0)
            {
                if (score > PlayerPrefs.GetInt("highScore"))
                {
                    PlayerPrefs.SetInt("highScore", score);
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

            }
        }
       


    }


    // fixed update to execute
    void FixedUpdate()
    {

        //applying rotation 
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(-angle, Vector3.up), .2f);

        //applying movement
        movement = new Vector3(moveH, 0.0f, moveV);
        rb.AddForce(movement*speed);


        //applying boost
        if (boost)
        {
            rb.AddForce(movement*speed*20);
            boostReady = false;
            boost = false;
            boostTimer = 50;
        }

        if(boostTimer > 0)
        {
            boostTimer--;
        }
        if(boostTimer == 0)
        {
            boostReady = true;
        }

        //shieldpowerup
        if (shielded)
        {
            //spawn a shield on the first tick
            if(shield == 0)
            {
               playerShield = Instantiate(playerShieldAsset);
            }
            shield++;
            if(shield > ShieldTimer)
            {
                shield = 0;
                shielded = false;
                playerShield.GetComponent<PlayerShield>().Destroy();
            }
            playerShield.transform.position = transform.position;

        }
        
        
        //slowly lose velocity overtime
        rb.velocity = rb.velocity * 0.90f;

        //lock player on screen
        Vector3 verticalLockTop = new Vector3(transform.position.x, 0f, 40f);
        if (transform.position.z > 40)
        {
            transform.position = verticalLockTop;
        }
        Vector3 verticalLockBottom = new Vector3(transform.position.x, 0f, -53f);
        if (transform.position.z < -53)
        {
            transform.position = verticalLockBottom;
        }

        Vector3 horizontalLockRight = new Vector3(85f, 0f, transform.position.z);
        if (transform.position.x > 85)
        {
            transform.position = horizontalLockRight;
        }
        Vector3 horizontalLockLeft = new Vector3(-85f, 0f, transform.position.z);
        if (transform.position.x < -85)
        {
            transform.position = horizontalLockLeft;
        }

    }

    public static int getScore()
    {
        return score;
    }

    //used by the shieldPowerUp class
    public static void setShielded(bool s)
    {
        shielded = s;
    }

    public Vector3 getPosition()
    {
        return transform.position;
    }
    
}
