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

    // Start is called before the first frame update
    void Start()
    {
        // 'Start Game' function  reference
        PlayGame();
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    // Handle a correct answer
    void CorrectAnswer()
    {
        

        // Update the score, do this in the score handler
        _score += 1;

        // Enable the UI ArtTitle ThisisArtTitle (disable all others)

        // Display art fact or description, this will use the artfacts database later developed

        // Load the next photograph
        LoadPhotograph();
    }

    // Handle incorrect answer
    void IncorrectAnswer()
    {
        // Display what the item is
        // Enable the UI ArtTitle child ThisIsntArtTitle (disable all others)

        // Display name of the item, probably from a name database or the name of the image
        //DisplayItemName();

        // Load the next photograph
        LoadPhotograph();
    }

    void DisplayArtFact()
    {
        // Display an art fact or description from the ArtFacts database
        // This will be implemented in this script/ will call from the artfactsdatabase script
    }

    void DisplayItemName()
    {
        // Display what the items name is
        // Either get the name from database or the name of the image and display it
        // This will work for both of the item types, but a non artwork will only display this.
        // Non artwork will feature extra info e.g. couch ("Although the swedish may disagree, this is just an ikea ... couch")
    }

    bool GameOverConditionsMet()
    {
        // Game over conditions will be set here
        // Set number of questions / rounds needed to be played
        return false;
    }
}
