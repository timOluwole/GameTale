using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallControl : MonoBehaviour {

    SwitchMode mode;

	//For Movement
	public float speed;
	private Rigidbody rb;

	//For Jumping
	public float jumpSpeed = 1000.0f;
	private bool isFalling = false;

	//For Scoring
	private int count;
	public Text countText;

	void Start () {
		rb = GetComponent<Rigidbody>();
		count = 5;
		SetCountText ();

	}

	void Update() { 
       
		//Movement
		float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		rb.AddForce (movement * speed);

        

        //Jumping
    
        //Raccoon Mode
        if (Input.GetKeyDown("space") && isFalling == false)
		{
            FindObjectOfType<AudioManager>().Play("Jump");
            rb.AddForce(Vector3.up * jumpSpeed);

            if (SwitchMode.hi() == 0)
            {
                isFalling = true;
            }


        }



	}



    





	void SetCountText(){
		countText.text = "Gold Needed: " + count.ToString ();
	}

    void SetWinText()
    {
        countText.text = "Find The Statue!";
    }



    void OnCollisionStay(){
		isFalling = false;
	}


	void OnTriggerEnter(Collider other) 
	{
        if (other.gameObject.CompareTag("Statue"))
        {
            if (count == 0)
            {
                countText.text = "YOU WIN!!!";
            }
        }


        if (other.gameObject.CompareTag("Water") && SwitchMode.hi() == 0)
        {
            isFalling = false;
        }


		if (other.gameObject.CompareTag ("Pick Up"))
		{
			count--;
            other.gameObject.SetActive(false);
            if (count == 0)
            {
                SetWinText();
            }
            else
            {
                SetCountText();
            }

			
			
			FindObjectOfType<AudioManager> ().Play ("Collect Coin");
		}
	}

}

