using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogScene : MonoBehaviour
{
    public float velocidad_rotacion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotar skybox de la escena asignado a la camara
        //RenderSettings.skybox.SetFloat("_Rotation", Time.time * velocidad_rotacion);
    }


}
