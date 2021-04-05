using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thingBullet : MonoBehaviour
{
    public float speed = 2f;
    public float leftBont = -9.3F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * -speed);
        if (transform.position.x  < 76.4f && gameObject.CompareTag("thingbullet"))
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }
        
    }
}
