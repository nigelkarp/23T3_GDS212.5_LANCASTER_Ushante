using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _score;                          // Players score

    private bool _isGameOver = false;            // Flag to track the game state 

    [SerializeField] ScoreHandler scoreHandler;             // Reference to the ScoreHandler script, will use more later
    [SerializeField] PhotographHandler photographHandler;   // Reference to the PhotographHandler script
    [SerializeField] PlayerInputHandler playerInputHandler; // Reference to the PlayerInputHandler script
    [SerializeField] FeedbackHandler feedbackHandler;       // Reference to the FeedbackHandler script
    [SerializeField] TitleHandler titleHandler;

    [SerializeField] private GameObject _gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        // 'Start Game' function  reference
        PlayGame();
        titleHandler.ResetTitle();
        titleHandler.NextImageTitleOff();
        photographHandler._imageCentred = true;
        _gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check that the player has answered 
        if (scoreHandler.HasAnswered())
        {
            // Set the current title
            titleHandler.SetActiveTitle();
            CorrectAnswer();
            IncorrectAnswer();
        }

        // if the isgameover bool is not true
        if (!_isGameOver)
        {
            // Check if the game is over based on your game's criteria
            if (GameOverConditionsMet() == true)
            {
                // if it is met set the bool to true and end game
                _isGameOver = true;
                EndGame();
            }
        }
    }


    // Game initialisation logic 
    void PlayGame()
    {
        // call the next (randomly chosen) photograph from the photograph handling script
        photographHandler.LoadNextPhotograph();
    }

    // Game Over logic 
    void EndGame()
    {
        Debug.Log("game over");

        // throw up game over screen
        _gameOverUI.SetActive(true);

        // Change score UI
        scoreHandler.UpdateFinalScore();
    }

    // Load and display the next photograph
    void LoadPhotograph()
    {
        if (playerInputHandler.GetNextItemClick())
        {
            titleHandler.ResetTitle();
            feedbackHandler.RemoveFeedback();
            photographHandler.LoadNextPhotograph();

            if (!photographHandler._imageCentred)
            {
                photographHandler._imageCentred = true;
                photographHandler.ChangeImagePosition();
            }
        }
    }

    void MoveImageToSide()
    {
        if (photographHandler._imageCentred)
        {
            photographHandler._imageCentred = false;
            photographHandler.ChangeImagePosition();
        }
    }

    // Handle a correct answer
    void CorrectAnswer()
    {
        // Check if the correct answer has been made (get from scorehandler)
        if (scoreHandler.IsCorrectAnswer())
        {
            // Change position of the Art item (to pos2)
            MoveImageToSide();

            // Display art fact or description
            feedbackHandler.UpdateFeedback();
            LoadPhotograph();
        }
    }

    // Handle incorrect answer
    void IncorrectAnswer()
    {
        // Check if the incorrect answer has been made (get from scorehandler)
        if (!scoreHandler.IsCorrectAnswer())
        {
            // Change position of the Art item (to pos2)
            MoveImageToSide();

            // Display information about the object
            feedbackHandler.UpdateFeedback();
            LoadPhotograph();
        }
    }

    // Game over conditions will be set here
    bool GameOverConditionsMet()
    {
        // Set number of questions / rounds needed to be played
        if (photographHandler.IsListFinished())
        {
            return true;
        }
        return false;
    }

}
