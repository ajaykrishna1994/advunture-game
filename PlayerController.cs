using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   

    public float horizontalMove =0f;
    public float verticallMove = 0f;
    public float runSpeed=7;
    public bool isOnGrount = true;
    public bool isHurt = false;
    public bool enemyBorder;
    private bool gameOver = false;
    public bool warning3 = false;

    public GameObject enemy;
    public GameObject bulletPrefab;
    public GameObject gameObjectToMove;
    public GameObject warningText;
    public GameObject warning;
    public GameObject enemything;
    public GameObject wall2;
    public GameObject warning3wall;
    public GameObject warningthingFinal;

    public int JumpCount;
    public int maxHealth = 20;
    public int currentHealth;
    public int jump = 0;
    int splittedScreen = Screen.width / 2;

    public Joystick joystik;

    public Animator animatior;

    private Rigidbody2D rigidBody;

    private AudioSource playerAudio;
    public AudioClip gunsound;
    public AudioClip enemyHahaha;
    public AudioClip pain;


    BoxCollider2D m_Collider;

    private Vector2 startingPoint;

    public GameManager gameManagerScript;
    public Health healthBar;
    public bulletScript bulletScript;

   


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        rigidBody = GetComponent<Rigidbody2D>();
        m_Collider = GetComponent<BoxCollider2D>();

        animatior.SetBool("isHurt", false);
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
      

    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerScript.isGameActive)
        {
            /*   int i = 0;

               if (Input.GetMouseButtonDown(2))
               {
                   if (Input.mousePosition.x < Screen.width / 2)
                   {
                       shootBullet();
                       //Move Player Left
                   }

               }
               else
               {
                   animatior.SetBool("isShoot", false);
               }*/


            /*  var tapCount = Input.touchCount;



               for (var i = 0; i < tapCount; i++)
              {
                  var touch = Input.GetTouch(i);
                  Debug.Log("touched");
                  
              }*/

            int i = 0;
            while (i < Input.touchCount)
            {
                Touch t = Input.GetTouch(i);
                if (t.position.x < Screen.width / 2)
                {
                    if (t.phase == TouchPhase.Began)
                    {
                        Debug.Log("left ");
                        shootBullet();

                    }
                  
                }
                  
              /*  else if (t.phase == TouchPhase.Ended)
                {
                    Debug.Log("touch ended");
                  //  touchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchId == t.fingerId);
                  //  Destroy(thisTouch.circle);
                   // touches.RemoveAt(touches.IndexOf(thisTouch));
                }
                else if (t.phase == TouchPhase.Moved)
                {
                    Debug.Log("touch is moving");
                   // touchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchId == t.fingerId);
                  //  thisTouch.circle.transform.position = getTouchPosition(t.position);
                }*/
                ++i;
            }

            horizontalMove = joystik.Horizontal * runSpeed;
            animatior.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (horizontalMove >= .2f)
            {
                transform.Translate(Vector2.right * Time.deltaTime * runSpeed);

            }
            else if (horizontalMove <= -.2f)
            {
                if (transform.position.x < -7)
                {
                    transform.position = new Vector2(-7, transform.position.y);
                }

                transform.Translate(Vector2.left * Time.deltaTime * runSpeed);

            }



            verticallMove = joystik.Vertical;


            if (verticallMove >= .5f && isOnGrount == true)
            {
                rigidBody.AddForce(Vector2.up * 250);




                isOnGrount = false;


            }

            if (verticallMove <= -.5f && isOnGrount == true)
            {


                animatior.SetBool("isCrouch", true);
                m_Collider.size = new Vector2(0.240652F, 0.3533852F);

            }
            else
            {
                animatior.SetBool("isCrouch", false);
                m_Collider.size = new Vector2(0.2149089F, 0.4447858F);

            }



            if (isOnGrount == false)
            {
                animatior.SetBool("isJumping", true);
                jump = 1;
            }
            else
            {
                animatior.SetBool("isJumping", false);
                jump = 0;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAudio.PlayOneShot(gunsound, 1.0f);
                animatior.SetBool("isShoot", true);
                bulletScript.Shooting();
                shootBullet();


            }
            else
            {
                animatior.SetBool("isShoot", false);
            }

            if (gameOver)
            {
                
                Debug.Log("gameOver working");
            }
        }
      

    }


    private void  OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.CompareTag("ground"))
        {
           
            isOnGrount = true;
            
           
        }
        if (collision.gameObject.CompareTag("spider"))
        {

            TakeDamage(5);


        }
        if (collision.gameObject.CompareTag("thingbullet"))
        {

            Debug.Log("bhoom");
          //  enemy.SetActive(true);
            animatior.SetBool("isHurt", true);
            isHurt = true;
            StartCoroutine(boolFun());
            TakeDamage(5);
            enemyBorder = true;
            Destroy(collision.gameObject);





        }



    }
    void OnTriggerEnter2D(Collider2D colisions)
    {
        if (colisions.gameObject.CompareTag("warning"))
        {

            Debug.Log("warning");
          
            StartCoroutine(Enemyactive());
            warningText.SetActive(true);
            playerAudio.PlayOneShot(enemyHahaha, 1.0f);

        }
        if (colisions.gameObject.CompareTag("warningthing"))
        {

            Debug.Log("warningthing");

            StartCoroutine(warningthing());
          //  warningText.SetActive(true);
            playerAudio.PlayOneShot(enemyHahaha, 1.0f);

        }



        if (colisions.gameObject.CompareTag("bullet")        )
        {

            Debug.Log("bhoom");
         //   enemy.SetActive(true);
            animatior.SetBool("isHurt", true);
            isHurt = true;
            StartCoroutine(boolFun());
            TakeDamage(5);
            enemyBorder = true;
            Destroy(colisions.gameObject);





          
        }


        if (colisions.gameObject.CompareTag("warning2"))
        {
            warning3 = true;
            Debug.Log("warning3");

            wall2.SetActive(true);
            StartCoroutine(ThingHaha());






        }
        if (colisions.gameObject.CompareTag("warning3"))
        {
            warning3 = true;
            Debug.Log("warning3");

            warning3wall.SetActive(true);
            StartCoroutine(ThingHaha());






        }



    }


    private void shootBullet()
    {
      
        Debug.Log("shooting"); 
        Instantiate(bulletPrefab, new Vector2(transform.position.x+2 , transform.position.y+.5f), transform.rotation);
    }

      IEnumerator boolFun()
    {

      
        yield return new WaitForSeconds(0.2f);
        animatior.SetBool("isHurt", false);

    }


    void TakeDamage(int damage)
    {
        playerAudio.PlayOneShot(pain, 1.0f);

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth==0)
        {
            gameManagerScript.GameOver();
            gameOver = true; ;
            Destroy(gameObject);
            Debug.Log("health loss");
          
         
          
        }
    }

    IEnumerator Enemyactive()
    {
        warning.SetActive(false);
        yield return new WaitForSeconds(3);
        enemy.SetActive(true);
        warningText.SetActive(false);
        playerAudio.PlayOneShot(enemyHahaha, 1.0f);
    }
    IEnumerator warningthing  ()
    {
      //  warning.SetActive(false);
        yield return new WaitForSeconds(3);
        enemything.SetActive(true);
        StartCoroutine(deactivewarningWall());
        // warningText.SetActive(false);
       
    }
    IEnumerator deactivewarningWall()
    {
        playerAudio.PlayOneShot(enemyHahaha, 1.0f);
        yield return new WaitForSeconds(1);
        warningthingFinal.SetActive(false);
       

    }

    IEnumerator ThingHaha()
    {
      
        yield return new WaitForSeconds(3);
        StartCoroutine(ThingHaha());

    }
    /* IEnumerator ThingEnemyactive()
     {
         warning.SetActive(true);
         yield return new WaitForSeconds(3);
         thingenemy.SetActive(true);
         warningText.SetActive(false);
     }*/


}
