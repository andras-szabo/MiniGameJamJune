using UnityEngine;

public class DudeMover : MonoBehaviour
{
	public float DrunkLevel { get; private set; }
	public Transform dudeAnchor;
	public Transform dudePointer;

	private Rigidbody2D pointerRB;
	private Rigidbody2D anchorRB;

	private Vector3 _dudePointerInitialPosition;

	private void Awake()
	{
		pointerRB = dudePointer.GetComponent<Rigidbody2D>();
		anchorRB = dudeAnchor.GetComponent<Rigidbody2D>();
		_dudePointerInitialPosition = dudePointer.position;
		pointerRB.freezeRotation = false;
	}

	public void Fallen()
	{
		pointerRB.freezeRotation = true;
		anchorRB.velocity = Vector3.zero;
	}

	public void Reset()
	{
		pointerRB.freezeRotation = false;
		DrunkLevel = 0f;
		dudeAnchor.position = Vector3.zero;
		anchorRB.velocity = Vector3.zero;
		anchorRB.angularVelocity = 0f;

		dudePointer.SetPositionAndRotation(_dudePointerInitialPosition, Quaternion.identity);
		pointerRB.velocity = Vector3.zero;
		pointerRB.angularVelocity = 0f;
	}
}
