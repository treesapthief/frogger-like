using System;
using UnityEngine;

public class TurtleUnderwaterBehavior : MonoBehaviour
{

    /// <summary>
    /// When the turtle reaches a point that the player can't stay on, remove collision
    /// </summary>
    /// <param name="value"></param>
    public void ToggleCollision(int value)
    {
        Debug.Log($"ToggleCollision (value: {value})");
        bool isUnderwater = Convert.ToBoolean(value);
        var obj = transform.parent.gameObject;
        var collider = obj.GetComponent<BoxCollider2D>();
        collider.enabled = !isUnderwater;
    }
}
