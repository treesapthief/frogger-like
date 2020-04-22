using UnityEngine;

public enum FacingDirection
{
    South = 0,
    East = 1,
    North = 2,
    West = 3
}

public class PlayerMovement : MonoBehaviour
{
    public FacingDirection FacingDirection = FacingDirection.North;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
            FacingDirection = FacingDirection.North;
            transform.localEulerAngles = new Vector3(0, 0, 180);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);
            FacingDirection = FacingDirection.South;
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
            FacingDirection = FacingDirection.West;
            transform.localEulerAngles = new Vector3(0, 0, 270);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, 0);
            FacingDirection = FacingDirection.East;
            transform.localEulerAngles = new Vector3(0, 0, 90);
        }
    }
}
