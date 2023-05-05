using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

public class Bullet : FastCut
{
    [SerializeField]private float Speed;
    private Rigidbody RB;
    private void OnEnable() 
    {
        RB = Get<Rigidbody>();
        if()
        {

        }
        this.Speed = GunLogic.Instance.CurrentGunOnHand.Shoot.BulletSpeed;
        transform.LookAt(CharacterController.Instance.RayProperties.LookInfo.point,Vector3.left);  
        RB.velocity = ((CharacterController.Instance.RayProperties.LookInfo.point - transform.position) + new Vector3(GunLogic.Instance.Recoil.x,GunLogic.Instance.Recoil.y,0)).normalized  * this.Speed;
    }
}
