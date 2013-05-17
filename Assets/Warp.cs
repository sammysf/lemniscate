using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Warp : MonoBehaviour {
	
	public AudioClip timeTravelSoundEffect;
	public AudioClip unableToWarpSoundEffect;
	
	private bool isOnLowerLevel = false;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdateCamera();
		
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if(CanWarp())
			{
				Vector3 pos = transform.position;
				pos.y = isOnLowerLevel? pos.y+400 : pos.y-400;
				transform.position = pos;
					
				isOnLowerLevel = !isOnLowerLevel;
				
				if(audio.isPlaying)
					audio.Stop();
				audio.PlayOneShot(timeTravelSoundEffect);
			}
			else
			{
				if(audio.isPlaying)
						audio.Stop();
					audio.PlayOneShot(unableToWarpSoundEffect);
			}
		}
	}
	
	void UpdateCamera()
	{
		GameObject bottomCamera = GameObject.Find("BottomCamera");
		GameObject topCamera = GameObject.Find("TopCamera");
		
		float displacement;
		Vector3 pos;
		displacement = isOnLowerLevel? 0 : -400;
		pos = new Vector3(transform.position.x, transform.position.y + displacement, bottomCamera.transform.position.z);
		bottomCamera.transform.position = pos;
		displacement = isOnLowerLevel? 400 : 0;
		pos = new Vector3(transform.position.x, transform.position.y + displacement, bottomCamera.transform.position.z);
		topCamera.transform.position = pos;
		
		bottomCamera.transform.rotation = Quaternion.identity;
		topCamera.transform.rotation = Quaternion.identity;
	}
	
	bool CanWarp()
	{
		Object[] objects = GameObject.FindObjectsOfType(typeof(GameObject));
		Vector3 newPosition = transform.position;
		newPosition.y = isOnLowerLevel? newPosition.y+400 : newPosition.y-400;
		
		foreach(Object obj in objects)
		{
			try{
				if(((GameObject) obj).activeInHierarchy && ((GameObject) obj).collider.bounds.Contains(newPosition))
				{
					//FlashWhenHit();
					return false;
				}
			}catch{}
		}
		
		return true;
	}
	
	void Fade(float start, float end, float length, GameObject currentObject)
	{
		if (currentObject.guiTexture.color.a == start)
		{
			for (float i = 0.0F; i < 1.0F; i += Time.deltaTime*(1/length))
			{
				Color tempColor = currentObject.guiTexture.color;
				tempColor.a = Mathf.Lerp(start, end, i);
				currentObject.guiTexture.color = tempColor;
				tempColor.a = end;
				currentObject.guiTexture.color = tempColor;
			}
		}
	}
	
	void FlashWhenHit()
	{
		Fade(0F, 0.8F, 0.5F, GameObject.Find("Red"));
		System.Threading.Thread.Sleep(100);
		Fade(0.8F, 0F, 0.5F, GameObject.Find("Red"));
    }
}
