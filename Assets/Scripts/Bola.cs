using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public AudioClip hitSound;
    private AudioSource audiosource;

    public int totalScore;

    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        snapPosition = this.transform.position;
        originalRotationValue = transform.rotation;
        scoreText.text = "Score: " + score;
        gameOverText.text = "";
        audiosource = GetComponent<AudioSource>();
        totalScore = PlayerPrefs.GetInt("totalScore");
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
        timeCounter();
        scoreCounter();
    }

    void timeCounter()
    {
        if (timeCount > 0)
        {
            timeCount -= 1 * Time.deltaTime;
        }
        else
        {
            gameOverText.text = "GAME OVER!";
            timeCount = 0;
            Time.timeScale = 0f;
            goBack();
        }
        timeText.text = "Time: " + timeCount;
    }

    void scoreCounter()
    {
        if (score == maxScore)
        {
            gameOverText.text = "GAME OVER!";
            timeCount = 0;
            Time.timeScale = 0f;
            timeText.text = "Time: " + timeCount;
            goBack();
        }
    }

    void goBack() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        totalScore += score;
        PlayerPrefs.SetInt("totalScore", totalScore);
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
            scoreText.text = "Score: " + score;
            audiosource.Play();
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