using UnityEngine;
using System;
public class Input_ : MonoBehaviour
{
    [SerializeField]private InputMode Inputmode;
    private Joystick joystick;
    public Vector3 LastRotationInput;
    private void Start() 
    {
        this.Inputmode = Application.isMobilePlatform ? InputMode.Touch : InputMode.KeyboardMouse;
        this.joystick = FindObjectOfType<Joystick>();
        LastRotationInput = Vector2.zero;
    }
    enum InputMode
    {
        Touch,
        KeyboardMouse
    }
    public Vector3 GetMove
    {
        get
        {
            Vector3 MoveInput = this.Inputmode == InputMode.Touch ?
            new Vector3(this.joystick.Horizontal,0,this.joystick.Vertical) : 
            new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            return MoveInput;
        }
        private set{GetRotation = value;}
    }
    public Vector3 GetRotation
    {
        get
        {
            Vector3 CameraInput;
            if(this.Inputmode == InputMode.Touch)
            {
            CameraInput =  Input.mousePosition - this.LastRotationInput;
            this.LastRotationInput = Input.mousePosition;
            }
            CameraInput = new Vector3(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"),0);
            return CameraInput;
        }
        private set{GetRotation = value;}
    }
}
