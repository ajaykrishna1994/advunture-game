using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public PlayerController playerControllerScript;
    public GameObject bulletPrefab;
    Rigidbody2D bullets;
    
    // Start is called before the first frame update
    void Start()
    {
      //  bullets.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      //  bullets.AddForce(new Vector2(2, 0));
    }

    public void Shooting()
    {
       /*Debug.Log("shooting working");
        Instantiate(bulletPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);*/
    }
}
