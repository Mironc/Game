using UnityEngine;
using Tools;
public class SimplePath : FastCut,IPath
{
    [SerializeField]private Transform StartPoint;
    [SerializeField]private Transform EndPoint;
    public Vector3 FindPosition(float position)
    {
        return Vector3.Lerp(StartPoint.position,EndPoint.position,position);
    }
    public void draw(int x = 0)
    {
        Gizmos.DrawLine(StartPoint.position,EndPoint.position);
    }
}