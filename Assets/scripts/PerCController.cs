using UnityEngine;
using System.Collections;

public class PerCController : MonoBehaviour
{
	private PXCUPipeline pp;

	private Vector3 leftHand;
	private Vector3 rightHand;

	void Start()
	{
		this.pp = new PXCUPipeline();
		if (this.pp == null || !this.pp.Init(PXCUPipeline.Mode.GESTURE))
			Debug.Log("PXCUPipeline Initialization ERROR");
	}

	void OnDestroy()
	{
		this.pp.Close();
	}

	void Update()
	{
		if (this.pp == null)
			return;
		PXCMGesture.GeoNode left;
		PXCMGesture.GeoNode right;
		this.pp.QueryGeoNode(PXCMGesture.GeoNode.Label.LABEL_BODY_HAND_LEFT, out left);
		this.pp.QueryGeoNode(PXCMGesture.GeoNode.Label.LABEL_BODY_HAND_RIGHT, out right);
		if (left.positionWorld.x < right.positionWorld.x)
		{
			PXCMGesture.GeoNode temp = left;
			left = right;
			right = temp;
		}
		this.leftHand = new Vector3(-left.positionWorld.x, left.positionWorld.z, -left.positionWorld.y);
		this.rightHand = new Vector3(-right.positionWorld.x, right.positionWorld.z, -right.positionWorld.y);
	}
}
