using UnityEngine;
using UnityEngine.EventSystems;

public class ThirdpersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;

    private float turnSmoothVelocity;

    public GameObject canvas;

    //////////////////////////////

    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;


    private bool isGrounded;
    private Vector3 playerVelocity;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas.activeSelf)
            return;

        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        isGrounded = controller.isGrounded;

        //Ve quai os input do utilizador
        float hotizotal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(hotizotal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            //Poe os input do utilizador em angulos
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            //Vira o persunaguempara onde a camara esta
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //Faz o persunaguem andar para onde a camara esta virada
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //move do eprsunaguem
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }


        #region Sprint

        //ve se carregou na tecla shift
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Aumenta a velicidade
            speed = 8;
        }

        //ve se largou na tecla shift
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //Diminui a velucidade
            speed = 6;
        }

        #endregion

        #region Saltar
        //Ve se carregou na tecla de saltar
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                //Salta
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            }
        } 
        #endregion

    }

    private void FixedUpdate()
    {
        #region Gravidade
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        controller.Move(playerVelocity * Time.deltaTime);
        #endregion
    }
}
