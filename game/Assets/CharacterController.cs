using System;
using UnityEngine;
using Tools.serialize;


[RequireComponent(typeof(InputHandler))]
sealed public class CharacterController : serialize<CharacterController>
{
    [SerializeField] private parametrs Parametrs;
    [SerializeField] public movementproperty MovementProperties;
    [SerializeField] private rotationproperty RotationProperties;
    [SerializeField] private bobproperty BobProperties;
    [SerializeField] public rayproperty RayProperties;
    public static CharacterController Instance;
    private Rigidbody RB;
    private InputHandler InputHandler;
    private Camera Camera;

    [Serializable]
    struct parametrs
    {
        public bool Move,
        Rotation,
        BobHead,
        Ray,
        Debug;
    }
    private void OnEnable() 
    {
        LoadData("characterdat");
    }
    private void OnDisable() 
    {
        SaveData("characterdat",this);
    }
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        this.SetAllProperties();
        DontDestroyOnLoad(this);
        Instance = Instance == null ? Instance = this : Instance;
    }
    private void SetAllProperties()
    {
        this.RB = Get<Rigidbody>();
        this.Camera = Camera.main;
        this.InputHandler = Get<InputHandler>();
        this.RotationProperties.RotationY = 90f;
        this.BobProperties.BobHeadFirstPosition = Camera.transform.localPosition;
    }
    private void Update()
    {
        if(this.Parametrs.Move)
            this.Move();
        if(this.Parametrs.Rotation)
            this.Rotation();
        if(this.Parametrs.BobHead)
            this.BobHead();
        if(this.Parametrs.Ray)
            this.UpdateRaycast();
    }
    #region Rotation
        [Serializable]
        public struct rotationproperty
        {
            public float Sensetivity;
            public int MaxAngleY;
            [NonSerialized] public float RotationX;
            [NonSerialized] public float RotationY;
        }
        private void Rotation()
        {
            this.RotationProperties.RotationX += this.InputHandler.Rotation.x * this.RotationProperties.Sensetivity * Time.deltaTime;
            this.RotationProperties.RotationY -= this.InputHandler.Rotation.y * this.RotationProperties.Sensetivity * Time.deltaTime;
            this.RotationProperties.RotationY = Mathf.Clamp(this.RotationProperties.RotationY, -this.RotationProperties.MaxAngleY, this.RotationProperties.MaxAngleY);
            transform.localRotation = Quaternion.AngleAxis(this.RotationProperties.RotationX, Vector3.up);
            Camera.transform.localRotation = Quaternion.AngleAxis(this.RotationProperties.RotationY, Vector3.right);
        }
    #endregion

    #region Movement
        [Serializable]
        public struct movementproperty
        {
            public float Speed;
            public float PowerSpeed;
            public float MaxSpeed;
            public float MaxFallSpeed;
            public bool Walk;
            public float MaxAngleFloor;
        }
    
        private void Move()
        {
            this.RB.AddRelativeForce(this.InputHandler.Move * Mathf.Pow(this.MovementProperties.Speed, this.MovementProperties.PowerSpeed) * Time.deltaTime);
            this.RB.velocity = new Vector3
            (
            Mathf.Clamp(this.RB.velocity.x, -this.MovementProperties.MaxSpeed, this.MovementProperties.MaxSpeed),
            Mathf.Clamp(this.RB.velocity.y, -this.MovementProperties.MaxFallSpeed, this.MovementProperties.MaxFallSpeed),
            Mathf.Clamp(this.RB.velocity.z, -this.MovementProperties.MaxSpeed, this.MovementProperties.MaxSpeed)
            );
            this.MovementProperties.Walk = (this.InputHandler.RawMove == Vector3.zero) ? false : true;
        }
        private void Slide()
        {

        }
    #endregion

    #region BobHead
        [Serializable]
        public struct bobproperty
        {
            public Vector3 BobHeadAxisAmplitude;
            public float BobHeadSpeed;
            [NonSerialized] public Vector3 BobHeadFirstPosition;
            [NonSerialized] public float BobHeadTimer;
        }
        private void BobHead()
        {
            if (!this.MovementProperties.Walk)
            {
                this.BobProperties.BobHeadTimer = 0;
                this.Camera.transform.localPosition = this.BobProperties.BobHeadFirstPosition;
                return;
            }

            this.BobProperties.BobHeadTimer += Time.deltaTime;
            this.Camera.transform.localPosition = this.Camera.transform.localPosition + new Vector3
            (
                this.BobProperties.BobHeadAxisAmplitude.x * Mathf.Sin(this.BobProperties.BobHeadTimer * this.BobProperties.BobHeadSpeed) * Time.deltaTime,
                this.BobProperties.BobHeadAxisAmplitude.y * Mathf.Sin(this.BobProperties.BobHeadTimer * this.BobProperties.BobHeadSpeed) * Time.deltaTime,
                this.BobProperties.BobHeadAxisAmplitude.z * Mathf.Sin(this.BobProperties.BobHeadTimer * this.BobProperties.BobHeadSpeed) * Time.deltaTime
            );
        }
    #endregion

    #region Ray
        [Serializable]
        public class rayproperty
        {
            public LayerMask LookInfoLayerMask;
            public Ray CameraRay;
            public RaycastHit LookInfo;        
            public float GroundRayDistance; 
            internal LayerMask GroundInfoLayerMask;
            public Ray GroundRay;
            public RaycastHit GroundInfo;
        }
        private void UpdateRaycast()
        {
            this.RayProperties.CameraRay = new Ray(Camera.transform.position,Camera.transform.forward);
            this.RayProperties.GroundRay = new Ray(transform.position,Vector3.down);
            if(Physics.Raycast(this.RayProperties.CameraRay, out this.RayProperties.LookInfo, 1000f, this.RayProperties.LookInfoLayerMask));
            else this.RayProperties.LookInfo.point = this.RayProperties.CameraRay.direction * 10f;
            Physics.Raycast(this.RayProperties.GroundRay, out this.RayProperties.GroundInfo, 1.05f, this.RayProperties.GroundInfoLayerMask);
        }
    #endregion
    #region Debug
    private void OnDrawGizmos()
    {
        if(this.Parametrs.Debug)
        {
            Gizmos.DrawRay(RayProperties.CameraRay.origin,RayProperties.CameraRay.direction *100);
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * this.RayProperties.GroundRayDistance);
        }
    }
    #endregion
}
