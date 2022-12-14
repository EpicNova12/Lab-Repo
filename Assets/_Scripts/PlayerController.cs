using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerAction inputAction;
    Vector2 move;
    Vector2 rotate;
    Rigidbody rb;

    private float distanceToGround;
    bool isGrounded = true;
    public float jump = 5f;
    public float walkSpeed = 5f;
    public Camera playerCamera;
    public Transform oldCamera;
    public float cameraSpeed;
    Vector3 cameraRotation;
    //Gets camera position for when player stops aiming
    Vector3 oldCameraPosition;

    private Animator animator;
    private bool isWalking = false;

    public GameObject projectile;
    public Transform projectilePos;

    private void OnEnable() {
        inputAction.Enable();
    }

    private void OnDisable() {
        inputAction.Disable();
    }

    private void Awake() {

        inputAction = new PlayerAction();

        inputAction.Player.Jump.performed += cntxt => Jump();

        inputAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        inputAction.Player.Move.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.Look.performed += cntxt => rotate = cntxt.ReadValue<Vector2>();
        inputAction.Player.Look.canceled += cntxt => rotate = Vector2.zero;

        inputAction.Player.Shoot.performed += cntxt => Shoot();

        inputAction.Player.Aim.performed += cntxt => Aim(true);
        inputAction.Player.Aim.canceled += cntxt => Aim(false);

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
        cameraRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        
    }

    private void Jump()
    {
        if(isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGrounded = false;
        }
    }

    private void Shoot()
    {
        Rigidbody bulletRb = Instantiate(projectile, projectilePos.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        bulletRb.AddForce(transform.up * 1f, ForceMode.Impulse);
        animator.SetTrigger("Shoot");
    }
    //= new Vector3(0.19f, 1.69f, 0.47f) new Vector3(0.0f,-2.36f,9.85f)
    private void Aim(bool aiming)
    {
        if (aiming)
        {
            playerCamera.transform.position =  new Vector3 (projectilePos.transform.position.x-0.828f, projectilePos.transform.position.y+0.787f, projectilePos.transform.position.z-1.853f);
        }
        else
        {
            playerCamera.transform.position = new Vector3(oldCamera.transform.position.x, oldCamera.transform.position.y, oldCamera.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        cameraRotation = new Vector3(cameraRotation.x + rotate.y*cameraSpeed, cameraRotation.y + rotate.x * cameraSpeed, cameraRotation.z * cameraSpeed);
        
        playerCamera.transform.rotation = Quaternion.Euler(cameraRotation);
        oldCamera.transform.rotation = Quaternion.Euler(cameraRotation);

        transform.eulerAngles = new Vector3(transform.rotation.x, cameraRotation.y, transform.rotation.z);

        transform.Translate(Vector3.right * Time.deltaTime * move.x * walkSpeed, Space.Self);
        transform.Translate(Vector3.forward * Time.deltaTime * move.y * walkSpeed, Space.Self);

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distanceToGround);

        Vector3 m = new Vector3(move.x, 0, move.y);
        AnimateRun(m);
    }

    void AnimateRun(Vector3 m)
    {
        isWalking = (m.x > 0.1f || m.x < -0.1f) || (m.z > 0.1f || m.z < -0.1f) ? true : false;
        animator.SetBool("isWalking", isWalking);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Enemy")
        {
            PlayerHealth.instance.TakeDamage(1);
            animator.SetTrigger("Hit");
            Debug.Log("Health: "+PlayerHealth.instance.getHealth());
            if (PlayerHealth.instance.getHealth() <= 0)
            {
                animator.SetBool("isAlive", false);
            }
        }
    }
}
