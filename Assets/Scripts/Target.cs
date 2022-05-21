using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float speed = 30.0f;

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

    private Vector3 snapPosition;
    private Quaternion originalRotationValue;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        snapPosition = this.transform.position;
        originalRotationValue = transform.rotation;
        scoreText.text = "Score: " + score;
        gameOverText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            this.transform.position = snapPosition;
            transform.rotation = originalRotationValue;
            rb.angularVelocity = new Vector3(0, 0, 0);
            rb.velocity = new Vector3(0, 0, 0);
        }
        timeCounter();
        scoreCounter();
    }

    void timeCounter() { 
        if(timeCount > 0)
        {
            timeCount -= 1 * Time.deltaTime;
        }
        else
        {
            gameOverText.text = "GAME OVER!";
            timeCount = 0;
            Time.timeScale = 0f;
        }
        timeText.text = "Time: " + timeCount;
    }

    void scoreCounter() {
        if (score == maxScore)
        {
            gameOverText.text = "GAME OVER!";
            timeCount = 0;
            Time.timeScale = 0f;
            timeText.text = "Time: " + timeCount;
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(5,0,0);
        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("wallCollider")) {
            this.speed = speed * -1;
            Vector3 movement = new Vector3(5, 0, 0);
            rb.AddForce(movement * speed);
        }else if (collision.collider.CompareTag("bullet"))
        {
            score++;
            scoreText.text = "Score: " + score;
        }
    }
}
