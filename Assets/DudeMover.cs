using UnityEngine;

public class DudeMover : MonoBehaviour
{
	public float DrunkLevel { get; private set; }
	public Transform dudeAnchor;
	public Transform dudePointer;

	private Vector3 _dudePointerInitialPosition;

	private void Awake()
	{
		_dudePointerInitialPosition = dudePointer.position;
	}

	public void Reset()
	{
		DrunkLevel = 0f;
		dudeAnchor.position = Vector3.zero;
		dudeAnchor.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

		dudePointer.SetPositionAndRotation(_dudePointerInitialPosition, Quaternion.identity);
		dudePointer.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		dudePointer.GetComponent<Rigidbody2D>().angularVelocity = 0f;
	}
}
