using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManeger : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor; 

    // Start is called before the first frame update
    void Start()
    {
        playerInput = new PlayerInput();

        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Diz ao PlayerMotor para mover usando o valor do movement action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }
    
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
