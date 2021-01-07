using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movimiento_Mouse : MonoBehaviour
{
    public float movementSpeed;
    public float speed = 0.0f, duration = 0.0f;
    public GameObject playerMovePoint;
    private GameObject Obj_personaje;
    private GameObject triggeringPMR;

    private Transform pmr ;
    private bool pmrSpawned;
    private bool moving;
    private Animator anim;
    //private NavMeshAgent navAgent;
    Vector3 mousePosition, target;
    public Vector3 targetPos;
    public LayerMask groundLayer;

    private void Awake()
    {
        //navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //anim.SetFloat("velo", navAgent.velocity.sqrMagnitude);

        if (Input.GetButtonDown("Fire1"))
        {
            MoveTowardsClick();
        }

        //Player movement
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        Obj_personaje = GameObject.Find("Player");

        if (playerPlane.Raycast(ray, out float hitDistance))
        {
            mousePosition = ray.GetPoint(hitDistance);
            if (Input.GetMouseButtonDown(0))
            {
                moving = true;

                if (pmrSpawned)
                {
                    pmr = null;
                    pmr = Instantiate(playerMovePoint.transform, mousePosition, Quaternion.identity);
                }
                else
                {
                    pmr = Instantiate(playerMovePoint.transform, mousePosition, Quaternion.identity);
                }
            }
        }

        if (pmr)
            pmrSpawned = true;
        else
            pmrSpawned = false;

        if (moving)
            Move();
        
            
    }

    private void MoveTowardsClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            if (targetPos != hit.point)
            {
                targetPos = hit.point;
            }

            //navAgent.SetDestination(targetPos);
        }
    }

    public void Move()
    {
   
        if (pmr)
        {
            transform.position = Vector3.MoveTowards(transform.position, pmr.transform.position, movementSpeed);
            this.transform.LookAt(pmr.transform);

            ///Dibuja trayectoria del muñeco al mouse
            /*transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            Debug.DrawLine(transform.position, mousePosition, Color.black, duration = 0.0f);*/

        }
           
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PMR"))
        {
            triggeringPMR = other.gameObject;
            triggeringPMR.GetComponent<PMR>().DestroyPMR();
        }
    }

}
