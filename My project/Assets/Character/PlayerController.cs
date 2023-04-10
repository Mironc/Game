using UnityEngine;
using Tools;
using Random = UnityEngine.Random;

public class PlayerController : InstanceCache<PlayerController>
{
    [SerializeField] private float Speed;
    private Rigidbody Rb;
    private bool Walk;
    private Input_ Input_;
    public int Health{get;private set;}
    private void Awake()
    {
        
        this.Input_ = GetComponent<Input_>();
        this.camera = Camera.main;
        this.DefPos = this.camera.transform.localPosition;
    }
    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }
    override public void LateTick()
    {
        Rotation();
        cameraShake();
    }
    #region Camera
    [SerializeField] private float Sensitivity;
    [SerializeField] private LayerMask LayerMaskLook;
    [HideInInspector]public Vector3 RotationCurrent;
    [Header("CameraShake")]
    [SerializeField] private float MaxAngleY;
    [SerializeField] private bool CameraShake;
    [SerializeField] private float CameraShakeSpeed;
    [SerializeField] private Vector2 RandomShake;
    [SerializeField] private Vector3 CameraShakeForce;
    [SerializeField] private float MoveBackSpeed;
    [HideInInspector]public new Camera camera;
    private Vector3 DefPos;
    private Vector3 Vel;
    private float TimerShake; 
    [HideInInspector]public RaycastHit LookInfo;
    private void Rotation()
    {
        this.RotationCurrent += this.Input_.GetRotation * Time.deltaTime * this.Sensitivity;
        this.RotationCurrent.y = Mathf.Clamp(this.RotationCurrent.y, -this.MaxAngleY, this.MaxAngleY);
        this.camera.transform.localRotation = Quaternion.Euler(this.RotationCurrent.y, 0, 0);
        this.transform.rotation = Quaternion.Euler(0,this.RotationCurrent.x,0);
    }
    private void cameraShake()
    {
        if(!this.CameraShake) return;

        if (this.Walk)
        {
            this.TimerShake += Time.deltaTime;
            this.camera.transform.localPosition = DefPos + new Vector3
            (
             Mathf.Sin(TimerShake * this.CameraShakeSpeed) * this.CameraShakeForce.x + Random.Range(this.RandomShake.x, this.RandomShake.y) * Time.deltaTime
            ,Mathf.Sin(TimerShake * this.CameraShakeSpeed) * this.CameraShakeForce.y + Random.Range(this.RandomShake.x, this.RandomShake.y) * Time.deltaTime
            ,Mathf.Sin(TimerShake * this.CameraShakeSpeed) * this.CameraShakeForce.z + Random.Range(this.RandomShake.x, this.RandomShake.y) * Time.deltaTime
            );
        }
        else
        {
            this.TimerShake = 0;
            this.camera.transform.localPosition = Vector3.SmoothDamp(this.camera.transform.localPosition,this.DefPos,ref Vel,this.MoveBackSpeed);
        }
    }
    #endregion
    private void OnDrawGizmos() {
        if(Application.isPlaying) Gizmos.DrawRay(camera.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0)));
    }
    override public void Tick()
    {
        Rb.AddRelativeForce(Speed * this.Input_.GetMove * Time.deltaTime);
        this.Walk = this.Input_.GetMove != Vector3.zero ? true : false;
        Physics.Raycast(camera.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0)),out this.LookInfo,100000000f,this.LayerMaskLook);
    }
        
    [SerializeField]public void GetDamage(int health,int Damage)
    {
        health -= Damage;
    }
    [SerializeField]public void GetHealth(int health,int Heal)
    {
        health += Heal;
    }
}
