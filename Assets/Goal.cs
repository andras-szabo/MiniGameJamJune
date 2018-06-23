using UnityEngine;

public class Goal : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameController.Instance.GameOver(win: true);		
	}
}
