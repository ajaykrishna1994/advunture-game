using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thing : MonoBehaviour
{
    public float min = 2f;
    public float max = 3f;
    private Rigidbody2D rigidBody;

    public GameObject bulletPrefab;

    public ParticleSystem explosionParticle;


    public Animator animatior;
    public int deadCount = 0;

   
    private AudioSource playerAudio;
    public AudioClip enemypainsound;
    public AudioClip explosion;
    public AudioClip clap;

    public GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();

        min = transform.position.y;
        max = transform.position.y + 3;
        StartCoroutine(Bullet());
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.isGameActive==true)
        {
            transform.position = new Vector2(transform.position.x, Mathf.PingPong(Time.time * 2, max - min) + min);

            if (deadCount == 10)
            {

                explosionParticle.Play();
                Debug.Log("before corutine ");
               // animatior.SetBool("ghost_death", true);
                StartCoroutine(death());
              

            }
        }
     

    }

     public IEnumerator Bullet()
    {

        Debug.Log("thing bullet");

            yield return new WaitForSeconds(1);

        if(gameManagerScript.isGameActive)
        {
            Instantiate(bulletPrefab, new Vector2(transform.position.x + -2, transform.position.y), transform.rotation); //copy of element
            StartCoroutine(Bullet());
        }
      
        

           
        
            
    }
    void OnTriggerEnter2D(Collider2D colisions)
    {
        if (colisions.gameObject.CompareTag("player_bullet"))
        {
           
            deadCount = deadCount + 1;
            playerAudio.PlayOneShot(enemypainsound, 1.0f);

            Destroy(colisions.gameObject);
           









        }
    }
    IEnumerator death()
    {
        playerAudio.PlayOneShot(explosion, 1.0f);
        Debug.Log("after coroutine");
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(finalStage());
        Destroy(gameObject);
         
        gameManagerScript.GameWin();

    }
    IEnumerator finalStage()
    {
        Debug.Log("finall");
        playerAudio.PlayOneShot(clap, 1.0f);
        yield return new WaitForSeconds(1);
        // warningthingFinal.SetActive(false);


    }


}
