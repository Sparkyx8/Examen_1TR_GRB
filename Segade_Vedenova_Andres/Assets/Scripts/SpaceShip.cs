using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    float speed = 10f;
    float rotSpeed = 100f;
    bool forward = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveSpaceship();
    }

    public void moveSpaceship()
    {
        float myPosX = transform.position.x;
        float desplX = Input.GetAxis("Horizontal");
        float myPosZ = transform.position.z;
        float desplY = Input.GetAxis("Vertical");
        float rotY = Input.GetAxis("Rotate");
        float rotYMouse = Input.GetAxis("Rotate Mouse");
        float rotDegrees = rotY * Time.deltaTime * rotSpeed;
        float rotDegreesMouse = rotYMouse * Time.deltaTime * speed;
        if (forward == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * desplY);
        }
        if (desplY <= 0)
        {
            forward = false;
        }
        else if (desplY > 0)
        {
            forward = true;
        }
        transform.Translate(Vector3.right * Time.deltaTime * speed * desplX);
        transform.Rotate(0f, rotDegrees, 0f);
        transform.Rotate(0f, rotDegreesMouse, 0f);
    }
}
