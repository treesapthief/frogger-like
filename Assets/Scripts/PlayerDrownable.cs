using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrownable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water" && transform.parent != null && transform.parent.tag == "")
        {
            Debug.Log("Player hit water");
        }
    }
}
