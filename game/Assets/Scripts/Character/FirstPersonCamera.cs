using UnityEngine;

public sealed class FirstPersonCamera : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField]private float Sensetivity;
    [SerializeField]private float MaxAngleY;
    private Vector3 CurrentRotation;
    [Header("BobHead")]
    [SerializeField]private Vector3 AxisAmplitude;
    [SerializeField]private float BobHeadSpeed;
    private Vector3 FirstPosition;
    private float BobHeadTimer;
    [HideInInspector]public Camera Camera;
    private InputHandler Input;
    public static FirstPersonCamera Instance;
    private void Start() 
    {
        this.Input = GetComponent<InputHandler>();
        this.Camera = Camera.main;
        this.FirstPosition = Camera.transform.localPosition;
        Instance = Instance == null ? Instance = this : Instance;
    }
    private void LateUpdate() 
    {
        Rotation();
        BobHead();
    }
    private void Rotation()
    {
        this.CurrentRotation += this.Input.Rotation * this.Sensetivity * Time.deltaTime;
        this.CurrentRotation = new Vector3(
            this.CurrentRotation.x,
            Mathf.Clamp(this.CurrentRotation.y,-this.MaxAngleY,this.MaxAngleY),
            this.CurrentRotation.z);
        this.transform.localRotation = Quaternion.AngleAxis(this.CurrentRotation.x,Vector3.up);
        this.Camera.transform.localRotation = Quaternion.AngleAxis(this.CurrentRotation.y,Vector3.right);

    }
    private void BobHead()
    {
        if (!CharacterMovement.Instance.Walk)
        {
            this.BobHeadTimer = 0;
            this.Camera.transform.localPosition = this.FirstPosition;
            return;
        }

        this.BobHeadTimer += Time.deltaTime;
        this.Camera.transform.localPosition = this.Camera.transform.localPosition + new Vector3
        (
            this.AxisAmplitude.x * Mathf.Sin(this.BobHeadTimer * this.BobHeadSpeed) * Time.deltaTime,
            this.AxisAmplitude.y * Mathf.Sin(this.BobHeadTimer * this.BobHeadSpeed) * Time.deltaTime,
            this.AxisAmplitude.z * Mathf.Sin(this.BobHeadTimer * this.BobHeadSpeed) * Time.deltaTime
        );
    }
}
