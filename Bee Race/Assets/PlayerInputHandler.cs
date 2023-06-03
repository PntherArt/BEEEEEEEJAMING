using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using static UnityEngine.InputSystem.InputAction;
using TMPro;
using UnityEngine.UI;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;
    private PlayerMovement movement;

    [SerializeField]
    public TextMeshProUGUI textTag;

    private ThirdPersonActionAsset controls;

    private void Awake()
    {
        textTag.GetComponent<TextMeshProUGUI>();

        movement = GetComponent<PlayerMovement>();
        controls = new ThirdPersonActionAsset();


    }

    public  void IniPlayer(PlayerConfiguration pc)
    {
        playerConfig = pc;
        var pi = pc.PlayerIndex;
        textTag.faceColor = pc.PlayerMat.color;
        textTag.SetText("Player " + (pi + 1).ToString());
        playerConfig.Input.onActionTriggered += Input_onActionTriggered;
    }

    private void Input_onActionTriggered(CallbackContext obj)
    {
        if(obj.action.name == controls.Player.Move.name)
        {
            OnMove(obj);
        }
    }

    public void OnMove(CallbackContext context)
    {
        if(movement != null)
        {
            movement.SetInputVector(context.ReadValue<Vector2>());
        }
    }

    public void OnLook(CallbackContext context)
    {
        /*if(movement != null)
        {
            movement.SetInputVector(context.ReadValue<Vector2>());
        }*/
    }

    public void OnPollen(CallbackContext context)
    {
        /*if(movement != null)
        {
            movement.SetInputVector(context.ReadValue<Vector2>());
        }*/
    }

    public void OnBoost(CallbackContext context)
    {
        /*if(movement != null)
        {
            movement.SetInputVector(context.ReadValue<Vector2>());
        }*/
    }

}
