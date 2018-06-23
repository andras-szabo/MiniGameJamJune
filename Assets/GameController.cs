using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public DudeMover dude;

	public void Reset()
	{
		dude.Reset();
	}
}
