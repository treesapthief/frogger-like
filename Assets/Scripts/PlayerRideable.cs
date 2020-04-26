using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public static class UtilityExtensions
{
    public static T[] GetComponentsOnlyInChildren<T>(this Component script) where T : class
    {
        List<T> group = new List<T>();

        //collect only if its an interface or a Component
        if (typeof(T).IsInterface
            || typeof(T).IsSubclassOf(typeof(Component))
            || typeof(T) == typeof(Component))
        {
            foreach (Transform child in script.transform)
            {
                group.AddRange(child.GetComponentsInChildren<T>());
            }
        }

        return group.ToArray();
    }
}

public class PlayerRideable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D platform)
    {
        if (platform.gameObject.tag == "Rideable" && gameObject.transform.parent == null)
        {
            Debug.Log("Player landed on ride-able object");
            var playerRigidBody = GetComponent<Rigidbody2D>();
            var parentRigidBody = platform.gameObject.GetComponent<Rigidbody2D>();
            var playerPosition = gameObject.transform.position;
            var children = platform.GetComponentsOnlyInChildren<Transform>().ToList();
            if (children.Any())
            {
                Debug.Log("Choose a side");
                var newDistance = children.Select(x => x.position).OrderBy(c => Vector3.Distance(c, playerPosition)).FirstOrDefault();
                Debug.Log($"Player: {playerPosition}, New Distance {newDistance}");
                gameObject.transform.position = new Vector3(newDistance.x, playerPosition.y, 0);
            }

            // TODO: Set player to correct "tile" on the turtle
            // Check player's position to the turtle's position (and length)
            // Determine if they are on the left or the right
            playerRigidBody.velocity = parentRigidBody.velocity;
            gameObject.transform.parent = platform.transform;
            // TODO: player can move left and right on grid of log
        }
    }

    void OnTriggerExit2D(Collider2D platform)
    {
        if (platform.gameObject.tag == "Rideable" && gameObject.transform.parent != null)
        {
            Debug.Log("Player left ride-able object");
            gameObject.transform.parent = null;
            var playerRigidBody = GetComponent<Rigidbody2D>();
            playerRigidBody.velocity = Vector3.zero;
            // TODO: Remove parent from Player gameobject
        }
    }
}
