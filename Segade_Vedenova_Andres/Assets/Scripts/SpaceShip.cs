using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    float speed = 10f;
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
        print(forward);
        print(desplY);
        transform.Translate(Vector3.right * Time.deltaTime * speed * desplX);
        
    }
}
