using UnityEngine;
using System.Collections;

public class PlaySoundOnCollisionWithObjects : MonoBehaviour {
	
	public AudioClip[] clips;
	
	public GameObject[] objects;
	
	void OnCollisionEnter(Collision hit)
	{
		if( objects.Length == 0 )
		{
			GameObject.Find("AudioPlayer").audio.PlayOneShot(clips[Random.Range(0,clips.Length)]);
		}
		
		foreach( GameObject obj in objects )
		{
			if( obj.name == hit.gameObject.name )
			{
				GameObject.Find("AudioPlayer").audio.PlayOneShot(clips[Random.Range(0,clips.Length)]);
			}
		}
	}
}
