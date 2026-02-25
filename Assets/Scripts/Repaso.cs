using UnityEngine;
using UnityEngine.InputSystem;

public class Repaso : MonoBehaviour
{
    public Rigidbody2D body;

    public float movementSpeed = 5f;

    private InputAction _moveAction;
    private Vector2 _moveDirection;

    public float jumpForce = 10;
    private InputAction _jumpAction; //Inputaction es por cada input, saltar caminar...

    private GroundSensor sensor;//Tiene que ser el nombre que tiene el script

    private SpriteRenderer _render;



    
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();

        _moveAction = InputSystem.actions["Move"];

        _jumpAction = InputSystem.actions["Jump"];

        sensor = GetComponentInChildren<GroundSensor>();//el Getcomponet nomal no sirve porque esta dentro del mario, es un children

        _render = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
         _moveDirection = _moveAction.ReadValue<Vector2>(); //Vincular el direction con el action

         if (_jumpAction.WasPressedThisFrame() && sensor.isGrounded)
         {
             body.AddForce(Vector2.up * ((byte)jumpForce), ForceMode2D.Impulse);
         }

         if (_moveDirection.x > 0)
         {
             _render.flipX = false;
         }
         else if (_moveDirection.x < 0)
         {
             _render.flipX = true;
         }

    }

//Crear el fixed para controlar la velocidad
    void FixedUpdate()
    {                                     //esto para el eje x             //esto para el eje y
        body.linearVelocity = new Vector2(_moveDirection.x * movementSpeed, body.linearVelocity.y);
    }
}
