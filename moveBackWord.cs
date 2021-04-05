using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackWord : MonoBehaviour
{
    public float speed = 2f;
    public float rightBont = 110.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (transform.position.x > 110f && gameObject.CompareTag("player_bullet"))
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }
    }
}
