using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ForceThing : MonoBehaviour
{
	public Rigidbody2D rb;
	public float forceFactor = 2f;
	public bool applyConstantForce;
	public Vector2 myConstantForce;
	public float drunkLevel;
	public float drunkImpulsePeriodSeconds;

	private float _previousForce;


	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		if (applyConstantForce)
		{
			StartCoroutine(DrunkMoveRoutine());
		}
	}

	void Update()
	{
		var force = Input.GetAxis("Horizontal") * forceFactor;
		force = applyConstantForce ? -force : force;

		if (!applyConstantForce || drunkLevel > 0f)
		{
			rb.AddForce(new Vector2(force, 0f));
		}
	}

	private IEnumerator DrunkMoveRoutine()
	{
		while (true)
		{
			rb.AddForce(new Vector2(_previousForce, 0f));

			var moveToRightForce = drunkLevel * myConstantForce.x * 0.75f;
			var randomChange = GetRandomDrunkennessQuotient();
			var finalForce = moveToRightForce + randomChange;
			rb.AddForce(new Vector2(finalForce, 0f));

			_previousForce = -finalForce;

			yield return new WaitForSeconds(drunkImpulsePeriodSeconds);
		}
	}

	private float GetRandomDrunkennessQuotient()
	{
		return Random.Range(-drunkLevel, drunkLevel) * myConstantForce.x * 0.5f;
	}
}
