using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShip : MonoBehaviour
{
    //Variable para velocidad general de la nave.
    float speed = 10f;
    //Variable para velocidad de rotación de la nave con el joystick.
    float rotSpeed = 100f;
    //Variable para velocidad de rotación de la nave con el ratón.
    float rotSpeedMouse = 8f;
    //Variable para preguntar si la nave intenta moverse hacia delante o hacia atrás.
    bool forward = true;
    //Variables para conseguir los textos.
    [SerializeField] Text alert;
    [SerializeField] Text enemies;
    [SerializeField] Text timeSpent;
    //Variable para saber si la nave está dentro del tablero.
    bool offLimits = false;
    //Variable para tener el número de enemigos en escena.
    int enemyNumber;
    //Variable para acceder al mesh render de la nave.
    [SerializeField] MeshRenderer myMeshRender;
    //Variable para saber si la nave está viva.
    bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        //Accedemos a los textos.
        Text alert = GetComponent<Text>();
        Text enemies = GetComponent<Text>();
        Text timeSpent = GetComponent<Text>();
        //Empezamos la corrutina del tiempo transcurrido.
        StartCoroutine("secondsSpent");
    }

    // Update is called once per frame
    void Update()
    {
        //Método para mover la nave.
        if(alive == true)
        {
            moveSpaceship();
        }
        //Especificamos el texto de alert.
        alert.text = "ALERT";
        //Le decimos que se active el texto si la booleana lo indica.
        alert.gameObject.SetActive(offLimits);
        //Conseguimos el número de enemigos y lo incluimos en el texto de enemies.
        enemyNumber = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemies.text = "Nº de enemigos: " + enemyNumber;
    }

    public void moveSpaceship()
    {
        //Variables para la posición de la nave en X Y y Z, detectar el movimiento de los axis y especificar los grados de rotación de la nave.
        float myPosX = transform.position.x;
        float desplX = Input.GetAxis("Horizontal");
        float myPosZ = transform.position.z;
        float desplY = Input.GetAxis("Vertical");
        float myPosY = transform.position.y;
        float rotY = Input.GetAxis("Rotate");
        float rotYMouse = Input.GetAxis("Rotate Mouse");
        float rotDegrees = rotY * Time.deltaTime * rotSpeed;
        float rotDegreesMouse = rotYMouse * Time.deltaTime * rotSpeedMouse;
        //Condición para que la nave se mueva hacia delante y atrás.
        if (forward == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * desplY);
        }
        //Condición para impedir el movimiento hacia atrás y dejar el movimiento hacia delante únicamente.
        if (desplY <= 0)
        {
            forward = false;
        }
        else if (desplY > 0)
        {
            forward = true;
        }
        //Movimiento de la nave en horizontal.
        transform.Translate(Vector3.right * Time.deltaTime * speed * desplX);
        //Rotación de la nave.
        transform.Rotate(0f, rotDegrees, 0f);
        transform.Rotate(0f, rotDegreesMouse, 0f);
        //Condición para saber si la nave está dentro del tablero o no.
        if (myPosX > 22 || myPosX < -22 || myPosZ > 22 || myPosZ < -22 || myPosY > 22)
        {
            offLimits = true;
        }
        else
        {
            offLimits = false;
        }
        if(Input.GetKey(KeyCode.JoystickButton4))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if(Input.GetKey(KeyCode.JoystickButton5))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }
    //Corrutina para añadir uno al contador de tiempo cada segundo.
    IEnumerator secondsSpent()
    {
        //Loop infinito para que el contador de tiempo siga avanzando hasta que se pare la corrutina.
        for (int n = 0; ; n++)
        {
            //Especificamos el texto de timeSpent.
            timeSpent.text = "Tiempo transcurrido: " + n;
            //Hacemos que la corrutina tarde 1 segundo en añadir 1 al contador.
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            print("GAME OVER");
            myMeshRender.enabled = false;
            alive = false;
        }
    }
}
