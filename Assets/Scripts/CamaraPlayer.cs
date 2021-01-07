using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPlayer : MonoBehaviour
{

    public GameObject player;
    private Vector3 distancia;

    void Start()
    {
        ///Distancia entre la posisción del jugador y de la cámara
        distancia = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + distancia;
    }
}
