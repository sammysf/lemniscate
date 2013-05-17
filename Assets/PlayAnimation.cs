using UnityEngine;
using System.Collections;

public class PlayAnimation : MonoBehaviour {
	
	public AnimationClip idleAnimation;
	public AnimationClip walkAnimation;
	public AnimationClip runAnimation;
	public AnimationClip jumpAnimation;
	
	// Use this for initialization
	void Start ()
	{
		animation.clip = runAnimation;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
