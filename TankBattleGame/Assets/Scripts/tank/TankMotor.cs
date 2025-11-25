using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TankMotor : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [Header("Wheels Settings")]
    [SerializeField] private GameObject[] wheels;
    [SerializeField] private float wheelRotateSpeed = 180.0f;

    private void RotateWheels(float speed)
    {
        foreach (GameObject wheel in wheels)
        {
            if (wheel != null)
                wheel.transform.Rotate(Vector3.right * speed * Time.deltaTime, Space.Self);
        }
    }

    public void MoveAndTurn(float moveAxis, float turnAxis, float moveSpeed, float turnSpeed)
    {
        if (!rb) rb = GetComponent<Rigidbody>();

        // Forward/backward
        Vector3 move = transform.forward * (moveAxis * moveSpeed) * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
        RotateWheels(wheelRotateSpeed * moveAxis);

        // Yaw
        Quaternion turn = Quaternion.Euler(0f, turnAxis * turnSpeed * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * turn);
    }
}


