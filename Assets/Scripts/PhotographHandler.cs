using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotographHandler : MonoBehaviour
{
    [SerializeField] private List<PhotographSO> _itemList; // List of Scriptable Objects

    List<PhotographSO> displayedItem = new List<PhotographSO>();

 
    [SerializeField] private GameObject _artImageObject;   // Reference to ArtImage gameobject
    [SerializeField] ScoreHandler scoreHandler;            // Reference to the ScoreHandler script
    [SerializeField] PlayerInputHandler playerInputHandler;
    [SerializeField] TitleHandler titleHandler; 

    public bool isArtwork; // bool to check if the item is an artwork or not
    private PhotographSO _currentItem;
    
    // Method to load the next photograph based on the game state
    public void LoadNextPhotograph()
    {
        // Reminder to populate artwork list
        if (_itemList.Count == 0)
        {
            Debug.LogWarning("Artwork List is empty");
            return;
        }

        // Randomly shuggle list 
        ShuffleList(_itemList);

        PhotographSO nextItem = GetNextUnusedItem();

        if (nextItem != null)
        {

            // Set the boolean to reflect whether it is an artwork or not
            isArtwork = nextItem.IsArt;
            
            // Set the current artwork displayed
            _currentItem = nextItem;

            // Display the selected image
            DisplayImage(nextItem.Image);

            // Set Score handler has answered to false
            scoreHandler.resetAnswering();

            // Set isnext clicked to false
            playerInputHandler.resetNextClick();

        }
    }

    // Method to shuffle a list using the Fisher-Yates shuffle algorithm
    void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    // Get the next unused artwork
    public PhotographSO GetNextUnusedItem()
    {
        foreach (var item in _itemList)
        {
            if (!displayedItem.Contains(item))
            {
                displayedItem.Add(item);
                Debug.Log("displayed item count:" + displayedItem.Count);
                Debug.Log("Itemlist count:" + _itemList.Count);
                return item;
            }
            return null;
        }
        return null;
    }

    // Display Image
    void DisplayImage(Sprite Image)
    {
        if (Image != null)
        {
            // Set the image within the artItem.artimage sprite renderer sprite
            _artImageObject.GetComponent<SpriteRenderer>().sprite = Image;
        }
    }

    // Returns isArt bool from the current item
    public bool IsCurrentArtwork()
    {
        return isArtwork;
    }

    // Returns the current Photograph Scriptable object
    public ScriptableObject CurrentItem()
    {
        return _currentItem;
    }

    public bool IsListFinished()
    {
        if (_itemList.Count == displayedItem.Count)
            {
                return true;
            }
        
        return false;
    }
}
