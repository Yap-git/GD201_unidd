using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerFinal : MonoBehaviour
{
	public float speed = 0;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;
    public GameObject wall1;
    public GameObject wall3;
    public GameObject bwall;

	private Rigidbody rb;
	private int count;
	private float movementX;
	private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 100;

        SetCountText();
        winTextObject.SetActive(false);

        wall1 = GameObject.FindWithTag("PWall1");
        wall3 = GameObject.FindWithTag("PWall3");
        bwall = GameObject.FindWithTag("BWall");
    }


    void OnMove(InputValue movementValue) 
    { 
       Vector2 movementVector = movementValue.Get<Vector2>();

       movementX = movementVector.x;
       movementY = movementVector.y;

    }


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        
    }

    void FixedUpdate()
    {
    	Vector3 movement = new Vector3(movementX, 0.0f, movementY);

    	rb.AddForce(movement * speed);

        
            if(count == 120){
             Destroy(wall1);
            }

            if(count == 220){
             Destroy(wall3);
            }

            if(count == 300){
                Destroy(bwall);
            }
        
    }

    private void OnTriggerEnter(Collider other)
    {
    	if(other.gameObject.CompareTag("Health"))
    	{
    		other.gameObject.SetActive(false);
    		count = count + 10;

    		SetCountText();
    	}
        if(other.gameObject.CompareTag("MHealth")){

            other.gameObject.SetActive(false);
            speed = speed + 10;
        }
        if(other.gameObject.CompareTag("Finish")){

            other.gameObject.SetActive(false);
            winTextObject.SetActive(true);

        }

       
    }
}
