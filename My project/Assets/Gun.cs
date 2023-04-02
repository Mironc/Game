using System;
using UnityEngine;

public class Gun : MonoBehaviour,IUpdate
{
    [SerializeField]private GameObject Bullet;
    public static Action OnShoot;
    public void Tick()
    {
        
    }
    private void Shoot()
    {
        
    }
}
