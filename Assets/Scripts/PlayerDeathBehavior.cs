using UnityEngine;

public class PlayerDeathBehavior : MonoBehaviour
{
    public Sprite PlayerNormal;
    public Sprite PlayerDeath;

    public void SetPlayerDeath()
    {
        Debug.Log("SetPlayerDeath");
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = PlayerDeath;
    }

    public void SetPlayerAlive()
    {
        Debug.Log("SetPlayerAlive");
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = PlayerNormal;
    }
}
