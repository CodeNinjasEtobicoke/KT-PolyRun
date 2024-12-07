using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    [Header("Default Jumping Power")]
    public float jumpPower = 6f;
    [Header("Boolean isGrounded")]
    public bool isGrounded = false;
    float posX = 0.0f;
    Rigidbody2D rb;
    public Text scoreText;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * (jumpPower * rb.mass * rb.gravityScale * 20.0f));
        }
        if (transform.position.x < posX)
        {
            GameOver();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
        if (collision.collider.tag == "Enemy")
        {
            GameOver();
        }
        if (collision.collider.tag == "Coin")
        {
            FindObjectOfType<GameController>().IncrementScore();
            Destroy(collision.gameObject);
            //score++;
            //scoreText.text = score.ToString();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void GameOver()
    {
        GameObject.Find("GameController").GetComponent<GameController>().GameOver();
    }


}

