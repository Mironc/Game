using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

[ExecuteAlways]
public class Platform : FastCut
{
    [SerializeField]private Edge Path;
    [Range(0,1)]
    [SerializeField]float position;
    [SerializeField]private Transform PlatformModel;
    [SerializeField]int drawSegments;
    private void Awake() 
    {
        this.Path = GetChild<Edge>();
    }
    private void Update()
    {
        this.PlatformModel.transform.position = this.Path.FindPosition(position);
    }
    private void OnDrawGizmos() 
    {
        this.Path.draw(this.position,this.drawSegments);
    }
}
