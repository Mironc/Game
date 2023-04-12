using Tools;
using System;
using UnityEngine;

[RequireComponent(typeof(InputHandler), typeof(Rigidbody))]
public class CharacterController : FastCut
{
    [SerializeField]private movementproperty MovementProperty;
    [SerializeField]private rotationproperty RotationProperty;
    private Rigidbody RB;
    private InputHandler InputHandler;
    private Camera Camera;
    private float RotationX;
    private float RotationY = 0f;

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
        this.RB.AddRelativeForce(this.InputHandler.Move * this.MovementProperty.Speed * Time.deltaTime);
        this.RB.velocity = new Vector3
        (
        Mathf.Clamp(this.RB.velocity.x, -this.MovementProperty.MaxSpeed, this.MovementProperty.MaxSpeed),
        Mathf.Clamp(this.RB.velocity.y, -this.MovementProperty.MaxFallSpeed, this.MovementProperty.MaxFallSpeed),
        Mathf.Clamp(this.RB.velocity.z, -this.MovementProperty.MaxSpeed, this.MovementProperty.MaxSpeed)
        );
    }
    private void Rotation()
    {
        this.RotationX += this.InputHandler.Rotation.x * this.RotationProperty.Sensetivity * Time.deltaTime;
        this.RotationY -= this.InputHandler.Rotation.y * this.RotationProperty.Sensetivity * Time.deltaTime;
        this.RotationY = Mathf.Clamp(this.RotationY,-this.RotationProperty.MaxAngleY,this.RotationProperty.MaxAngleY);
        transform.localRotation = Quaternion.AngleAxis(this.RotationX, Vector3.up);
        Camera.transform.localRotation = Quaternion.AngleAxis(this.RotationY, Vector3.right);
    }
    [Serializable]public struct rotationproperty
    {
    public float Sensetivity;
    public int MaxAngleY;
    }
    [Serializable]public struct movementproperty
    {
    public float Speed;
    public float MaxSpeed;
    public float MaxFallSpeed;
    }
}
