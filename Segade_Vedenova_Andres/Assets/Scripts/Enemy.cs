using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variable para acceder al audio source.
    private AudioSource explSound;
    //Variable para acceder al mesh render de la esfera.
    [SerializeField] MeshRenderer myMeshRender;
    // Start is called before the first frame update
    void Start()
    {
        //Accedemos al audio source
        explSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Colisión para destruir la esfera y hacer sonar una explosión.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            myMeshRender.enabled = false;
            Destroy(this.gameObject, 1.5f);
            explSound.Play(0);
        }
    }
}
