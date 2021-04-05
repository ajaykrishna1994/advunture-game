using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider : MonoBehaviour
{

    public float min = 2f;
    public float max = 3f;
    public GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        min = transform.position.x;
        max = transform.position.x + 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerScript.isGameActive)
        {
            transform.position = new Vector2(Mathf.PingPong(Time.time * 1, max - min) + min, transform.position.y);
        }

        
    }
}
