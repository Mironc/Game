using Tools;
using System;
using UnityEngine;

[RequireComponent(typeof(InputHandler), typeof(Rigidbody))]
public class CharacterController : Instancer<CharacterController>
{
    [SerializeField]private movementproperty MovementProperty;
    [SerializeField]private rotationproperty RotationProperty;
    [SerializeField]private LayerMask LookInfoLayerMask;
    [SerializeField]private bobproperty BobProperty;
    [HideInInspector]public RaycastHit LookInfo{
        get
        {
            RaycastHit CachedRaycast;
            Physics.Raycast(transform.position,Vector3.forward,out CachedRaycast,Mathf.Infinity,this.LookInfoLayerMask);
            return CachedRaycast;
        }
    }
    private Rigidbody RB;
    private InputHandler InputHandler;
    private Camera Camera;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SetAllProperties();
        SetInstance();
        DontDestroyOnLoad(this);
    }
    private void SetAllProperties()
    {
        this.RB = Get<Rigidbody>();
        this.Camera = Camera.main;
        this.InputHandler = Get<InputHandler>();
        this.RotationProperty.RotationY = 90f;
        this.BobProperty.BobHeadFirstPosition = Camera.transform.localPosition;
    }
    private void Update()
    {
        this.Move();
        this.Rotation();
        this.BobHead();
    }
    private void Move()
    {
        this.RB.AddRelativeForce(this.InputHandler.Move * Mathf.Pow(this.MovementProperty.Speed,this.MovementProperty.PowerSpeed) * Time.deltaTime);
        this.RB.velocity = new Vector3
        (
        Mathf.Clamp(this.RB.velocity.x, -this.MovementProperty.MaxSpeed, this.MovementProperty.MaxSpeed),
        Mathf.Clamp(this.RB.velocity.y, -this.MovementProperty.MaxFallSpeed, this.MovementProperty.MaxFallSpeed),
        Mathf.Clamp(this.RB.velocity.z, -this.MovementProperty.MaxSpeed, this.MovementProperty.MaxSpeed)
        );
        this.MovementProperty.Walk = (this.InputHandler.RawMove == Vector3.zero)  ? false : true;
    }
    private void Rotation()
    {
        this.RotationProperty.RotationX += this.InputHandler.Rotation.x * this.RotationProperty.Sensetivity * Time.deltaTime;
        this.RotationProperty.RotationY -= this.InputHandler.Rotation.y * this.RotationProperty.Sensetivity * Time.deltaTime;
        this.RotationProperty.RotationY = Mathf.Clamp(this.RotationProperty.RotationY,-this.RotationProperty.MaxAngleY,this.RotationProperty.MaxAngleY);
        transform.localRotation = Quaternion.AngleAxis(this.RotationProperty.RotationX, Vector3.up);
        Camera.transform.localRotation = Quaternion.AngleAxis(this.RotationProperty.RotationY, Vector3.right);
    }
    private void BobHead()
    {
        if(!this.MovementProperty.Walk)
        {
            this.BobProperty.BobHeadTimer = 0;
            this.Camera.transform.localPosition = this.BobProperty.BobHeadFirstPosition;
            return;
        }

        this.BobProperty.BobHeadTimer += Time.deltaTime;
        this.Camera.transform.localPosition = this.Camera.transform.localPosition + new Vector3
        (
            this.BobProperty.BobHeadAxisAmplitude.x * Mathf.Sin(this.BobProperty.BobHeadTimer * this.BobProperty.BobHeadSpeed) * Time.deltaTime,
            this.BobProperty.BobHeadAxisAmplitude.y * Mathf.Sin(this.BobProperty.BobHeadTimer * this.BobProperty.BobHeadSpeed) * Time.deltaTime,
            this.BobProperty.BobHeadAxisAmplitude.z * Mathf.Sin(this.BobProperty.BobHeadTimer * this.BobProperty.BobHeadSpeed) * Time.deltaTime
        );
    }
    [Serializable]public struct rotationproperty
    {
    public float Sensetivity;
    public int MaxAngleY;
    [NonSerialized]public float RotationX;
    [NonSerialized]public float RotationY;
    }
    [Serializable]public struct movementproperty
    {
    public float Speed;
    public float PowerSpeed;
    public float MaxSpeed;
    public float MaxFallSpeed;
    public bool Walk;
    }
    [Serializable]public struct bobproperty
    {

        public Vector3 BobHeadAxisAmplitude;
        public float BobHeadSpeed;
        [NonSerialized]public Vector3 BobHeadFirstPosition;
        [NonSerialized]public float BobHeadTimer;
    }
    private void OnDrawGizmos() 
    {
    }
}
