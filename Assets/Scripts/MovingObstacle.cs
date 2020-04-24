using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float Speed;
    public Transform StartingPosition;

    private Rigidbody2D _rigidBody2D;

    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidBody2D.velocity = Vector3.right * Speed;
    }

    public void ResetPosition()
    {
        transform.position = StartingPosition.position;
    }
}
