using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleHandler : MonoBehaviour
{
    [SerializeField] private GameObject ArtTitle; // UI title gameobject (with different title children)
    
    public int selectedTitle;                   // Current title selected

    // set the title depending on game state
    public void SetActiveTitle()
    {
        GameObject isThisArtTitle = ArtTitle.transform.GetChild(0).gameObject;
        GameObject thisIsArtTitle = ArtTitle.transform.GetChild(1).gameObject;
        GameObject thisIsntArtTitle = ArtTitle.transform.GetChild(2).gameObject;

        // IF no items chosen yet/ default
        if (selectedTitle == 0)
        {
            isThisArtTitle.gameObject.SetActive(true);

            thisIsArtTitle.gameObject.SetActive(false);
            thisIsntArtTitle.gameObject.SetActive(false);
        }

        //IF the item is an artwork title
        if (selectedTitle == 1)
        {

            thisIsArtTitle.gameObject.SetActive(true);

            isThisArtTitle.gameObject.SetActive(false);
            thisIsntArtTitle.gameObject.SetActive(false);
        }

        // IF the item isnt an artwork title
        if (selectedTitle == 2)
        {
            thisIsntArtTitle.gameObject.SetActive(true);

            thisIsArtTitle.gameObject.SetActive(false);
            isThisArtTitle.gameObject.SetActive(false);

        }
    }

}
