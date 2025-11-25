public interface ITankInput
{
    // Hull
    float MoveAxis { get; }   // -1..1 (back/forward)
    float TurnAxis { get; }   // -1..1 (left/right)

    // Turret
    float TurretYawAxis { get; }    // -1..1 (left/right)
    float CannonPitchAxis { get; }  // -1..1 (down/up)

    // Actions
    bool FirePressed { get; }       // true when trigger pressed this frame
}
