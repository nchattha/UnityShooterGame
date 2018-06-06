using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int speed ;

	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed); // move game object accordint the transform component - no force	
	}

	
	   void OnCollisionEnter(Collision collision)
	   {
	       print(collision.transform.name);
	       if(collision.transform.tag == "Enemy"){
	           print("Hit");
	           collision.gameObject.SetActive(false);
	       }
	}

}
