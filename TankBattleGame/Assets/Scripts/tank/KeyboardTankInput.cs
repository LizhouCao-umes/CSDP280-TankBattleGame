using UnityEngine;

public class KeyboardTankInput : MonoBehaviour, ITankInput
{
    public float MoveAxis => (Input.GetKey(KeyCode.W) ? 1f : 0f) + (Input.GetKey(KeyCode.S) ? -1f : 0f);
    public float TurnAxis => (Input.GetKey(KeyCode.D) ? 1f : 0f) + (Input.GetKey(KeyCode.A) ? -1f : 0f);
    public float TurretYawAxis => (Input.GetKey(KeyCode.L) ? 1f : 0f) + (Input.GetKey(KeyCode.J) ? -1f : 0f);
    public float CannonPitchAxis => (Input.GetKey(KeyCode.I) ? 1f : 0f) + (Input.GetKey(KeyCode.K) ? -1f : 0f);
    public bool FirePressed => Input.GetKeyDown(KeyCode.Space);
}
