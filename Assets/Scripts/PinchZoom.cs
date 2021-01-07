using UnityEngine;
using UnityEngine.UI;

public class PinchZoom : MonoBehaviour
{
    public float perspectiveZoomSpeed = 0.1f;        // The rate of change of the field of view in perspective mode.
    public float orthoZoomSpeed = 0.1f;        // The rate of change of the orthographic size in orthographic mode.
    Camera maincam;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;
    public static GameObject MoveText;
    Vector3 touchStart;
    /*float xmax = 1475f;
    float ymax = 725f;
    float xmin = 630f;
    float ymin = 280f;*/

    private void Start()
    {
        maincam = this.GetComponent<Camera>();
        MoveText = GameObject.Find("textoPrueba");

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            //float deltaMagnitudeDiff =  touchDeltaMag - prevTouchDeltaMag;
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
            //MoveText.GetComponent<Text>().text = "Tamaño: " +Camera.main.fieldOfView;

            //zoom(deltaMagnitudeDiff * 0.01f);

            /// If the camera is orthographic...
            if (Camera.main.orthographicSize < 100)
            {
                // ... change the orthographic size based on the change in distance between the touches.
                Camera.main.fieldOfView += deltaMagnitudeDiff * orthoZoomSpeed;

                // Make sure the orthographic size never drops below zero.
                Camera.main.fieldOfView = Mathf.Max(Camera.main.fieldOfView, 0.1f);
                if (Camera.main.fieldOfView > 850)
                    Camera.main.fieldOfView = 850;
            }
            else
            {
                // Otherwise change the field of view based on the change in distance between the touches.
                Camera.main.orthographicSize += deltaMagnitudeDiff * perspectiveZoomSpeed;

                // Clamp the field of view to make sure it's between 0 and 180.
                Camera.main.orthographicSize = Mathf.Clamp(Camera.main.fieldOfView, 0.1f, 179.9f);
            }
        }
        else if (Input.GetMouseButton(0)) {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
            //if (Camera.main.orthographicSize < 300)
            //{
            //
            /*if (Camera.main.transform.position.x > 1475)
                Camera.main.transform.position = new Vector3(xmax, Camera.main.transform.position.y, Camera.main.transform.position.z);
            /*if (Camera.main.transform.position.x < 630) 
                Camera.main.transform.position = new Vector3(xmin, Camera.main.transform.position.y, Camera.main.transform.position.z);*/
            /*if (Camera.main.transform.position.y > 725)
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, ymax, Camera.main.transform.position.z);
           /* if (Camera.main.transform.position.y < 280) 
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, ymin, Camera.main.transform.position.z);*/
            // }
            /*new Vector3(
        Mathf.Clamp(direction.x, -1.0f, Camera.main.transform.position.x),
        Mathf.Clamp(direction.y, -1.0f, Camera.main.transform.position.x),
        direction.z);*/


            /*Camera mainCamera = Camera.main;
            int leftBorder = -111;
            int rightBorder = 111;
            int topBorder = 111;
            int bottomBorder = -111;

            Vector2 viewSize = new Vector2(mainCamera.orthographicSize * mainCamera.aspect, mainCamera.orthographicSize);
            mainCamera.transform.position = new Vector3(Mathf.Clamp(mainCamera.transform.position.x, leftBorder + viewSize.x, rightBorder - viewSize.x),
                        Mathf.Clamp(mainCamera.transform.position.y, bottomBorder + viewSize.y, topBorder - viewSize.y), -11F);
            Camera mainCamera = Camera.main;
            int leftBorder = -111;
            int rightBorder = 111;
            int topBorder = 111;
            int bottomBorder = -111;

            Vector2 viewSize = new Vector2(mainCamera.orthographicSize * mainCamera.aspect, mainCamera.orthographicSize);
            mainCamera.transform.position = new Vector3(Mathf.Clamp(mainCamera.transform.position.x, leftBorder + viewSize.x, rightBorder - viewSize.x),
                        Mathf.Clamp(mainCamera.transform.position.y, bottomBorder + viewSize.y, topBorder - viewSize.y), -11F);*/


        }
    }

    void zoom(float increment) {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}
