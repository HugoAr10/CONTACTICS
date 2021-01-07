using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mana_btn : MonoBehaviour
{

    GameObject canvas_reglas;
    //public GameObject can_Regla;
    [Header("Canvas")]
    public GameObject Panel_Reglas;
    public GameObject Panel_Principal;
    public GameObject Panel_Salir;
    public GameObject Panel_InicioSesion;
    public GameObject Panel_Registro;
    public GameObject Panel_Game;
    
    [Header("Botones - main")]
    public GameObject Btn_jugar;
    public GameObject Btn_reglas;
    public GameObject Btn_tut;
    public GameObject Btn_x;

    [Header("Objeto")]
    public GameObject Obj_mun;


    //Cambia de escena
    public void cma_btn()
    {
        SceneManager.LoadScene("PlayGame");
    }

   

    public void Position2()
    {
        //CameraObject.SetFloat("Animate", 1);
    }

    /*public void NewGame()
     {
         if (newscene != "")
         {
             StartCoroutine(LoadAsynchronously(newscene));
             //SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
         }
     }*/

    //Cambio de Canvas - (Met Jugar, Registro y Interfaces)
    public void Can_Jugar()
    {
        Panel_InicioSesion.gameObject.SetActive(false);
        Panel_Game.gameObject.SetActive(true);  
    }

    public void Can_Registro()
    {
        Panel_InicioSesion.gameObject.SetActive(false);
        Panel_Registro.gameObject.SetActive(true);

    }
    
    public void Canv_interfaces()
    {
         Panel_Principal.gameObject.SetActive(false);
         Panel_Reglas.gameObject.SetActive(true);
    }

    //Btn Regresa al panel principal - Canvas del simulador
    public void Btn_regresar()
    {
         Panel_Reglas.gameObject.SetActive(false);
         Panel_Principal.gameObject.SetActive(true);

    }
    
    //Btn Regresa al panel de inicio de sesión
    public void Btn_regresarIS()
    {
        Panel_InicioSesion.gameObject.SetActive(true);
        Panel_Registro.gameObject.SetActive(false);

    }

    //Muestra el panel pop-up Salir (canvas), oculta los objetos asignados
    public void Btn_Salir()
    {
        //Panel_Principal.gameObject.GetComponent<Color>();
        Panel_Salir.gameObject.SetActive(true);
        Btn_jugar.gameObject.SetActive(false);
        Btn_reglas.gameObject.SetActive(false);
        Btn_tut.gameObject.SetActive(false);
        Btn_x.gameObject.SetActive(false);
        //Obj_mun.gameObject.SetActive(false);
    }

    //Canvas panel salir, muestra los objetos asignados
    public void Btn_No()
    {
        Panel_Salir.gameObject.SetActive(false);
        Btn_jugar.gameObject.SetActive(true);
        Btn_reglas.gameObject.SetActive(true);
        Btn_tut.gameObject.SetActive(true);
        Btn_x.gameObject.SetActive(true);
        //Obj_mun.gameObject.SetActive(true);
    }
    
    public void Btn_Si()
    {
        Application.Quit();    
    }


    /*IEnumerator LoadAsynchronously(string newscene)
    {

        newscene.CompareTo("Untagged");
        throw new NotImplementedException();
    }*/
}
