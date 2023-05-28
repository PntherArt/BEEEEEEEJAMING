using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private InputAction move;
    [SerializeField]
    private InputActionAsset inputAsset;
    [SerializeField]
    private InputActionMap player;

    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float movementForce = 1f;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float maxSpeed = 5f;
    private Vector3 forceDirection = Vector3.zero;

    [SerializeField]
    private Camera playerCamera;
    //private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputAsset = this.GetComponent<PlayerInput>().actions;
        player = inputAsset.FindActionMap("Player");
    }

    private void OnEnable()
    {
        //player.FindAction("Pollen").started += DropPollen;
       // player.FindAction("Boost").started += DoBoost;
        move = player.FindAction("Move");
        player.Enable();
    }

    private void OnDisable()
    {
       // player.FindAction("Pollen").started -= DropPollen;
       // player.FindAction("Boost").started -= DoBoost;
        player.Disable();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + forceDirection * Time.fixedDeltaTime);
    }

}
