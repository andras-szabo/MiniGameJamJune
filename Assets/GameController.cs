using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public DudeMover dude;

	public static GameController Instance;

	private void Awake()
	{
		Instance = this;
	}

	public void Reset()
	{
		dude.Reset();
	}

	public void GameOver(bool win)
	{
		Debug.Log("Game over, did you win? " + win);
	}
}
