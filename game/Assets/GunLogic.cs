using System.Collections;
using Tools;
using UnityEngine;

public class GunLogic : FastCut
{
    [SerializeField] public GunConstruct CurrentGunOnHand;
    [SerializeField] private GunConstruct FirstGun;
    [SerializeField] private GunConstruct SecondGun;
    public static GunLogic Instance;
    public Vector2 Recoil;
    private bool Switched;
    private bool Reloading;
    private float DelayAboutShootTimer;
    private float ResetRecoilTimer;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform BulletPlace;
    private void Awake()
    {
        Instance = Instance == null ? Instance = this : Instance;
    }
    private void Update()
    {
        /* switch (this.CurrentGunOnHand.TypeofShoot)
        {
            case Gun.ShootType.Auto:
                if (Input.GetMouseButton(1) && this.DelayAboutShootTimer > CurrentGunOnHand.DelayAboutShoot)
                {
                    this.ShotLogic();
                    break;
                }
                else if(this.DelayAboutShootTimer < CurrentGunOnHand.DelayAboutShoot)
                {
                    this.DelayAboutShootTimer += Time.deltaTime;
                    break;
                }
                else
                this.ResetRecoil();
            break;
            case Gun.ShootType.SemiAuto:

                break;
            case Gun.ShootType.Single:
                if (Input.GetMouseButtonDown(1) && this.DelayAboutShootTimer > CurrentGunOnHand.DelayAboutShoot)
                {
                    this.ShotLogic();
                    break;
                }
                else if(this.DelayAboutShootTimer < CurrentGunOnHand.DelayAboutShoot)
                {
                    this.DelayAboutShootTimer += Time.deltaTime;
                    break;
                }
                this.ResetRecoil();
                break;

            default:
                break;
        } */
        if (Input.GetKeyDown(KeyCode.R) && this.CurrentGunOnHand.CountOfBullets != this.CurrentGunOnHand.MaxCountOfBullet) Reload();
    }
    private void ShotLogic()
    {
        if (!(this.CurrentGunOnHand.CountOfBullets == 0))
        {
            if (!Reloading)
            {
                Instantiate(Bullet, BulletPlace.transform.position, Quaternion.identity);
                this.CurrentGunOnHand.DecreaseCountOfBullet();
                this.DelayAboutShootTimer = 0;
            }
            else
            {
                Reloading = false;
            }
        }
        Reload();
    }
    private void SwitchGun(GunConstruct gun)
    {
        if (gun == null) return;
        CurrentGunOnHand = gun;
        Reloading = false;
    }
    private void Reload()
    {
        if (CurrentGunOnHand == null) return;
        StartCoroutine("CReload");
    }
    IEnumerable CReload()
    {
        Reloading = false;
        this.CurrentGunOnHand.CountOfBullets = this.CurrentGunOnHand.MaxCountOfBullet;
        yield return new WaitForSeconds(CurrentGunOnHand.ReloadTime);
    }
}