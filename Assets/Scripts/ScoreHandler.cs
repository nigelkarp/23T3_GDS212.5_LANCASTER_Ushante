using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] PhotographHandler photographHandler;   // Reference to the PhotographHandler script
    [SerializeField] PlayerInputHandler playerInputHandler; // Reference to the PlayerInputHandler script

    private bool _isArtworkValue;
    private bool _isYesButtonClickValue;

    private int _playerScore;               // Players score variable
    private bool hasAnswered = false;
    
    // Initialize players score (set score as 0)
    private void Start()
    {
        _playerScore = 0;
    }

    private void Update()
    {
        IncreasePlayerScore();
    }

    // update the players score (this will depend on the playerinputhandler)
    void IncreasePlayerScore()
    {
        _isArtworkValue = photographHandler.GetIfItemArtwork();
        _isYesButtonClickValue = playerInputHandler.GetBtnClicked();

        if (!hasAnswered)    // Check if the player has answered
        { 
            if (_isArtworkValue && _isYesButtonClickValue || !_isArtworkValue && !_isYesButtonClickValue)
            {
                _playerScore++;
                Debug.Log("Player Score: " + _playerScore);
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
}
