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
        var obj = transform.parent.gameObject;
        var collider = obj.GetComponent<BoxCollider2D>();
        collider.enabled = ((DiveState)value) != DiveState.Underwater;

        var animator = GetComponent<Animator>();
        animator.SetInteger("DiveState", value); // This state should be 0 or 2 only
    }
}
