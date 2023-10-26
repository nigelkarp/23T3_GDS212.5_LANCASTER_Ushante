using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private Button _yesBtn;        // Yes button reference
    [SerializeField] private Button _noBtn;         // No button reference
    [SerializeField] private Button _nextItemBtn;   // Next item button reference

    [SerializeField] ScoreHandler scoreHandler;     // Reference to the ScoreHandler script, will use more later

    private bool isYesClicked;                  // Bool to check which button is clicked
    private bool isNextClicked;         // Bool to check if button is clicked

    // private bool hasAnswered = false;   // Bool to check if the player has already answered

    // Listen for player input on start
    private void Start()
    {
        isNextClicked = false;

        // Listen for button clicks (on the yes and no btns) by adding listeners to them
        _yesBtn.onClick.AddListener(OnYesBtnClick);
        _noBtn.onClick.AddListener(OnNoBtnClick);

        _nextItemBtn.onClick.AddListener(OnNextItemClick); // I need to disable this btn unless an answer is given
    }

    // Handle Yes input, and communicate this to GM
    void OnYesBtnClick()
    {
        isYesClicked = true;

        // Play Increaseplayerscore func from scorehandler
        scoreHandler.IncreasePlayerScore();

        // set active circle out image object  (i can add to on hover)

        Debug.Log("Yes Clicked");     
    }

    // Handle No input, and communicate this to GM
    void OnNoBtnClick()
    {

        isYesClicked = false;

        // Play Increaseplayerscore func from scorehandler
        scoreHandler.IncreasePlayerScore();

        // set active circle out image object (i can add to on hover)

        Debug.Log("No Clicked");
    }

    // Perhaps a method for on hover that will enable the circle

    // Handle player nect image input, communicate to GM
    void OnNextItemClick()
    {
        Debug.Log("Next btn clicked");
        isNextClicked = true;
    }
    public bool GetNextItemClick()
    {
        return isNextClicked;
    }

    public void resetNextClick()
    {
        isNextClicked = false;
    }

    // Return whether the yes or no button has been clicked
    public bool GetBtnClicked()
    {
        return isYesClicked;
    }
}
