using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public DudeMover dude;

	public static GameController Instance;

	public float DrunkLevel { get; private set; }

	private void Awake()
	{
		Instance = this;
		DrunkLevel = 0f;
	}

	public void Reset()
	{
		DrunkLevel = 0f;
		dude.Reset();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			DrunkLevel += 1f;
		}
	}

	public void GameOver(bool win)
	{
		Debug.Log("Game over, did you win? " + win);
	}
}
