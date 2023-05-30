using UnityEngine;

public sealed class CharacterInteraction : MonoBehaviour
{
    
    [Header("Interaction")]
    [SerializeField]private float InteractionDistance;
    [SerializeField]private LayerMask InteractionMask;
    public RaycastHit Interaction
    {
        get
        {
            RaycastHit Hit = new RaycastHit();
            Physics.Raycast(FirstPersonCamera.Instance.Camera.transform.position,Vector3.forward,out Hit,this.InteractionDistance,this.InteractionMask);
            return Hit;
        }
    }
    private InputHandler Input;
    private void Start() 
    {
        this.Input = GetComponent<InputHandler>();
    }
    void Update()
    {
        if(Input.Interaction)
        {
            InteractableObject cached =  GetComponent<InteractableObject>();
            if(cached != null)
            {
                cached.OnInteract();
            }
        }
    }
    private void OnDrawGizmos() 
    {
        Gizmos.draw
    }
}
