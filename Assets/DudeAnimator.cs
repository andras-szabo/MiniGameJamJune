using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeAnimator : MonoBehaviour
{
	public Sprite defaultDude;
	public Sprite drinkingDude;

	private SpriteRenderer _spriteRenderer;

	void Start()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void MakeDudeDrink()
	{
		StartCoroutine(DrinkingRoutine());
	}

	private IEnumerator DrinkingRoutine()
	{
		_spriteRenderer.sprite = drinkingDude;
		yield return new WaitForSeconds(GameController.Instance.drinkingDuration);
		_spriteRenderer.sprite = defaultDude;
	}
}
