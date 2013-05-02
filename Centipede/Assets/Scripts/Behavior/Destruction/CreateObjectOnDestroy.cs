using UnityEngine;
using System.Collections;

public class CreateObjectOnDestroy : MonoBehaviour {
	
	public GameObject CreatedObject;
	public bool isEnabled = true;

	void OnDestroy()
	{
		if( !isEnabled )
		{
			return;
		}
		
		GameObject parentObj = GameObject.Find("GameLevelControl");
		if( parentObj && parentObj.GetComponent<GameLevelControl>().currentState == GameLevelControl.State.Running)
		{
			GameObject newObj = Instantiate(CreatedObject, transform.position, Quaternion.AngleAxis(180, new Vector3(0,0,1))) as GameObject;
			newObj.name = CreatedObject.name;
		}
	}
}
