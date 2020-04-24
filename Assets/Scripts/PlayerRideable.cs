using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRideable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player landed on ride-able object");
            collision.gameObject.transform.parent = gameObject.transform;
            // TODO: attach player as child
            // TODO: player can move left and right on grid of log
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player left ride-able object");
            collision.gameObject.transform.parent = null;
            // TODO: Remove parent from Player gameobject
        }
    }
}
