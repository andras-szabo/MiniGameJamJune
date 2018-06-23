using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkCollider : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameController.Instance.GameOver(win: collision.tag != "dude");
	}
}
