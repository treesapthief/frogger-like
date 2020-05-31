using UnityEngine;

public enum DiveState
{
    Above = 0,
    Diving = 1,
    Underwater = 2,
    Surfacing = 3
}

public class TurtleDive : MonoBehaviour
{
    public float TimeBetweenDives = 3f;
    public float GracePeriodBetweenDivingFrames = 0.5f;

    private float _timeSinceLastDive = 0;
    private DiveState _diveState = DiveState.Above;

    public void SetDiveState(DiveState diveState)
    {
        _diveState = diveState;
    }

    public bool IsPlayerCollidable()
    {
        return _diveState != DiveState.Underwater;
    }

    /// <summary>
    /// Start the turtles diving under water
    /// </summary>
    /// <param name="isDiving"></param>
    private void ToggleDive(bool isDiving)
    {
        _diveState = isDiving ? DiveState.Diving : DiveState.Surfacing;
        //Debug.Log($"ToggleDive(isDiving: {isDiving}");
        foreach (Transform child in transform)
        {
            var obj = child.gameObject;
            if (obj.name == "Player")
            {
                // Kick player off turtle
                Debug.Log("Kick player off turtle when it dives");
                obj.gameObject.GetComponent<PlayerRideable>()?.RemovePlayerFromRideable();

                // Player should check water collision again
                obj.gameObject.GetComponent<PlayerDrownable>()?.WaterContactTrigger();
                continue;
            }

            var animator = obj.GetComponent<Animator>();
            animator.SetInteger("DiveState", (int)_diveState); // Should be 1 or 3
        }
    }

    private void Update()
    {
        if (_diveState == DiveState.Above || _diveState == DiveState.Underwater)
        {
            _timeSinceLastDive -= Time.deltaTime;

            if (_timeSinceLastDive <= 0)
            {
                var isDiving = _diveState == DiveState.Above;
                ToggleDive(isDiving);

                // Start timer
                _timeSinceLastDive = TimeBetweenDives;
            }
        }
    }
}
