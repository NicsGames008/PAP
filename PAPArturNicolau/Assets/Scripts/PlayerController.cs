using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;

    PlayerMotor motor;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask) )
            {
                motor.MoveToPoint(hit.point);
            }
        }
    }
}
