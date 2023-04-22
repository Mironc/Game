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
        transform.LookAt(CharacterController.Instance.LookInfo.point,new Vector3(1,1,0));
        RB = Get<Rigidbody>();
    }
    void Update()
    {
        RB.velocity = Vector3.forward * this.Speed;
    }
}
