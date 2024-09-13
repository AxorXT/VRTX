using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Variables publicas
    public float rotationSpeed, minRotation, maxRotation;
    public bool canRotate;

    //Variables privadas
    private float xRotation, yRotation;

   

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    public void Rotation()
    {
        //Si podemos
        if (canRotate)
        {
            //Conseguimos la rotacion del mouse
            xRotation += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            yRotation += Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            //Agregamos el limite de rotacion Y
            yRotation = Mathf.Clamp(yRotation, minRotation, maxRotation);

            //Rotar el objeto y la camara
            transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
            Camera.main.transform.localRotation = Quaternion.Euler(-yRotation, 0f, 0f);
        }
    }
}
