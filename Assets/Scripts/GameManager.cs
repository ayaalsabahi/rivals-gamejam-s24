using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameState { Menu, PreRound, Sabotaging, Guessing, PostRound, GameOver };

public enum winnerState { playerOneWin, playerTwoWin, playerOneLose, playerTwoLose, stillPlaying}

public class GameManager : MonoBehaviour


{
    public static GameManager S; // define the singleton

    public GameState currentState;

    public float playerOneApproval;
    public float playerTwoApproval;
    private float timer;
    private float RATING_INCREMENT = 10.0f;
    private float MAX_POINTS = 50.00f;
    public int STRIKE_COUNT = 2;

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
    }

    // Start is called before the first frame update
    void Start()
    {
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
    }

    private void StartRound()
    {
        GameManager.S.currentState = GameState.Sabotaging;
    }

    public void CorrectAnswer(GameObject thePlayer)
    {
        // thePlayer rating increases by 10 points
        IncreasePlayerRating(thePlayer, RATING_INCREMENT);
        // "Well said!" "Astute observation as always."

        // check for if player wins
        if (playerOneApproval >= MAX_POINTS || playerTwoApproval == MAX_POINTS)
        {
            StopAllCoroutines();
            GameOverRoutine();
        }
        else {
            // switches to other player's turn
        }
    }

    public void WrongAnswer(GameObject thePlayer)
    {
        // thePlayer's rating stays the same
        // "That... didn't sound right." "Boo!" "...What?"
        // switches to other player's turn
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
        
    }

    private IEnumerator GameOverRoutine()
    {
        yield return new WaitForSeconds(1.0f);
    }
}
