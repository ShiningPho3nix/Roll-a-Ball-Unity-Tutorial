using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int score;
    public Text scoreText;
    public Text winText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        setScore();
        winText.text = " ";
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    // Destroy everything that enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            score++;
            setScore();
        }
    }

    private void setScore()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 16)
        {
            winText.text = "You Win!";
        }
    }
}
