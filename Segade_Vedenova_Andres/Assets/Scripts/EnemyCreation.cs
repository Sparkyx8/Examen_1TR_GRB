using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreation : MonoBehaviour
{
    //Variable para acceder al prefab del enemigo.
    [SerializeField] GameObject Enemy;
    //Variable para acceder a la posición del instanciador.
    [SerializeField] Transform initPos;
    //Variables para crear números aleatorios
    float randomNumberX;
    float randomNumberY;
    float randomNumberZ;
    //Variable para crear una posición aleatoria a partir de los números aleatorios.
    Vector3 randomPos;
    //Variable para saber el número de enemigos.
    float numberEnemies;
    //Variable para poner un intervalo de tiempo entre la creación de unos enemigos y otros.
    float interval;
    // Start is called before the first frame update
    void Start()
    {
        //Loop que crea 20 enemigos antes de empezar el juego.
        for (int a = 1; a <= 20; a++)
        {
            CreateEnemy();
        }
        //Empezamos la corrutina que creará más enemigos.
        StartCoroutine("MoreEnemies");
    }

    // Update is called once per frame
    void Update()
    {
        //Conseguimos el número de enemigos.
        numberEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //Condiciones para el intervalo según el número de enemigos.(Versión del profe)
        if (numberEnemies <= 4)
        {
            interval = 4;
        }
        else if (numberEnemies > 4 && numberEnemies < 10)
        {
            interval = 2;
        }
        if (numberEnemies >= 10)
        {
            interval = 1;
        }
        //Condiciones para el intervalo según el número de enemigos.(Mi versión)
        /*if (numberEnemies <= 4)
        {
            interval = 1;
        }
        else if (numberEnemies > 4 && numberEnemies < 10)
        {
            interval = 2;
        }
        if (numberEnemies >= 10)
        {
            interval = 4;
        }*/
    }
    //Método para crear los enemigos.
    void CreateEnemy()
    {
        //Creamos los números aleatorios y se los asignamos a la posición.
        randomNumberX = Random.Range(-19.5f, 19.5f);
        randomNumberY = Random.Range(3f, 20f);
        randomNumberZ = Random.Range(-19.5f, 19.5f);
        randomPos = new Vector3(randomNumberX, randomNumberY, randomNumberZ);
        //Posición final que depende de la posición del instanciador más la aleatoria.
        Vector3 finalPos = initPos.position + randomPos;
        //Instanciamos el prefab.
        Instantiate(Enemy, finalPos, Quaternion.identity);
    }
    //Corrutina para crear los enemigos cada cierto tiempo.
    IEnumerator MoreEnemies()
    {
        //Loop infinito.
        for (int b = 0; ; b++)
        {
            CreateEnemy();
            //Le asignamos un tiempo según el número de enemigos con la variable interval.
            yield return new WaitForSeconds(interval);
        }
    }
}
