using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int speed;
    public Transform startPos;
    public Transform endPos;

    private Transform currentPos;

	void Start () {
        if( currentPos == null ){
            currentPos = startPos;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if ( currentPos == startPos){
            transform.position = Vector3.MoveTowards(transform.position, endPos.position, speed * Time.deltaTime);
            //GameObject.FindGameObjectWithTag("EnemyS").transform.position = Vector3.MoveTowards(GameObject.FindGameObjectWithTag("EnemyS").transform.position, endPos.position, (speed - 18) * Time.deltaTime);
        }else if(currentPos == endPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos.position, speed * Time.deltaTime);
            //GameObject.FindGameObjectWithTag("EnemyS").transform.position = Vector3.MoveTowards(GameObject.FindGameObjectWithTag("EnemyS").transform.position, startPos.position, (speed - 18) * Time.deltaTime);
        }



        if(( transform.position.x <= -7.1f && transform.position.x >= -9.4f )){
            currentPos = endPos;
            //print("Start" +transform.position.x);
        }else if ((transform.position.x >= 9.0f && transform.position.x <= 9.7f))
        {
            //print("End"+transform.position.x);
            currentPos = startPos;
        }


	}   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.transform.position =  collision.gameObject.GetComponent<Player>().orig; // getting acccess to the player components 
            print(" You Collided With ENemy ");
        }

       
    }
}
