using UnityEngine;

public class DudeMover : MonoBehaviour
{
	public float DrunkLevel { get; private set; }
	public Transform dudeAnchor;
	public Transform dudePointer;

	private Rigidbody2D pointerRB;
	private Rigidbody2D anchorRB;

	private Vector3 _dudePointerInitialPosition;
	private Vector3 _dudeAnchorInitialPosition;

	private void Awake()
	{
		pointerRB = dudePointer.GetComponent<Rigidbody2D>();
		anchorRB = dudeAnchor.GetComponent<Rigidbody2D>();
		_dudePointerInitialPosition = dudePointer.position;
		_dudeAnchorInitialPosition = dudeAnchor.position;
		pointerRB.freezeRotation = false;
	}

	public void Fallen()
	{
        pointerRB.isKinematic = true;
		pointerRB.freezeRotation = true;
		anchorRB.isKinematic = true;
	}

	public void Reset()
	{
		pointerRB.freezeRotation = false;
		DrunkLevel = 0f;
		dudeAnchor.position = _dudeAnchorInitialPosition;
		anchorRB.velocity = Vector3.zero;
		anchorRB.angularVelocity = 0f;

		dudePointer.SetPositionAndRotation(_dudePointerInitialPosition, Quaternion.identity);
		pointerRB.velocity = Vector3.zero;
		pointerRB.angularVelocity = 0f;
	}
}
