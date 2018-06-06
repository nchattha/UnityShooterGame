using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int speed;
    public Vector3 orig; 
    private Rigidbody rb;

    public int cointCount;
    public GameObject goal;
    private Quaternion rot = new Quaternion(0,0,0,0);

    public Transform bulletStartPos;// buullet start pos
    public GameObject bullet; //bullet

    public Text ammoText;

   
    public int ammo ;
    private int ammoCount;

	void Start () {
        rb = GetComponent<Rigidbody> ();
        orig = transform.position;
        ammoCount = ammo;
        ammoText.text = "Ammo: "+ ammoCount +" / "+ammo;
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
         
        Vector3 move = new Vector3(h, 0, v);
        rb.AddForce(move * speed);

        if (transform.position.y <= -2){
            transform.position = orig;
        }

        transform.rotation = rot;

        if( Input.GetKeyDown(KeyCode.Space) && ammoCount > 0 ){
            Instantiate(bullet, bulletStartPos.position, Quaternion.identity );
            ammoCount--;

        }



        //reloading the ammo
        if (Input.GetKeyDown(KeyCode.R) && ammoCount <= 0)
        {
            ammoCount = ammo;
        }

        if (ammoCount <= 0)
        {
            ammoText.text = "Out Of Ammo: Press R (Reload)";
        }
        else
        {
            ammoText.text = "Ammo: " + ammoCount + " / " + ammo;
        }

        //if ( Input.GetButtonDown("Jump")){
        //    Instantiate(bullet, bulletStartPos.position, Quaternion.identity);
        //}
	}

	private void OnTriggerEnter(Collider other){
        if( other.transform.tag == "Collectibles"){
            other.gameObject.SetActive(false);
            cointCount--;

            if( cointCount == 0 ){
                goal.gameObject.SetActive(true);

            }
        }else if( other.transform.tag == "Goal"){
            print(" You Win ");
        }
        
	}



	private void OnCollisionEnter(Collision collision)
	{
        if (collision.transform.tag == "Enemy")
        {
            transform.position = orig;
            print(" You Collided With ENemy ");
        }
	}

}
