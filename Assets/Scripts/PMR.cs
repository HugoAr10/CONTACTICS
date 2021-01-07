using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMR : MonoBehaviour
{

    public float timer;
  

    // Update is called once per frame
    void Update()
    {
        timer -= 1 * Time.deltaTime;

    }

    public void DestroyPMR()
    {
        Destroy(this.gameObject);
    }

}
