using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSquishable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Collided with player");
        }
        else
        {
            Debug.Log("Collided with anything, except the player.");
        }
    }
}
