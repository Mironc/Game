using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoCache
{
    private NavMeshAgent NMV;
    private void Awake() 
    {
        this.NMV = GetComponent<NavMeshAgent>();
    }
    private void MoveTo(Vector3 Position) => NMV.destination = Position;
    private void ResetMove(Vector3 Position) => NMV.destination = transform.position;
}
