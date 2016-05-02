using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	public float speed;
	
	Vector3 movement;
	//Animator anim;
	Rigidbody playerRigidbody;
	
	void Awake(){
		playerRigidbody = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
	}
	
	void FixedUpdate () {
		float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        Move(h,v);
        Turning(h,v);
        //Animating(h,v);
	}
	
	void Move(float h, float v){
		movement.Set(h,1.1f,v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
	}
	
	void Turning(float h, float v){
		
		// if 0,0 stay at last angle
		if( !(h == 0f && v == 0f) ){
			float y_value = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * (180 / Mathf.PI);
			Quaternion rotation = Quaternion.Euler(0,y_value,0);
			playerRigidbody.MoveRotation(rotation);
		}
	}
	/*
	void Animating(float h, float v){
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
	*/
	
}
