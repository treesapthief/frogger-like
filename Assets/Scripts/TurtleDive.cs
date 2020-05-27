using UnityEngine;

public class TurtleDive : MonoBehaviour
{
    public float TimeBetweenDives = 3f;
    public float GracePeriodBetweenDivingFrames = 0.5f;
    private float _timeSinceLastDive = 0;
    private bool _isUnderwater = false;

    /// <summary>
    /// Start the turtles diving under water
    /// </summary>
    /// <param name="isDiving"></param>
    private void ToggleDive(bool isDiving)
    {
        foreach (Transform child in transform)
        {
            var obj = child.gameObject;
            var animator = obj.GetComponent<Animator>();
            animator.SetBool("isDiving", isDiving);
        }

        // Start timer
        if (isDiving)
        {
            _timeSinceLastDive = TimeBetweenDives;
        }

        _isUnderwater = isDiving;
    }

    private void Update()
    {
        if (_isUnderwater)
        {
            _timeSinceLastDive -= Time.deltaTime;

            if (_timeSinceLastDive <= 0)
            {
                ToggleDive(false);
            }
        }
    }
}
