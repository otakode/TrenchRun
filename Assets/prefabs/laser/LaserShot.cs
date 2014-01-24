using UnityEngine;
using System.Collections;

public class LaserShot : MonoBehaviour 
{	
	public float		velocity = 10.0f;
	public float		timer = 10f;
	
	void Start () 
	{

	}
	
	void Update () 
	{
		timer-= Time.deltaTime;
		if (timer < 0)
			Destroy(this.gameObject);
		Vector3 localForward = this.transform.localRotation * Vector3.forward;
		this.transform.localPosition = localForward * velocity * Time.deltaTime + this.transform.localPosition/* + new Vector3(this.transform.position.x, 0, this.transform.position.z)*/;		
	}
}
