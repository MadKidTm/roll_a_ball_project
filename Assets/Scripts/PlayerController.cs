using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpSpeed;
    public Text Score;
    public Text winText;
    public bool isGrounded;

    private Rigidbody rb;
    private int count;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setScore();
        winText.text = "";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            Vector3 jump = new Vector3(0.0f, 2.0f, 0f);
            rb.AddForce(jump * jumpSpeed, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        

    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            setScore();

        }
    }

    public void setScore()
    {
        Score.text = "Score : " + count.ToString();
        if (count == 12)
        {
            winText.text = "Congratulations dude !";
        }
    }

    
}
