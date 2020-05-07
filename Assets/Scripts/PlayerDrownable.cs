using System.Collections;
using UnityEngine;

public class PlayerDrownable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnStateChange += OnPlayerDied;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water" && transform.parent == null)
        {
            Debug.Log("Player hit water");
            GameManager.Instance.SetGameState(GameState.PlayerDied);
        }
    }

    private void OnPlayerDied(GameState newState)
    {
        if (newState == GameState.PlayerDied)
        {
            StartCoroutine(SetDeathAnimation());
        }
    }

    private IEnumerator SetDeathAnimation()
    {
        // TODO: Change player to non-collidable
        // TODO: Change sprite to death animation
        
        yield return new WaitForSeconds(3);
        GetComponent<PlayerMovement>().ResetPosition();
        GameManager.Instance.SetGameState(GameState.InGame);
    }
}
