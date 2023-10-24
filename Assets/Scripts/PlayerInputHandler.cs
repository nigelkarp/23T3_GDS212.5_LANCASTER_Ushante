using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private Button _yesBtn; // Yes button reference
    [SerializeField] private Button _noBtn;  // No button reference

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
        // communicate to the game manager ...
    }

    // Handle No input, and communicate this to GM
    void OnNoBtnClick()
    {
        // communicate to the game manager ...
    }
}
