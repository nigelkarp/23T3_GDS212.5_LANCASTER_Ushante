using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] PhotographHandler photographHandler;   // Reference to the PhotographHandler script
    [SerializeField] PlayerInputHandler playerInputHandler; // Reference to the PlayerInputHandler script

    private int _playerScore;        // Players score variable
    private bool _isArtworkValue;    // Bool for whether an item is returned as an artwork

    // Initialize players score (set score as 0)
    private void Start()
    {
        _playerScore = 0;
    }

    // update the players score (this will depend on the playerinputhandler)
    void UpdatePlayerScore()
    {
        _isArtworkValue = photographHandler.GetIfItemArtwork();   // Get _isArtwork bool value from photograph handler
        
    }

    // call from the player input handler, and compare against a call from the photograph 
    // handler that returns whether the true list or false list is currently being chosen from
    // (set a bool that changes)
    //if yes && correctImage == true, add to score
    // if no && correctImage == true, nothing
    // if no && falseImage == true, add to score
    // if yes && falseImage == true, nothing

    // get the players score function
    // return the current value of player score
}
