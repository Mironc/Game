using UnityEngine;
using Tools;
[RequireComponent(typeof(Collider),typeof(Rigidbody))]
abstract public class PhysObject : FastCut
{
    private void OnCollisionEnter(Collision other) 
    {
        if(other.transform.CompareTag("Platform"))
        {
            transform.SetParent(other.transform);
        }
    }
    private void OnCollisionExit(Collision other) 
    {
        if(other.transform.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    }
}
