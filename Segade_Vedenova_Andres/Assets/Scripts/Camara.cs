using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    //Variable para acceder a la posición de la nave.
    public Transform spaceShip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Hacemos que la posición de la cámara en X no cambie pero siga a la nave en Y y en Z.
        transform.position = new Vector3(transform.position.x, spaceShip.position.y + 5f, spaceShip.position.z);
        //Hacemos que la cámara mire a la nave siempre.
        transform.LookAt(spaceShip);
    }
}
