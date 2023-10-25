using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotographHandler : MonoBehaviour
{
    [SerializeField] private List<PhotographSO> _itemList; // List of Scriptable Objects

    List<PhotographSO> displayedItem = new List<PhotographSO>();

 
    [SerializeField] private GameObject _artImageObject;   // Reference to ArtImage gameobject
    [SerializeField] ScoreHandler scoreHandler;            // Reference to the ScoreHandler script

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
            bool isArtwork = nextItem.IsArt;

            // Display the selected image
            DisplayImage(nextItem.Image);

            // Set Score handler has answered to false
            scoreHandler.resetAnswering();
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
                return item;
            }
        }
        return null;
    }

    // My method, to display Image
    void DisplayImage(Sprite Image)
    {
        if (Image != null)
        {
            // Set the image within the artItem.artimage sprite renderer sprite
            _artImageObject.GetComponent<SpriteRenderer>().sprite = Image;
        }
    }
}
