using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaSala2 : MonoBehaviour {

   private Rigidbody rb;
    private float speed = 200.0f;
    private Vector3 snapPosition;
    private Quaternion originalRotationValue;

    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        snapPosition = this.transform.position;
        originalRotationValue = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
         if( Input.GetKey(KeyCode.Escape))
        {
            this.transform.position= snapPosition;
            transform.rotation = originalRotationValue;
            rb.angularVelocity= new Vector3(0,0,0);
            rb.velocity= new Vector3(0,0,0);

        }
    }

    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
        rb.AddForce (movement * speed);
    }

    void OnCollisionEnter()
    {
       // Debug.Log ("Início da colisão");
    }
    void OnCollisionStay()
    {
        //Debug.Log ("Em colisão");
    }
    void OnCollisionExit()
    {
        //Debug.Log ("Fim da colisão");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("golfScore") ) {
            this.transform.position = snapPosition;
            transform.rotation = originalRotationValue; 
            rb.angularVelocity= new Vector3(0,0,0);
            rb.velocity= new Vector3(0,0,0);
        }
    }
}