using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour {

	public Transform thingThatShouldFollow;
	
	// Update is called once per frame
	void Update () {
		thingThatShouldFollow.position = transform.position;
	}
}
