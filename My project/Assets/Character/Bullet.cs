using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour,IUpdate
{
    private Rigidbody RB;
    private float damage;
    [SerializeField]private float speed;
    private void OnEnable() 
    {
        transform.localRotation = Quaternion.FromToRotation(transform.position,PlayerController.instance.LookInfo.point);
        RB = GetComponent<Rigidbody>();
        Debug.Log("Init");
    }
    public void Tick()
    {
        RB.velocity = Vector3.forward * Time.deltaTime * speed;
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Bullet")) Destroy(this);    
    }
}
