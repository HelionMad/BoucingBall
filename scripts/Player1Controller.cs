using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player1Controller : MonoBehaviour
{

    public float speed;
    public Text CountText;

    private bool isFalling;
    private bool notWall;
    private Rigidbody rb;
    public int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        CountText.text = "P1 Score:" + count.ToString();
    }

    void FixedUpdate()
    {
        if (!isFalling)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed);
        }
    }

    void Update()
    {
        Vector3 jump = new Vector3(0, 25.0f, 0);

        if (Input.GetKeyDown(KeyCode.Return) && isFalling == false)
        {
            rb.AddForce(jump * speed);
            isFalling = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("P2"))
        {
            if (GameObject.FindGameObjectWithTag("P2").transform.position.y > GameObject.FindGameObjectWithTag("P1").transform.position.y)
            {
                count = count - 1;
                SetCountText();
            }
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == ("Ground"))
            isFalling = false;
        else if (other.gameObject.tag == ("Wall"))
        {
            if (notWall)
            {
                count = count - 1;
                SetCountText();
            }
            notWall = false;
        }
    }

    void OnCollisionExit()
    {
        isFalling = true;
        notWall = true;
    }

    void SetCountText()
    {
        if (count < 0)
        {
            count = 0;
        }
        CountText.text = "P1 Score: " + count.ToString();
        /*if (count >= 12)
        {
            winText.text = "You Win!";
        }*/
    }


}