using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;
    public float cameraDistance=110f;
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.width / 2) / cameraDistance);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
