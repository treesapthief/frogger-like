using UnityEngine;

public enum DiveState
{
    AboveWater,
    DivingUnder,
    Underwater,
    RisingUp
}

public class TurtleDive : MonoBehaviour
{
    public float TimeBetweenDives = 3f;
    public float GracePeriodBetweenDivingFrames = 0.5f;
    private float _timeSinceLastDive = 0;
    private DiveState DiveState = DiveState.AboveWater;
}
