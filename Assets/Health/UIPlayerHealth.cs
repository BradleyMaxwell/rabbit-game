using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameEventListener))] // need to listen for the player's health changing
public class UIPlayerHealth : MonoBehaviour // changed how the health hearts are shown on the UI when the player's health changes
{
    [SerializeField] private GameObject heartSpritePrefab; // the heart sprite that represents 1 health point
    [SerializeField] private GameObject missingHeartSpritePrefab; // the heart sprite used for if the player does not have 100% health
    [SerializeField] private PlayerHealthInfo playerHealthInfo;

    public void UpdateUIHearts() // show heart sprites for each health point and missing heart sprites for missing health points from left to right 
    {
        Debug.Log("updated hearts on UI");
    }
}
