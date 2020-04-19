using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D _rigidbody2D;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = Vector3.right * Speed;
    }
}
