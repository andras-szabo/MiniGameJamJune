using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeMover : MonoBehaviour
{
	public float moveFactor = 2f;

	private void Update()
	{
		var dir = Input.GetAxis("Horizontal") * moveFactor * Time.deltaTime;
		transform.Translate(new Vector3(dir, 0f, 0f));
	}
}
