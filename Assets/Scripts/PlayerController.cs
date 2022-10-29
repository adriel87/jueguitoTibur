using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public int minPoint;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;

    private float movementX;
    private float movementY;

    private int pointsCount;

    //player jump variables
    public float jumpForce;
    public bool canJump;
    public bool isInGround;
    public bool canDobleJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pointsCount = 0;
        setCounText();
        winTextObject.SetActive(false);
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isInGround)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDobleJump)
        {
            doubleJump();
            canDobleJump = false;
        }
    }
    private void FixedUpdate()
    {
        if (gameObject.CompareTag("Player")) {

            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement * speed);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Picker"))
        {
            other.gameObject.SetActive(false);
            pointsCount++;
            setCounText();
        }
        if (other.gameObject.CompareTag("PickerPowerUp"))
        {
            other.gameObject.SetActive(false);
            speed += 0.5f;
        }

        if (other.gameObject.CompareTag("LastPoint"))
        {
            other.gameObject.SetActive(false);
            pointsCount += 50;
            setCounText();

        }

        if (pointsCount >= minPoint)
        {
            winTextObject.SetActive(true);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isInGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canDobleJump = true;
        }

        if (collision.gameObject.CompareTag("Ramp"))
        {
            canDobleJump = false;
            canJump = false;
        }

    }
    void setCounText()
    {
        countText.text = $"Tu puntuaje es de {pointsCount}";
    }
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }


    void Jump()
    {
        isInGround=false;
        addImpulse();
    }
    void doubleJump()
    {
        addImpulse();
        canDobleJump=false;
    }

    void addImpulse()
    {
        rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
    }

}