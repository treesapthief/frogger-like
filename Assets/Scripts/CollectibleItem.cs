using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }

        Debug.Log("Collectible item triggered");
        if (other.gameObject.TryGetComponent<PlayerMovement>(out var player))
        {
            GameManager.Instance.CollectItem();
            player.ResetPosition();
            Destroy(gameObject);
        }
    }
}
