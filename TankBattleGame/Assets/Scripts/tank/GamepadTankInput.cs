using UnityEngine;


public enum GamepadPlayer
{
    Player1,
    Player2,
    Player3,
    Player4
}

public class GamepadTankInput : MonoBehaviour, ITankInput
{
    [Header("Select which controller controls this tank")]
    [SerializeField] private GamepadPlayer player = GamepadPlayer.Player1;

    private string moveAxisName;
    private string turnAxisName;
    private string turretYawAxisName;
    private string turretPitchAxisName;
    private string fireButtonName;

    public float MoveAxis => Input.GetAxis(moveAxisName);
    public float TurnAxis => Input.GetAxis(turnAxisName);
    public float TurretYawAxis => Input.GetAxis(turretYawAxisName);
    public float CannonPitchAxis => Input.GetAxis(turretPitchAxisName);
    public bool FirePressed => Input.GetButtonDown(fireButtonName);

    private void Awake()
    {
        // Convert enum → prefix string (P1, P2, P3, P4)
        string prefix = player switch
        {
            GamepadPlayer.Player1 => "P1",
            GamepadPlayer.Player2 => "P2",
            GamepadPlayer.Player3 => "P3",
            GamepadPlayer.Player4 => "P4",
            _ => "P1"
        };

        // Build the axis/button names
        moveAxisName = prefix + "_Vertical";
        turnAxisName = prefix + "_Horizontal";
        turretYawAxisName = prefix + "_TurretX";
        turretPitchAxisName = prefix + "_TurretY";
        fireButtonName = prefix + "_Fire";
    }
}
