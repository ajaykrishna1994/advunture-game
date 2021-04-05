using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public float min = 2f;
    public float max = 3f;
    private Rigidbody2D rigidBody;
    public GameObject bulletPrefab;
    public GameObject hiddenWall;
    public Animator animatior;
    public GameManager gameManagerScript;

    public ParticleSystem explosionParticle;

    public int deadCount=0;

    private AudioSource playerAudio;
    public AudioClip deadSound;
    public AudioClip enemypainsound;
    // Start is called before the first frame update
    void Start()
    {
      
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        rigidBody = GetComponent<Rigidbody2D>();
        min = transform.position.y;
        max = transform.position.y + 3;
       StartCoroutine(Bullet());
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
      
        if(gameManagerScript.isGameActive)
        {
            transform.position = new Vector2(transform.position.x, Mathf.PingPong(Time.time * 2, max - min) + min);
        }
       
        
        if (deadCount==10 )
        {
            playerAudio.PlayOneShot(deadSound, 1.0f);
           // explosionParticle.Play();
            Debug.Log("enemy dead ");
            animatior.SetBool("ghost_death", true);
            StartCoroutine(death());
         
            hiddenWall.SetActive(false);
        }




    }
    IEnumerator Bullet()
    {
        yield return new WaitForSeconds(1);


        if(gameManagerScript.isGameActive)
        {
            Instantiate(bulletPrefab, new Vector2(transform.position.x + -2, transform.position.y), transform.rotation);
            StartCoroutine(Bullet());
        }
       //copy of element
      

      

      
    }
    IEnumerator death()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }


    void OnTriggerEnter2D(Collider2D colisions)
    {
        if (colisions.gameObject.CompareTag("player_bullet"))
        {
            playerAudio.PlayOneShot(enemypainsound, 1.0f);
            deadCount = deadCount + 1;
            Debug.Log("enemy warning");

            Destroy(colisions.gameObject);

            enemydead();
           

             


        }
    }
   void enemydead()
    {
      
    }

        
    }
