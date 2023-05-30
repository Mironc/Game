using UnityEngine;
[RequireComponent(typeof(Collider),typeof(Rigidbody))]
abstract public class PhysObject : MonoBehaviour
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
