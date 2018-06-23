using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public float timeLimit = 15f;

	[Range(1f, 12f)]
	public float drunkIncrement = 1f;

	[Range(0.1f, 2f)]
	public float drinkingDuration;

	public DudeMover dude;
	public DudeAnimator dudeAnimator;

	public static GameController Instance;
    public bool locked = true;

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
		Countdown.Instance.StartTimer(timeLimit);
	}

	private void Start()
	{
		dude.Reset();
		Countdown.Instance.StartTimer(timeLimit);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			DrunkLevel += drunkIncrement;
			dudeAnimator.MakeDudeDrink();
            locked = false;
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Reset();
		}
	}

	public void GameOver(bool win)
	{
		Debug.Log("Game over, did you win? " + win);
        if (!win)
        {
            dude.Fallen();
        }
        locked = true;

	}
}
