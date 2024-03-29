using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public enum GameState { Menu, PreRound, Sabotaging, Guessing, PostRound, GameOver };

public enum winnerState { playerOneWin, playerTwoWin, playerOneLose, playerTwoLose, stillPlaying }

public class GameManager : MonoBehaviour


{
    public AudioClip audioClip;
    private AudioSource audioSource;
    public static GameManager S; // define the singleton


    public AudioClip audioClip2;
    private AudioSource audioSource2;

    public GameState currentState;

    public float playerOneApproval;
    public float playerTwoApproval;
    private float timer;
    private GameObject stopwatch;
    private Animator stopwatchAnimator;
    private AnimationController animController;
    public float RATING_INCREMENT = 1.0f;
    public float MAX_POINTS = 10.00f;
    public int STRIKE_COUNT = 3;

    public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;
    public GameObject playerOne;
    public GameObject playerTwo;

    public bool isPlayerOne = true;

    //winner starts at being still playing
    public winnerState winnerIs = winnerState.stillPlaying;
    public int strikeCountPlayerOne = 0;
    public int strikeCountPlayerTwo = 0;

    private void Awake()
    {


        if (GameManager.S)
        {
            // the game manager already exists, destroy myself
            Destroy(this.gameObject);
        }
        else
        {
            S = this;
        }
        SetUpStopwatch();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;

        audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = audioClip2;

        if (audioSource2 != null) audioSource2.Play();
        else Debug.Log("Music null");

        // initialize relevant variables
        playerOneApproval = 0;
        playerTwoApproval = 0;
        GameManager.S.currentState = GameState.PreRound;
        DontDestroyOnLoad(this);
        StartRound();
    }

    // Update is called once per frame
    void Update()
    {
        // check for winner
        SetUpStopwatch();
    }

    private void StartRound()
    {
        StartCoroutine(PlayerTransition());
        NowSabotaging();
        Debug.Log("called in start round");
    }

    public void TimerAnimationStuff()
    {
        animController.ResetTimerAnimation();
        animController.StartAnimation();
        Debug.Log("called in timer animation stuff");
        
    }

    private void SetUpStopwatch()
    {
        stopwatch = GameObject.FindWithTag("Stopwatch");
        if (stopwatch != null) {
            animController = stopwatch.GetComponent<AnimationController>();
            stopwatchAnimator = stopwatch.GetComponent<Animator>();
            stopwatch.SetActive(true);
        }
        else Debug.LogError("Stopwatch_0 not found in the scene.");
        
    }

    public void CorrectAnswer(GameObject thePlayer)
    {
        // thePlayer rating increases by 10 points
        IncreasePlayerRating(thePlayer, RATING_INCREMENT);
        // "Well said!" "Astute observation as always."

        Debug.Log("got correct answer");
        if (animController != null)
        {
            Debug.Log("anim controller not nulllllllll");
            //animController.
            animController.StopAnimation();
            stopwatchAnimator.speed = 0.0f;
            Debug.Log("animator speed is=" + stopwatchAnimator.speed);

            Debug.Log("animation just stopped");
            animController.CorrectSprite();
        }
        else
        {
            Debug.LogError("AnimationController not found in the scene.");
        }

        // check for if player wins
        if (playerOneApproval >= MAX_POINTS || playerTwoApproval == MAX_POINTS)
        {
            StopAllCoroutines();
            GameOverRoutine();
        }
        else
        {
            // switches to other player's turn
            Debug.Log("is player one after = " + isPlayerOne);

            NowSabotaging();
            //SwitchTurn();
            Debug.Log("is player one after = " + isPlayerOne);
        }
    }

    public void WrongAnswer(GameObject thePlayer)
    {
        // thePlayer's rating stays the same
        // "That... didn't sound right." "Boo!" "...What?"
        // switches to other player's turn
        if (isPlayerOne) strikeCountPlayerOne++;
        else strikeCountPlayerTwo++;
    }

    private void IncreasePlayerRating(GameObject thePlayer, float ratingIncrease)
    {

        if (isPlayerOne)
        {
            if (playerOneApproval >= MAX_POINTS) winnerIs = winnerState.playerOneWin;
            playerOneApproval += ratingIncrease;
        }

        else
        {
            if (playerTwoApproval >= MAX_POINTS) winnerIs = winnerState.playerTwoWin;
            playerTwoApproval += ratingIncrease;
        }

    }

    public void SwitchTurn()
    {
        Debug.Log("switch turn called");
        isPlayerOne = !isPlayerOne;
        StartCoroutine(PlayerTransition());
        //NowSabotaging();
    }

    public void NowSabotaging()
    {
        GameManager.S.currentState = GameState.Sabotaging;
    }

    public void NowGuessing()
    {
        GameManager.S.currentState = GameState.Guessing;
    }

    public void BeginTimerGuessing()
    {
        NowGuessing();
        TimerAnimationStuff();
    }

    public void MakeSpritesNervous()
    {
        animController.NervousSprite();
    }

    public void MakeSpritesLose()
    {
        animController.LoseSprite();
    }

    private IEnumerator PlayerTransition()
    {
        Debug.Log("Coroutine started");
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            GameObject chadPeeking = GameObject.Find("SabotageUIP1");
            GameObject janicePeeking = GameObject.Find("SabotageUIP2");
            if (chadPeeking == null)
            {
                Debug.Log("Could not find chad overlay");
            }
            else if (janicePeeking == null)
            {
                Debug.Log("Could not find janice overlay");
            }

            else if (chadPeeking != null && isPlayerOne)
            {
                Debug.Log("Chad activated");
                chadPeeking.SetActive(true);
                janicePeeking.SetActive(false);
            }
            else if (janicePeeking != null && !isPlayerOne)
            {
                Debug.Log("chad deact");
                chadPeeking.SetActive(false);
                janicePeeking.SetActive(true);
            }

            yield return new WaitForSeconds(1.5f);

            Debug.Log("Chad & janice deactivated");
            if (chadPeeking != null)
                chadPeeking.SetActive(false);
            if (janicePeeking != null)
                janicePeeking.SetActive(false);
        }
    }

    private IEnumerator GameOverRoutine()
    {
        yield return new WaitForSeconds(1.0f);
    }

    public void PlayClickSound()
    {
        // Play the assigned click sound

        if (audioClip != null)
        {
            // Play the audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Problems :(((");
        }
    }
}