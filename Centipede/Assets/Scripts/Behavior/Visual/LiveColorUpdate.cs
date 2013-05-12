using UnityEngine;
using System.Collections;

public class LiveColorUpdate : MonoBehaviour {

	public float timeToHoldColor = 3f;
	private float timeHeldColor = 0f;
	
	private bool isChangingColor = true;
	
	private Color newColor;
	private Color curColor;
	
	// Use this for initialization
	void Start () {
		curColor = SelectNewColor();
		newColor = SelectNewColor();
		
	}
	
	// Update is called once per frame
	void Update () {
		if( isChangingColor )
		{
			timeHeldColor += Time.deltaTime;
			if(timeHeldColor > timeToHoldColor )
			{
				timeHeldColor = timeToHoldColor;
				isChangingColor = false;
			}
			float normTime = timeHeldColor / timeToHoldColor;
			Color lerped = Color.Lerp(curColor, newColor, normTime);
			
			if( renderer != null )
			{
				renderer.material.color = lerped;
			}
			else if( guiTexture != null)
			{
				guiTexture.color = lerped;
			}
			
		}
		else
		{
			curColor = newColor;
			newColor = SelectNewColor();
			isChangingColor = true;
			timeHeldColor = 0;
		}
	}
	
	Color SelectNewColor()
	{
		float[] rgb = new float[3];
		
		rgb[0] = Random.value;
		rgb[1] = Random.value;
		float difference = 2 - (rgb[0] + rgb[1]);
		rgb[2] = Mathf.Min(difference, Random.value);
		
		for (int i = rgb.Length - 1; i > 0; i--) {
	        var r = Random.Range(0,i);
	        var tmp = rgb[i];
	        rgb[i] = rgb[r];
	        rgb[r] = tmp;
	    }
		
		return new Color(rgb[0],rgb[1],rgb[2],1);
	}
}
