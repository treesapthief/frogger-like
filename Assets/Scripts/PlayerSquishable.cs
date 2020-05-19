using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSquishable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GameManager.Instance.OnStateChange += OnPlayerDied;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.Instance.GameState == GameState.InGame && other.gameObject.tag == "Squishable")
        {
            Debug.Log("Squished player");
            GameManager.Instance.SetGameState(GameState.PlayerDied);
            StartCoroutine(SetDeathAnimation());
        }
    }
    private IEnumerator SetDeathAnimation()
    {
        Debug.Log("PlayerSquishable.SetDeathAnimation");
        GetComponent<PlayerDeathBehavior>().SetPlayerDeath();
        yield return new WaitForSeconds(3);
        GetComponent<PlayerMovement>().ResetPosition();
        GameManager.Instance.SetGameState(GameState.InGame);
        GetComponent<PlayerDeathBehavior>().SetPlayerAlive();
    }
}
