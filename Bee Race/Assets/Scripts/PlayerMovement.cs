using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private InputAction move;
    private InputActionAsset inputAsset;
    private InputActionMap player;

    private void Awake()
    {
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


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
