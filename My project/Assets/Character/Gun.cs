using System;
using UnityEngine;

public class Gun : MonoCache
{
    [SerializeField]private GunData data;
    [SerializeField]private GameObject Bullet;
    public static Action OnShoot;
    override public void Tick()
    {
        this.data.BulletPlace = GetComponentInChildren<Transform>();
        if(Input.GetMouseButton(0) && this.data.typeShoot == GunData.TypeShoot.Automatic && this.data.LastTimeFired > this.data.SpeedShooting)
        {
            Instantiate(this.Bullet,this.data.BulletPlace.transform.position,Quaternion.identity);
            Debug.Log("1");
            this.data.LastTimeFired = 0;
        }
        else
        {
            this.data.LastTimeFired += Time.deltaTime;
        }
    }
    private void Shoot()
    {
        
    }
}
