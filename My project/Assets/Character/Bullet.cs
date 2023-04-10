using UnityEngine;

public class Bullet : MonoCache
{
    private Rigidbody RB;
    private float damage;
    [SerializeField]private float speed;
    override protected void OnEnable_() 
    {
        transform.localRotation = Quaternion.FromToRotation(transform.position,PlayerController.Instance.LookInfo.point);
        RB = Get<Rigidbody>();
        Debug.Log("Init");
    }
    override public void Tick()
    {
        RB.velocity = Vector3.forward * Time.deltaTime * speed;
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Bullet")) Destroy(this.gameObject);    
    }
}
