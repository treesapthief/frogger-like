using UnityEngine;

public class PlayerRideable : MonoBehaviour
{
    [Range(0f, 1f)]
    public float PlayerLandingOffset = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnStateChange += OnStateChange;
    }

    private void OnStateChange(GameState newState)
    {
        // To make sure the player is not attached to anything when they lose a life or the game is over
        if (newState == GameState.GameOver || newState == GameState.PlayerDied)
        {
            gameObject.transform.parent = null;
            var playerRigidBody = GetComponent<Rigidbody2D>();
            playerRigidBody.velocity = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D platform)
    {
        if (GameManager.Instance.GameState != GameState.InGame)
        {
            return;
        }

        if (platform.gameObject.tag == "Rideable" && gameObject.transform.parent == null)
        {
            Debug.Log($"Player landed on {platform.name}");
            var playerRigidBody = GetComponent<Rigidbody2D>();
            var parentRigidBody = platform.gameObject.GetComponent<Rigidbody2D>();

            var playerPosition = gameObject.transform.position;
            var platformPosition = platform.transform.position;

            var spot = Mathf.Round(playerPosition.x - platformPosition.x);
            var length = platform.bounds.size.x;
            if (spot > length)
            {
                Debug.Log($"Frog is no longer on {platform.name}");
                // Any farther, the frog is in the water
                return;
            }

            playerRigidBody.velocity = parentRigidBody.velocity;
            gameObject.transform.position = new Vector3(platformPosition.x + spot, platformPosition.y, 0);
            gameObject.transform.parent = platform.transform;
            Debug.Log($"Set player on {platform.name}");
        }
    }

    void OnTriggerExit2D(Collider2D platform)
    {
        if (GameManager.Instance.GameState != GameState.InGame)
        {
            return;
        }

        if (platform.gameObject.tag == "Rideable" && gameObject.transform.parent != null)
        {
            Debug.Log($"Player left {platform.name}");
            gameObject.transform.parent = null;
            var playerRigidBody = GetComponent<Rigidbody2D>();
            playerRigidBody.velocity = Vector3.zero;

            var playerPosition = gameObject.transform.position;
            var newX = Mathf.Round(playerPosition.x - PlayerLandingOffset) + PlayerLandingOffset;

            gameObject.transform.position = new Vector3(newX, playerPosition.y, 0);
        }
    }
}
