using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeedbackHandler : MonoBehaviour
{
    [SerializeField] GameManager gameManager;             // Reference to the GameManager
    [SerializeField] PhotographHandler photographHandler; // Reference to the photograph handler

    [SerializeField] private TMP_Text _feedbackText;      // Reference to the UI Text for displaying feedback
    [SerializeField] private string _fact;

    // Function to update and display feedback
    public void UpdateFeedback()
    {
        // Get the currently chosen PhotographSO from the photograph handler
        PhotographSO currentPhotograph = (PhotographSO)photographHandler.CurrentItem();

        // Check if a valid photographSO is chosen
        if (currentPhotograph != null)
        {
            // Get the fact from the current PhotographSo
            _fact = currentPhotograph.Fact;

            // Display the fact in the UI Text
            _feedbackText.text = _fact;
        } else {
            // If no valid PhotographSO is chosen, clear the feedback UI
            _feedbackText.text = "";
            Debug.LogWarning("there is no fact");
        }
    }

    public void RemoveFeedback()
    {
        // Set the text to nothing
        _feedbackText.text = "";
    }
}
