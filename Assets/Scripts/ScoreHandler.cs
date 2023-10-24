using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] PhotographHandler photographHandler;   // Reference to the PhotographHandler script
    [SerializeField] PlayerInputHandler playerInputHandler; // Reference to the PlayerInputHandler script

    private int _playerScore;               // Players score variable
    
    // Initialize players score (set score as 0)
    private void Start()
    {
        _playerScore = 0;
    }

    private void Update()
    {
        // Check if the player has clicked and an item has been identified as artwork
        if (playerInputHandler.GetBtnClicked() && photographHandler.GetIfItemArtwork())
        {
            IncreasePlayerScore();
        }
        else if (!playerInputHandler.GetBtnClicked() && !photographHandler.GetIfItemArtwork())
        {
            IncreasePlayerScore();
        }
    }

    // update the players score (this will depend on the playerinputhandler)
    void IncreasePlayerScore()
    {
        _playerScore++;
        Debug.Log("Player Score: " + _playerScore);
        
    }

    // get the players score function
    // return the current value of player score
    public int GetPlayerScore()
    {
        return _playerScore;
    }
}
