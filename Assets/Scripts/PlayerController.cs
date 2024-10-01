using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private int totalCollectiblesCount;

    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private TextMeshProUGUI countText;
    [SerializeField]
    private GameObject winTextObject;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        totalCollectiblesCount = GameObject.FindGameObjectsWithTag("PickUp").Length;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            
            if (count >= totalCollectiblesCount)
            {
                winTextObject.SetActive(true);
            }
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

}
