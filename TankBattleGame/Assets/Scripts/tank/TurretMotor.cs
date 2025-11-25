using UnityEngine;

public class TurretMotor : MonoBehaviour
{
    [SerializeField] private Transform turretYaw;   // parent yaw object
    [SerializeField] private Transform cannonPitch; // child pitch object

    public void Aim(float yawAxis, float pitchAxis, float yawSpeed, float pitchSpeed, float minPitch, float maxPitch)
    {
        if (turretYaw)
            turretYaw.Rotate(Vector3.up, yawAxis * yawSpeed * Time.deltaTime, Space.Self);

        if (cannonPitch)
        {
            float delta = pitchAxis * pitchSpeed * Time.deltaTime;
            Vector3 e = cannonPitch.localEulerAngles;
            // Convert to signed range
            float currentX = (e.x > 180f) ? e.x - 360f : e.x;
            currentX = Mathf.Clamp(currentX + (-delta), minPitch, maxPitch); // minus for conventional up = positive
            cannonPitch.localEulerAngles = new Vector3(currentX, 0f, 0f);
        }
    }
}
