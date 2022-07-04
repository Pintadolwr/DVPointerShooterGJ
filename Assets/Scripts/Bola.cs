using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bola : MonoBehaviour {

    private Rigidbody rb;

    [SerializeField]
    private float speed;
    private Vector3 snapPosition;
    private Quaternion originalRotationValue;

    private int score = 0;

    [SerializeField]
    public Text scoreText;

    [SerializeField]
    public Text timeText;

    [SerializeField]
    public Text gameOverText;

    [SerializeField]
    public float timeCount = 30;

    [SerializeField]
    public int maxScore;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("golfScore"))
        {
            this.transform.position = snapPosition;
            transform.rotation = originalRotationValue;
            rb.angularVelocity = new Vector3(0, 0, 0);
            rb.velocity = new Vector3(0, 0, 0);
            score++;
        }
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("golfScore") ) {
            this.transform.position = snapPosition;
            transform.rotation = originalRotationValue; 
            rb.angularVelocity= new Vector3(0,0,0);
            rb.velocity= new Vector3(0,0,0);
        }
    }*/
}