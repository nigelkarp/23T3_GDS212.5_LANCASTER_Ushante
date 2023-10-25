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

    [SerializeField] private GameObject ArtTitle; // UI title gameobject (with different title children)

    // Start is called before the first frame update
    void Start()
    {
        // 'Start Game' function  reference
        PlayGame();
    }

    // Update is called once per frame
    void Update()
    {
        // Check that the player has answered 
        if (scoreHandler.HasAnswered())
        {
            CorrectAnswer();
            IncorrectAnswer();
        }

        // if the isgameover bool is not true
        if (!_isGameOver)
        {
            // Check if the game is over based on your game's criteria
            if (GameOverConditionsMet())
            {
                // if it is met set the bool to true and end game
                _isGameOver = true;
                EndGame();
            }
        }

        // Call from the players input (from playerinputhandler)
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

        // Display the final score and feedback
        // Calculate whether the player is qualified to be a curator
        // (this can be done with score + predetermined thresholds)
        // Threshold hit = feedback given

        // Update the scorehandler with the final score or call from the score handler
        // scoreHandler.UpdateScore(score);

        // Display feedback based on the final score
        // DisplayFeedback();

    }

    // Load and display the next photograph
    void LoadPhotograph()
    {
        photographHandler.LoadNextPhotograph();
        
        //Change has answered to false in the photograph handler
    }

    // Handle a correct answer
    void CorrectAnswer()
    {
        // Check if the correct answer has been made (get from scorehandler)
        if (scoreHandler.IsCorrectAnswer())
        {
            Debug.Log("correct answer chosen");

            // Enable the UI ArtTitle ThisisArtTitle (disable all others)

            // Change position of the Art item (to pos2)

            // Display art fact or description, this will use the artfacts database later developed

            // Load the next photograph
            LoadPhotograph();
        }
        
    }

    // Handle incorrect answer
    void IncorrectAnswer()
    {
        // Check if the incorrect answer has been made (get from scorehandler)
        if (!scoreHandler.IsCorrectAnswer())
        {
            Debug.Log("incorrect answer chosen");

            // Enable the UI ArtTitle child ThisIsntArtTitle (disable all others)

            // Change position of the Art item (to pos2)

            // Display information about the object
            DisplayAboutItem();

            // Load the next photograph (maybe make it so the player has to click something for this to happen)
            LoadPhotograph();
        }
    }

    void DisplayAboutItem()
    {
        // Display an art fact or description from the ArtFacts database
        // This will be implemented in this script/ will call from the artfactsdatabase script
        // Used for all Items (artworks and nonartworks)
    }

    bool GameOverConditionsMet()
    {
        // Game over conditions will be set here
        // Set number of questions / rounds needed to be played
        return false;
    }
}
