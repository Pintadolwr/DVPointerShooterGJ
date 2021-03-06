using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingWall : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 30.0f;
    private Vector3 snapPosition;
    private Quaternion originalRotationValue;
    // Start is called before the first frame update
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
            Debug.Log(snapPosition);
            this.transform.position= snapPosition;
            transform.rotation = originalRotationValue;
            rb.angularVelocity= new Vector3(0,0,0);
            rb.velocity= new Vector3(0,0,0);

        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(5,0,0);
        rb.AddForce(movement * speed);
    }

  

    void OnCollisionEnter(Collision col)
    {
       if(col.collider.CompareTag("wallCollider"))
        {
            this.speed = speed * -1;
            Vector3 movement = new Vector3(5,0,0);
            rb.AddForce(movement*speed);
        } 
    }

}
