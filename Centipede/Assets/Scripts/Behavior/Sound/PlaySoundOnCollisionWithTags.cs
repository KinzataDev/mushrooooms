using UnityEngine;
using System.Collections;

public class PlaySoundOnCollisionWithTags : MonoBehaviour {
	
	public AudioClip[] clips;
	
	public string[] tags;
	
	void OnCollisionEnter(Collision hit)
	{		
		foreach( string s in tags )
		{
			if( s == hit.gameObject.tag )
			{
				GameObject.Find("AudioPlayer").audio.PlayOneShot(clips[Random.Range(0,clips.Length)]);
			}
		}
	}
}
