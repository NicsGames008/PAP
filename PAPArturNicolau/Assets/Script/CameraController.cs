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
    public float yamSpeed = 100f;
    private float yamInput = 0f;

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


        yamInput -= Input.GetAxis("Horizontal") * yamSpeed * Time.deltaTime;
    }
}
