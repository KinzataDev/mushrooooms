using UnityEngine;
using System.Collections;

public class CreateObjectOnBulletHit : MonoBehaviour {
	
	public GameObject CreatedObject;
	
	void OnCollisionEnter(Collision hit)
	{
		Debug.Log("hit");
		if( hit.gameObject.name == "Bullet" )
		{
			GameObject newObj = Instantiate(CreatedObject, transform.position, Quaternion.AngleAxis(180, new Vector3(0,0,1))) as GameObject;
			newObj.name = CreatedObject.name;
		}
	}
}
