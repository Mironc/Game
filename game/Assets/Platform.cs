using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

[ExecuteAlways]
sealed public class Platform : FastCut
{
    [SerializeField]private IPath Path;
    [Range(0,1)]
    [SerializeField]float position;
    [SerializeField]private Transform PlatformModel;
    [SerializeField]int drawSegments;
    private void Awake() 
    {
        this.Path = GetChild<IPath>();
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
