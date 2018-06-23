using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
	public static Countdown Instance;
	public bool IsRunning { get; private set; }
	public float SecondsLeft { get; private set; }
	public UnityEngine.UI.Text label;

	private void Awake()
	{
		Instance = this;
	}

	public void StartTimer(float startingSecondsLeft)
	{
		IsRunning = true;
		SecondsLeft = startingSecondsLeft;
	}

	private void Update()
	{
		if (IsRunning)
		{
			SecondsLeft -= Time.fixedDeltaTime;
			if (SecondsLeft <= 0f)
			{
				IsRunning = false;
				GameController.Instance.GameOver(win: false);
			}
		}

		UpdateLabel();
	}

	private void UpdateLabel()
	{
		label.text = string.Format("{0:F2}", SecondsLeft);
	}
}
