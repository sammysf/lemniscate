using UnityEngine;
using System.Collections;

public class ThirdPersonCharacter : MonoBehaviour {
	
	private bool canJump = false;
	private float JUMP_FORCE = 300.0f;
	
	
	public AnimationClip idleAnimation;
	public AnimationClip walkAnimation;
	public AnimationClip runAnimation;
	public AnimationClip jumpAnimation;
	enum CharacterState
	{
		Idle = 0,
		Walking = 1,
		Trotting = 2,
		Running = 3,
		Jumping = 4,
	}
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey(KeyCode.D))
			transform.Translate(new Vector3(0.1F, 0.0F, 0.0F));
		if(Input.GetKey(KeyCode.A))
			transform.Translate(new Vector3(-0.1F, 0.0F, 0.0F));
		if(Input.GetKeyDown(KeyCode.W) && canJump)
			rigidbody.AddForce(Vector3.up * JUMP_FORCE);
		
		GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
		Vector3 pos = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
		camera.transform.position = pos;
	}
	
	void OnCollisionEnter(Collision collision)
	{
		canJump = true;
		print ("Enter");
	}
	
	void OnCollisionExit(Collision collision)
	{
		canJump = false;
		print ("Exit");
	}
}
