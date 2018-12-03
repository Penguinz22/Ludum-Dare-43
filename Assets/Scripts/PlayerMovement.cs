using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed;
    public Rigidbody2D rb;
    public Camera cam;

	void Start () {
		
	}
	
	void FixedUpdate ()
    {

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.velocity = new Vector2(movementSpeed * Time.deltaTime, rb.velocity.y);
            transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-movementSpeed * Time.deltaTime, rb.velocity.y);
            transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, movementSpeed * Time.deltaTime);
            transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, -movementSpeed * Time.deltaTime);
            transform.rotation = Quaternion.identity;
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

	}

    public void Update()
    {
        if(transform.position.y <= 10 && transform.position.y >= 0)
            cam.transform.position = new Vector3(cam.transform.position.x, transform.position.y, cam.transform.position.z);
    }

}
