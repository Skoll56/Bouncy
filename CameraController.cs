using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public float distance = 15.0f;
    public float xSpeed = 2.0f;
    public float ySpeed = 8.0f;
    public float yMinLimit = -90f;
    public float yMaxLimit = 90f;
    //public float distanceMin = 10f;
    //public float distanceMax = 20f;
    //public float smoothTime = 2f;
    float rotationYAxis = 0.0f;
    float rotationXAxis = 0.0f;
    float velocityX = 0.0f;
    float velocityY = 0.0f;

    /*public float sensitivityX = 15f;
    public float sensitivityY = 30f; */

    void Start()
    {
        Cursor.visible = false;
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    void Update()
    {

    }
    void LateUpdate()
    {
       
        if (target)
        {
            velocityX = 0;
            velocityY = 0;
           // if (Input.GetMouseButton(0))
            {
                velocityX += xSpeed * Input.GetAxis("Mouse X") * distance * 0.2f;
                velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.2f;
            }
            rotationYAxis += velocityX;
            rotationXAxis -= velocityY;
            rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
            //Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
            Quaternion rotation = toRotation;

            //distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
            RaycastHit hit;
            if (Physics.Linecast(target.position, transform.position, out hit))
            {
                //distance -= hit.distance;
            }
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }

    }


        public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}



///This Code has been adapted from code written by OpenXcell-Studio
/// https://answers.unity.com/questions/1257281/how-to-rotate-camera-orbit-around-a-game-object-on.html