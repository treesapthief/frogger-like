using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBarrier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<MovingObstacle>(out var movingObstacle))
        {
            movingObstacle.ResetPosition();
        }
    }
}
