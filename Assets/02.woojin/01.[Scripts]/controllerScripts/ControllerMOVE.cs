using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerMOVE : MonoBehaviour
{

    float speed = 0.01f;
    [Header("Controller Setup")]
    public SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;
    public SteamVR_Input_Sources leftHand = SteamVR_Input_Sources.LeftHand;
    //트리거  버튼의 클릭 이벤트에 반응할 액션
    public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    public SteamVR_Action_Boolean trackpad = SteamVR_Actions.default_TraackPadTouch;
    public SteamVR_Action_Boolean grabGrip = SteamVR_Actions.default_GrabGrip;
    public SteamVR_Action_Vector2 trackpadPosition = SteamVR_Actions.default_TrackPadPosition;



    private void Update()
    {

        Vector2 rightStick_pos = trackpadPosition.GetAxis(SteamVR_Input_Sources.RightHand);

        if (rightStick_pos.y >= 0.2)
        {
            transform.Translate(Camera.main.transform.forward * speed);
        }
        if (rightStick_pos.y <= -0.2)
        {
            transform.Translate(-Camera.main.transform.forward * speed);
        }
        if (rightStick_pos.x >= 0.2)
        {
            transform.Translate(Camera.main.transform.right * speed);
        }
        if (rightStick_pos.x <= -0.2)
        {
            transform.Translate(-Camera.main.transform.right * speed);
        }
        if (grabGrip.GetState(leftHand))
        {
            transform.Translate(transform.up * speed);
        }
        if (grabGrip.GetState(rightHand))
        {
            transform.Translate(-transform.up * speed);
        }
    }
}
