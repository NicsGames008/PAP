using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Fiz a camara qual quem é o player
    public Transform target;

    //possição da camara
    public Vector3 offset;

    //Toma os valores do zoom
    private float currentZoom = 10f;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    //tamanho do player
    private float pitch = 2f;

    //Receber qual o valor para rodar a camare
    public float sensX;
    private float sensY;
    private float yamInput = 0f;
    private float yRotation;
    private float xRotation;

    public Camera cam;
    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        //Faz com que a camara mexa
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, yamInput);
    }

    private void Update()
    {
        //FAz com que o Scroll Wheel do rato de zoom ou tire
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        //calcular a rotação da camera para olhar para cima e baixo
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        //aplicar ao cameraTransform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //roda o personaguem para olhar para os lados
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
