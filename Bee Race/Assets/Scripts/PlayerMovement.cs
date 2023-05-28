using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 3f;

    private CharacterController characterController;

    private Vector3 moveDirection = Vector3.zero;
    private Vector2 inputVector = Vector2.zero;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction;
    }

    private void FixedUpdate()
    {
        moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= MoveSpeed;

        characterController.Move(moveDirection * Time.fixedDeltaTime);
    }

}
