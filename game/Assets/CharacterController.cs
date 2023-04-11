using UnityEngine;
using Tools;

[RequireComponent(typeof(InputHandler), typeof(Rigidbody))]
public class CharacterController : FastCut
{
    private Rigidbody RB;
    private InputHandler InputHandler;
    [SerializeField] private float Speed;
    [SerializeField] private float MaxSpeed;
    [SerializeField] private float MaxFallSpeed;
    [SerializeField] private float Sensetivity;
    private Camera Camera;
    private float RotationX;
    private float RotationY;
    private void Awake()
    {
        this.RB = Get<Rigidbody>();
        this.Camera = Camera.main;
        this.InputHandler = Get<InputHandler>();
    }
    private void Update()
    {
        Move();
        Rotation();
    }
    private void Move()
    {
        RB.AddRelativeForce(InputHandler.Move * Speed * Time.deltaTime);
        RB.velocity = new Vector3
        (
        Mathf.Clamp(this.RB.velocity.x, -this.MaxSpeed, this.MaxSpeed),
        Mathf.Clamp(this.RB.velocity.x, -this.MaxSpeed, this.MaxSpeed),
        Mathf.Clamp(this.RB.velocity.z, -this.MaxSpeed, this.MaxSpeed)
        );
    }
    private void Rotation()
    {
        this.RotationX += this.InputHandler.Rotation.x * this.Sensetivity * Time.deltaTime;
        this.RotationY -= this.InputHandler.Rotation.y * this.Sensetivity * Time.deltaTime;
        transform.localRotation = Quaternion.AngleAxis(this.RotationX, Vector3.up);
        Camera.transform.localRotation = Quaternion.AngleAxis(this.RotationY, Vector3.right);
    }
}
