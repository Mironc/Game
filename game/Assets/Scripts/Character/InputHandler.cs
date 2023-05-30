using UnityEngine;

public class InputHandler : MonoBehaviour
{
    protected internal Vector3 Move => new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
    protected internal Vector3 NormalizedMove => Move.normalized;
    protected internal Vector3 RawMove => new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
    protected internal Vector3 Rotation => new Vector3(Input.GetAxis("Mouse X"),-Input.GetAxis("Mouse Y"),0);
    protected internal Vector3 NormalizedRotation => Rotation.normalized;
    protected internal bool Space => Input.GetKeyDown(KeyCode.Space);
    protected internal bool Interaction => Input.GetKeyDown(KeyCode.E);
}