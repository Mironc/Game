using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

sealed public class BezierPath : MonoBehaviour,IPath
{
    [SerializeField]private Transform StartPoint;
    [SerializeField]private Transform EndPoint;
    [SerializeField]private Transform Point1;
    [SerializeField]private Transform Point2;
    public Vector3 FindPosition(float Position)
    {
        if(Position > 1) return EndPoint.position;
        Vector3 Ps1 = Vector3.Lerp(this.StartPoint.position,this.Point1.position,Position);
        Vector3 P12 = Vector3.Lerp(this.Point1.position,this.Point2.position,Position);
        Vector3 P2e = Vector3.Lerp(this.Point2.position,this.EndPoint.position,Position);
        Vector3 Ps1P12 = Vector3.Lerp(Ps1,P12,Position);
        Vector3 P12P2e = Vector3.Lerp(P12,P2e,Position);
        return Vector3.Lerp(Ps1P12,P12P2e,Position);
    }
    public void draw(int Segments)
    {
        float SegmentDist = 1 / (float)Segments;
        Vector3 PrevPoint = StartPoint.position; 
        for (int i = 0; i < Segments; i++)
        {

            Gizmos.DrawLine(PrevPoint,FindPosition(SegmentDist * i));
            PrevPoint = FindPosition(SegmentDist * i);
        }
    }
}
