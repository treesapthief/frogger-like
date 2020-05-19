using System.Collections;
using UnityEngine;

public class PlayerDrownable : MonoBehaviour
{
    public float GracePeriodWaterCheckTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        //GameManager.Instance.OnStateChange += OnPlayerDied;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.GameState == GameState.InGame
            && transform.parent == null
            && collision.gameObject.tag == "Water")
        {
            StartCoroutine(CheckWaterContact());
        }
    }

    private IEnumerator CheckWaterContact()
    {
        Debug.Log("CheckWaterContact");
        yield return new WaitForSeconds(GracePeriodWaterCheckTime);

        if (GameManager.Instance.GameState == GameState.InGame
            && transform.parent == null)
        {
            Debug.Log("Player hit water");
            GameManager.Instance.SetGameState(GameState.PlayerDied);
            StartCoroutine(SetDeathAnimation());
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

        Debug.Log("PlayerDrownable.SetDeathAnimation");
        GetComponent<PlayerDeathBehavior>().SetPlayerDeath();
        yield return new WaitForSeconds(3);
        GetComponent<PlayerMovement>().ResetPosition();
        GameManager.Instance.SetGameState(GameState.InGame);
        GetComponent<PlayerDeathBehavior>().SetPlayerAlive();
    }
}
