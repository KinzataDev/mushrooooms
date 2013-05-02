using UnityEngine;
using System.Collections;

public class CentipedeLink : MonoBehaviour {
	
	public CentipedeLink parent;
	public CentipedeLink child;
	
	public bool isHead;
	
	public void SetChild(CentipedeLink child)
	{
		this.child = child;
	}
	
	public void ClearChild()
	{
		child = null;
	}
	
	public void SetParent(CentipedeLink parent)
	{
		this.parent = parent;
		isHead = false;
	}
	
	public void ClearParent()
	{
		parent = null;
		isHead = true;
	}
	
	void SevereLink()
	{
		parent.ClearChild();
		child.ClearParent();
	}
	
	void OnDestroy()
	{
		SevereLink();
	}
}
