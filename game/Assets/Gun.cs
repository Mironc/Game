using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]private GameObject Bullet;
    [SerializeField]private Transform BulletPlace;
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Instantiate(Bullet,BulletPlace.transform.position,Quaternion.identity);
        }
    }
}
