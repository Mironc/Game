using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CharacterMovement : PhysObject
{
    [SerializeField]private float FloorSpeed;
    [SerializeField]private float MaxFloorSpeed;
    [SerializeField]private float MaxFallSpeed;
    public static CharacterMovement Instance;
    public bool Walk;
    private Rigidbody Rb; 
    private InputHandler Input;
    private void Awake() 
    {
        this.Rb = GetComponent<Rigidbody>();
        this.Input = GetComponent<InputHandler>();
        Instance = Instance == null ? this : Instance;
    }
    private void Update() 
    {
        Move();
        ClampVelocity();
    }
    private void ClampVelocity()
    {
        this.Rb.velocity = new Vector3(
            Mathf.Clamp(this.Rb.velocity.x,-this.MaxFloorSpeed,this.MaxFloorSpeed),
            Mathf.Max(this.Rb.velocity.y,-this.MaxFallSpeed),
            Mathf.Clamp(this.Rb.velocity.z,-this.FloorSpeed,this.FloorSpeed));
    }
    private void Move()
    {
        this.Rb.AddRelativeForce(this.Input.Move * this.FloorSpeed * Time.deltaTime);
        this.Walk = this.Input.RawMove != Vector3.zero ? true : false; 
    }

}
