using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variable Publicas
    public float walkspeed, runSpeed, jumpForce;
    public bool canMove;

    // Variables Privadas
    private Vector3 movementVector, verticalForce;
    private float speed, currentSpeed;
    private bool isGrounded;
    private CharacterController characterController;
    
    

// Start is called before the first frame update
    void Start()
    {
       // Inicializacion de variables
        characterController = GetComponent<CharacterController>();
        speed = 0f;
        currentSpeed = 0f;
        verticalForce = Vector3.zero;
        movementVector = Vector3.zero;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Walk();
        }
    }

    //Funcion para Caminar
    void Walk()
    {
        // Conseguir los inputs
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.z = Input.GetAxis("Vertical");
       
        // Normalizar el vector de movimiento
        movementVector = movementVector.normalized; 

        // Nos Movemos en direccion de la camara
        movementVector = transform.TransformDirection(movementVector);   

        // Guardamos la velocidad actual con suavizado
        currentSpeed = Mathf.Lerp(currentSpeed, movementVector.magnitude * speed, 18f * Time.deltaTime);

        //Nos movemos
        characterController.Move(movementVector * currentSpeed * Time.deltaTime);
    }

    // Funcion para Correr
    void Run()
    {
        // Si presionamos el boton para correr





    }



}
