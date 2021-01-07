using UnityEngine;
using System.Collections;

public class MoveCam : MonoBehaviour {

    Vector2 touchDeltaPosition;
    public float rotar = 100.0f;

    void Update () {

        ///Movimiento de la cámara del escenario con el clic derecho del mouse

        if (Input.GetMouseButton(1))
        {
             float pointer_x = Input.GetAxis("Mouse X");
             float pointer_y = Input.GetAxis("Mouse Y");


             transform.Translate(-pointer_x * 10.5f, -pointer_y * 10.5f, 0);

        }
         if (Input.GetMouseButton(3))
         {

             float rotation = Input.GetAxis("Horizontal") * rotar;

             rotation *= Time.deltaTime;
             transform.Rotate(1, rotation, 1);

         }

        ///Movimiento de la cámara del escenario Touch
        
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            if (touchZero.phase == TouchPhase.Moved)
            {
                touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                gameObject.transform.Rotate(touchDeltaPosition.y * 5.5f, -touchDeltaPosition.x * 5.5f, 0);
            }
        }
    }
}
