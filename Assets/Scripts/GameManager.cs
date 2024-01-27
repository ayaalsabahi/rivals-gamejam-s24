using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { Menu, PreRound, PlayerOneSabotage, PlayerTwoGuess,
                        PlayerTwoSabotage, PlayerOneGuess, PostRound, GameOver };

public class GameManager : MonoBehaviour
{
    public static GameManager S; // define the singleton

    public GameState currentState;

    private float playerOneApproval;
    private float playerTwoApproval;
    private float timer;
    private float RATING_INCREMENT = 10.0f;
    private float MAX_POINTS = 50.00f;

    public GameObject playerOne;
    public GameObject playerTwo;

    //winner starts at null
    public GameObject winner;

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
        StartRound(playerOne);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartRound(GameObject thePlayer)
    {
        GameManager.S.currentState = (thePlayer == playerOne)
            ? GameState.PlayerOneSabotage : GameState.PlayerTwoSabotage;
    }

    public void CorrectAnswer(GameObject thePlayer)
    {
        // thePlayer rating increases by 10 points
        IncreasePlayerRating(thePlayer, RATING_INCREMENT);
        // "Well said!" "Astute observation as always."

        // check for if player wins
        if (playerOneApproval >= 100 || playerTwoApproval == 100)
        { 
            StopAllCoroutines();
            GameOverRoutine();
        }
        else {
            // switches to other player's turn
            SwitchTurn();
        }
    }

    public void WrongAnswer(GameObject thePlayer)
    {
        // thePlayer's rating stays the same
        // "That... didn't sound right." "Boo!" "...What?"
        // switches to other player's turn
        SwitchTurn();
    }

    private void IncreasePlayerRating(GameObject thePlayer, float ratingIncrease)
    {
        if (thePlayer == playerOne)
            playerOneApproval += ratingIncrease;
            if(playerOneApproval >= MAX_POINTS) winner = playerOne;

        else
            playerTwoApproval += ratingIncrease;
        if (playerTwoApproval >= MAX_POINTS) winner = playerTwo;
    }

    private void SwitchTurn()
    {
        GameManager.S.currentState = (GameManager.S.currentState == GameState.PlayerTwoSabotage)
            ? GameState.PlayerOneSabotage : GameState.PlayerTwoSabotage;
    }

    private IEnumerator GameOverRoutine()
    {
        yield return new WaitForSeconds(1.0f);
    }
}
