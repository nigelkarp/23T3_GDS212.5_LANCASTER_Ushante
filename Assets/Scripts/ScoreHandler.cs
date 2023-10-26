using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] PhotographHandler photographHandler;   // Reference to the PhotographHandler script
    [SerializeField] PlayerInputHandler playerInputHandler; // Reference to the PlayerInputHandler script

    private bool _isArtworkValue;
    private bool _isYesButtonClickValue;

    private int _playerScore;               // Players score variable
    private bool _isCorrectAnswer;           // Is the players answer correct

    public bool hasAnswered = false;       // Has the player answered

    // Initialize players score (set score as 0)
    private void Start()
    {
        _playerScore = 0;
    }

    // update the players score (this will depend on the playerinputhandler)
    public void IncreasePlayerScore()
    {
        _isArtworkValue = photographHandler.IsCurrentArtwork();
        _isYesButtonClickValue = playerInputHandler.GetBtnClicked();

        if (!hasAnswered)    // Check if the player has answered
        { 
            if (_isArtworkValue && _isYesButtonClickValue || !_isArtworkValue && !_isYesButtonClickValue)
            {
                _playerScore++;
                Debug.Log("Player Score: " + _playerScore);
                _isCorrectAnswer = true;
                hasAnswered = true;
            } 
            else
            {
                _isCorrectAnswer = false;
                hasAnswered = true;
            }
        }
    }

    // get the players score function
    // return the current value of player score
    public int GetPlayerScore()
    {
        return _playerScore;
    }

    public bool IsCorrectAnswer()
    {
        return _isCorrectAnswer;
    }

    public bool HasAnswered()
    {
        return hasAnswered;
    }

    // Function to set has answered to false
    public void resetAnswering()
    {
        hasAnswered = false;
    }
}
