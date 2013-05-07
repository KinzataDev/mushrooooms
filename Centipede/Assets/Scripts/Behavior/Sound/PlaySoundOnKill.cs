using UnityEngine;
using System.Collections;

public class PlaySoundOnKill : MonoBehaviour {
	
	public AudioClip clip;
	
	void OnKill()
	{
		Debug.Log("Playing: " + clip.name);
		GameObject.Find("AudioPlayer").audio.PlayOneShot(clip);
	}
}
