using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Moveball : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public Camera cam;
    public bool space = false;
    public Transform template;
    public GameObject lava;
    public Text endText, text;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0.0f, -10.0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(0.0f, rb.velocity.y, 0.0f);
            rb.angularVelocity = new Vector3(0.0f, rb.velocity.y, 0.0f);
            space = true;
        }

        if (transform.position.y >= lava.transform.position.y + 1500)
        {
            lava.transform.position = new Vector3(lava.transform.position.x, transform.position.y - 1500, lava.transform.position.z);
            template.transform.position = new Vector3(template.transform.position.x, transform.position.y, template.transform.position.z);
        }
    }

    void FixedUpdate()
    {
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;
        forward.y = 0.0f;
        right.y = 0.0f;
        forward.Normalize();
        right.Normalize();

        

        
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 movement = forward * moveZ + right * moveX;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement.y = -2.0f;
        }
        rb.AddForce(movement * speed);
        
    }

}
