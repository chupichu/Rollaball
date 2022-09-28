using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //añadir campo al player controller: 
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
 
    // declaracion 
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public float jumpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    // como se va a mover la pelota 
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // indica los pick up collecionados 
    void SetCountText()
    {
        countText.text =  count.ToString() + "/ 12 " ;

        if (count >= 12)
        {
            winTextObject.SetActive(true);
            countText.text = "";
        }
    }

    // añadir un vector mas que es la del saltar
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 atas = new Vector3(0, 5, 0);
            rb.AddForce(atas * speed);
        }
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    //cada vez que tocamos un pick up , el objeto se desaparece 
    //y se suma 1 al contador de pickup 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }



}
