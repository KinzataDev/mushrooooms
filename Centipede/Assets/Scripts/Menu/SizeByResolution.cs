using UnityEngine;
using System.Collections;

public class SizeByResolution : MonoBehaviour {
	
	public float percentWidth = 0.5f;
	
	public float widthHeightRatio = 0.5f;
	
	// Use this for initialization
	void Start () {
		
		float imageWidth = Screen.width * percentWidth;
		float imageHeight = Screen.height * widthHeightRatio;
		
		Rect pix = guiTexture.pixelInset;
		
		pix.width = (int)imageWidth;
		pix.height = (int)imageHeight;
		
		pix.x -= pix.width * 0.5f;
		pix.y -= pix.height * 0.5f;
		
		guiTexture.pixelInset = pix;
		
	}
}
