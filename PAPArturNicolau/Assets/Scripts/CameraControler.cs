using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    public float pitch = 2f;

    public float currentZoom = 10f;

    void LateUpdate()
    {
        trasform.posiiton = target.possition - offset * currentZoom;
        transform.LookAt(target.possition + Vector3.up * pitch);
    }
}
