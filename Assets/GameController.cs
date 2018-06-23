using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour 
{
	public float timeLimit = 15f;


    private bool gameOver;

    [SerializeField]
    private GameObject loosingPanel;


    [SerializeField]
    private Image winImage;

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

	public void Reset(bool startResetAgain = true)
	{

        winImage.gameObject.SetActive(false);
        gameOver = false;
		DrunkLevel = 0f;
		dude.Reset();
		if (startResetAgain)
		{
			StartCoroutine(CallResetAgainRoutine());
		}
		Countdown.Instance.StartTimer(timeLimit);
        loosingPanel.SetActive(false);
        

	}

	private IEnumerator CallResetAgainRoutine()
	{
		yield return new WaitForSeconds(0.2f);
		Reset(startResetAgain: false);
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
        if (!gameOver)

        {
            gameOver = true;
            if (!win)
            {
                loosingPanel.SetActive(true);
            }
            else
            {
                StartCoroutine(FadeInWin());

            }
            dude.Fallen(true);
            Countdown.Instance.Stop();
            locked = true;
        }

	}


    IEnumerator FadeInWin()
    {
        Color startColor = new Color (1,1,1,0);
        winImage.color = startColor;
        winImage.gameObject.SetActive(true);

        float alpha = 0;

        while(alpha < 1)
        {
            alpha += 0.5f * Time.deltaTime;
            winImage.color = new Color (1,1,1, alpha);
        yield return null;
        }


    }
}
