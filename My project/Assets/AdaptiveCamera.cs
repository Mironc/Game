using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptiveCamera : MonoBehaviour
{
    private new Camera camera;
    float FovRatio = 26;
    private void Start() 
    {
        camera = Camera.main;
        camera.fieldOfView = (camera.pixelWidth + camera.pixelHeight) / FovRatio;
        Debug.Log((camera.pixelWidth + camera.pixelHeight) / FovRatio);
    }
}
