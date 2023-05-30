using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

[ExecuteAlways]
sealed public class Platform : MonoBehaviour
{
    [SerializeField]private IPath Path;
    [Range(0,1)]
    [SerializeField]private float position;
    [SerializeField]private Transform PlatformModel;
    [SerializeField]private int drawSegments;
    private void Awake() 
    {
        this.Path = GetComponentInChildren<IPath>();
    }
    private void Update()
    {
        this.PlatformModel.transform.position = this.Path.FindPosition(position);
    }
    private void OnDrawGizmos() 
    {
        this.Path.draw(this.drawSegments);
    }
}
interface IPath
{
    void draw(int segments);
    Vector3 FindPosition(float t);
}
