using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Photograph", menuName = "Photograph")]
public class PhotographSO : ScriptableObject
{
    public Sprite Image;
    public string Fact;
    public bool IsArt;
}
