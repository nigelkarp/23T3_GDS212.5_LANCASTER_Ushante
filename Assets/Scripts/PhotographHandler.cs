using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotographHandler : MonoBehaviour
{
    // Separate lists for correct art and false art
    [SerializeField] private List<Sprite> _correctArtImages; // List of correct art images
    [SerializeField] private List<Sprite> _falseArtImages;   // List of false art images

    // Variables to keep track of displayed photos
    List<Sprite> displayedPhotos = new List<Sprite>();

    // Reference to ArtImage gameobject
    [SerializeField] private GameObject _artImageObject;

    private void Start()
    {
        LoadNextPhotograph();
    }

    // Method to load the next photograph based on the game state
    public void LoadNextPhotograph()
    {
        // Randomly select between displaying correct art or false art
        bool displayCorrectArt = (Random.value > 0.5f);  // 50% chance for either

        // Determine the game state and select the appropriate list
        List<Sprite> currentImageList = (displayCorrectArt) ? _correctArtImages : _falseArtImages;


        // Check if all photos have been displayed; if so, reset the displayed photos list
        if (displayedPhotos.Count == currentImageList.Count)
        {
            displayedPhotos.Clear();
        }

        // Randomly shuffle the current image list until an unused photo is found
        ShuffleList(currentImageList);

        // Find the first unused photo
        Sprite nextImage = null;
        foreach (var image in currentImageList)
        {
            if (!displayedPhotos.Contains(image))
            {
                nextImage = image;
                displayedPhotos.Add(image);
                break;
            }
        }

        // Display the selected image
        DisplayImage(nextImage);
        Debug.Log(nextImage.name);
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

    // My own method, to display Image
    void DisplayImage(Sprite Image)
    {
        if (Image != null)
        {
            // Set the image within the artItem.artimage sprite renderer sprite
        }
    }
}
