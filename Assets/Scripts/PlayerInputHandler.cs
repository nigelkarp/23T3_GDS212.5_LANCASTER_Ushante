using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private Button _yesBtn; // Yes button reference
    [SerializeField] private Button _noBtn;  // No button reference

    private bool isYesClicked;          // Bool to check which button is clicked
    private bool hasAnswered = false;   // Bool to check if the player has already answered

    // Listen for player input on start
    private void Start()
    {
        // Listen for button clicks (on the yes and no btns) by adding listeners to them
        _yesBtn.onClick.AddListener(OnYesBtnClick);
        _noBtn.onClick.AddListener(OnNoBtnClick);
    }

    // Handle Yes input, and communicate this to GM
    void OnYesBtnClick()
    {
        if (!hasAnswered)
        {
            isYesClicked = true;
            hasAnswered = true; // Now it marks the players input as being made

            // set active circle out image object  (i can add to on hover)
            Debug.Log("Yes CLicked");
        }
        
    }

    // Handle No input, and communicate this to GM
    void OnNoBtnClick()
    {
        if (!hasAnswered)
        {
            isYesClicked = false;
            hasAnswered = true; // Now it marks the players input as being made

            // set active circle out image object (i can add to on hover)
            Debug.Log("No CLicked");
        }
    }

    // Perhaps a method for on hover that will enable the circle 

    // Return whether the yes or no button has been clicked
    public bool GetBtnClicked()
    {
        return isYesClicked;
    }

    public bool HasItBeenAnswered()
    {
        return hasAnswered;
    }
}
