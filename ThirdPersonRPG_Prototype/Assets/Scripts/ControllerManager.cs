using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerManager : MonoBehaviour {
    public static ControllerManager instance;
    public string moveHorizontalAxis;
    public string moveVerticalAxis;
    public string jumpButton;
    public string cameraHorizontalAxis;
    public string cameraVerticalAxis;
    public string lightButton;
    public string lightTrigger;
    public string aimButton;
    public string aimTrigger;
    public string sprintButton;
    public string dashButton;
    public string MenuButton;
    public string BackButton;

    private void Awake() {
        instance = this;

        moveHorizontalAxis = "Horizontal";
        moveVerticalAxis = "Vertical";

        jumpButton = "Jump";

        cameraHorizontalAxis = "CamHorizontal";
        cameraVerticalAxis = "CamVertical";

        lightButton = "Fire";
        lightTrigger = "Right_Trigger";
        aimButton = "Aim";
        aimTrigger = "Left_Trigger";

        sprintButton = "Sprint";
        dashButton = "Dash";

        MenuButton = "Menu";
        BackButton = "Back";
    }

    public Vector3 OnMove() {
        return new Vector3(Input.GetAxis(moveHorizontalAxis), 0, Input.GetAxis(moveVerticalAxis));
    }

    public bool OnJump() {
        return Input.GetButtonDown(jumpButton);
    }

    public bool OnGlide() {
        return Input.GetButtonDown(jumpButton);
    }

    public bool OnReadyGlide() {
        return Input.GetButtonUp(jumpButton);
    }

    public bool OnAim() {
        return (Input.GetButton(aimButton) || Input.GetAxis(aimTrigger) > 0.2f);
    }

    public bool OnSprint() {
        return Input.GetButton(sprintButton);
    }

    public bool OnDash() {
        return Input.GetButtonDown(dashButton);
    }

    public bool OnLight() {
        return (Input.GetButton(lightButton) || Input.GetAxis(lightTrigger) > 0.2f);
    }

    public bool OnMenu() {
        return Input.GetButtonUp(MenuButton);
    }

    public bool OnBack() {
        return Input.GetButtonUp(BackButton);
    }
}
