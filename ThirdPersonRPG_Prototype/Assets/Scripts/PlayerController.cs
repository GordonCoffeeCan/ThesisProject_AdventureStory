using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour {
    [SerializeField] private float walkSpeed = 2;
    [SerializeField] private float runSpeed = 6;
    [SerializeField] private float dashSpeed = 15;
    [SerializeField] private float jumpSpeed = 8;
    [SerializeField] private float sprintTime = 1.65f;

    public Transform rotationPivot;
    public CameraDynamicOrbit cameraPivot;

    [HideInInspector] public float popSpeed;
    [HideInInspector] public float currentGlidingGraivity;
    [HideInInspector] public float gravity = 20;

    [HideInInspector] public bool isPopped = false;
    [HideInInspector] public bool toggleJump = false;
    [HideInInspector] public bool isInMiddleAir = false;
    [HideInInspector] public bool isDashing = false;
    [HideInInspector] public bool isAbleToMove = true;
    [HideInInspector] public bool isAbleToDash = false;
    [HideInInspector] public bool hasTorch = false;

    [SerializeField] private Camera playerCamera;

    private float glidingGraivty = 2.8f;
    private float rotationSpeed = 15;
    private float aimRotationSpeed = 40;
    private float currentSpeed = 0;
    private float currentVerticalSpeed = 0;

    private const float MINIMUM_SPEED_TO_GLIDE = -6.5f;

    private CharacterController characterCtr;
    private PlayerAnimation playerAnimation;
    
    private Vector3 moveDirection;
    private Vector3 rotationDirection;
    private float sprintTimeLimit;

    private void Awake() {
        characterCtr = this.GetComponent<CharacterController>();
        playerAnimation = this.GetComponent<PlayerAnimation>();
        moveDirection = Vector3.zero;
        sprintTimeLimit = sprintTime;
        currentGlidingGraivity = glidingGraivty;
        
    }

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        //If in Game menu panel is on, player cannot be controlled;
        if (UIManager.isMenuPanelOn) {
            return;
        }

        SprintLevel();
        DetectGround();
        OnLightFire();

        if (isAbleToMove) {
            MoveCharacter();
        }

        playerAnimation.hasTorch = hasTorch;
    }

    private void MoveCharacter() {

        moveDirection = ControllerManager.instance.OnMove();

        moveDirection = playerCamera.transform.TransformDirection(moveDirection);
        moveDirection.y = 0;
        moveDirection.Normalize();

        moveDirection *= currentSpeed;

        if (characterCtr.isGrounded) {
            OnSprint();
            if (isAbleToDash) {
                OnDash();
            }
            currentVerticalSpeed = 0;
            if (toggleJump) {
                currentVerticalSpeed = jumpSpeed;
            }
        }else {
            if(currentSpeed > runSpeed) {
                currentSpeed = Mathf.Lerp(currentSpeed, walkSpeed, 0.2f);
            }
        }

        currentVerticalSpeed -= gravity * Time.deltaTime;

        moveDirection.y = currentVerticalSpeed;
        characterCtr.Move(moveDirection * Time.deltaTime);
        RotateCharacter(moveDirection);
    }

    private void DetectGround() {
        RaycastHit _hit;
        RaycastHit _hitGround;
        if (Physics.Raycast(this.transform.position, Vector3.down, out _hit, Mathf.Infinity)) {
            if (Vector3.Distance(this.transform.position, _hit.point) > 3) {
                isInMiddleAir = true;
                playerAnimation.isHardLanding = false;
            } else {
                isInMiddleAir = false;
            }
        }

        if(Physics.Raycast(this.transform.position, Vector3.down, out _hitGround, 0.05f)) {
            if(_hitGround.collider.gameObject.layer == LayerMask.NameToLayer("Spring")) {
                playerAnimation.isHardLanding = false;
            } else {
                playerAnimation.isHardLanding = true;
            }
        }

        //Debug.DrawRay(this.transform.position, Vector3.down * 0.5f, Color.cyan);
    }

    private void RotateCharacter(Vector3 _direction) {

        //No Aiming, Player will facing to it's movement direction;
        if (Mathf.Abs(_direction.x) > 0.1f || Mathf.Abs(_direction.z) > 0.1f) {
            rotationDirection = playerCamera.transform.TransformDirection(new Vector3(_direction.x, 0, _direction.z));
            rotationDirection.y = 0;
            rotationDirection.Normalize();
            rotationDirection *= Time.deltaTime;

            rotationDirection *= (Mathf.Abs(_direction.x) > Mathf.Abs(_direction.z)) ? Mathf.Abs(_direction.x) : Mathf.Abs(_direction.z);

            if (ControllerManager.instance.OnAim() == false) {
                rotationPivot.rotation = Quaternion.Slerp(rotationPivot.rotation, Quaternion.Euler(new Vector3(0, (Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg), 0)), rotationSpeed * Time.deltaTime);
            }
        }
    }

    private void OnSprint() {

        SprintStamina(ControllerManager.instance.OnSprint(), ControllerManager.instance.OnMove(), characterCtr.isGrounded);
    }

    private void SprintStamina(bool _isOnSprint, Vector3 _moveDirection, bool _isOnGround) {
        if (_isOnSprint == false || sprintTime < 0) {
            currentSpeed = Mathf.Lerp(currentSpeed, walkSpeed, 0.2f);
        }
        if (_isOnSprint == true && _moveDirection.magnitude >= 0.8f && _isOnGround == true) {
            if (sprintTime >= 0) {
                sprintTime -= Time.deltaTime;
                currentSpeed = Mathf.Lerp(currentSpeed, runSpeed, 0.2f);
            }
        } else {
            if (sprintTime < sprintTimeLimit) {
                sprintTime += Time.deltaTime;
            } else if (sprintTime >= sprintTimeLimit) {
                sprintTime = sprintTimeLimit;
            }
        }
    }

    private void OnDash() {
        if (ControllerManager.instance.OnDash() && moveDirection.magnitude >= 0.8f && sprintTime / sprintTimeLimit > 0.5f) {
            sprintTime = 0;
            currentSpeed = dashSpeed;
            isDashing = true;
        } else {
            isDashing = false;
        }
    }

    private void OnLightFire() {
        if (characterCtr.velocity.magnitude == 0 && hasTorch) {
            if (ControllerManager.instance.OnLight()) {
                playerAnimation.isLighting = true;
                Debug.Log("Lighting Wood!");
            } else {
                playerAnimation.isLighting = false;
            }

            isAbleToMove = !ControllerManager.instance.OnLight();
        }
    }

    private void SprintLevel() {
        //GameManager.instance.staminaLevel = sprintTime / sprintTimeLimit;
    }
}
