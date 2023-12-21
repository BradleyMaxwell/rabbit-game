using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

[RequireComponent(typeof(GameEventListener))] // need to listen for the player's health changing
public class UIPlayerHealth : MonoBehaviour // changed how the health hearts are shown on the UI when the player's health changes
{
    [SerializeField] private GameObject heartPrefab; // the prefab game object which is instantiated for every 1 health point up to the player's max health
    [SerializeField] private Image heartImage; // the heart image that represents 1 current health point
    [SerializeField] private Image missingHeartImage; // the heart image that represents 1 missing health point
    [SerializeField] private PlayerHealthInfo playerHealthInfo;
    private int currentHealthDisplayed; // keep track of how many hearts are being shown at the time of the health change event occurring so the script knows how many hearts to add or remove
    private List<GameObject> hearts = new List<GameObject>(); // stores the heart UI elements that are seen on the player's UI

    private void Start()
    {
        SetupHearts();
    }

    public void ChangeHearts() // show heart sprites for each health point and missing heart sprites for missing health points from left to right 
    {
        // from the rightmost heart displayed (hearts[currentHealthDisplayed - 1]), either change hearts to the right or left based on change in health
        int healthChange = playerHealthInfo.CurrentHealth - CurrentHealthDisplayed; // find how much the hearts need to change
        if (healthChange < 0) // the player's health has gone down
        {
            // go left changing hearts to missing hearts
            for (int i = currentHealthDisplayed - 1; i > playerHealthInfo.CurrentHealth - 1; i--)
            {
                Image currentHeartImage = hearts[i].GetComponent<Image>();
                currentHeartImage.color = missingHeartImage.color;
            }
        } else if (healthChange > 0) // the player's health has gone up
        {
            // go right changing hearts from missing hearts to hearts, starting from the next heart in the list as that is the first missing heart
            for (int i = currentHealthDisplayed; i <= playerHealthInfo.CurrentHealth - 1; i++)
            {
                Image currentMissingHeartImage = hearts[i].GetComponent<Image>();
                currentMissingHeartImage.color = heartImage.color;
            }
        }
        CurrentHealthDisplayed = playerHealthInfo.CurrentHealth; // current health displayed needs updating for when this function is next triggered by the health change event
    }

    private void SetupHearts() // called when the scene starts to setup the hearts and position them correctly based on the player's max health
    {
        for (int i = 0; i < playerHealthInfo.MaxHealth; i++)
        {
            GameObject heart = Instantiate(heartPrefab, transform); // create a heart prefab as a child element of this parent game object
            hearts.Add(heart);
            float offset = i * heart.GetComponent<RectTransform>().rect.width; // how much to move the current heart UI element to the right by so each heart is shown to the right of the previous
            heart.transform.localPosition = new Vector3(offset, 0f, 0f);
        }
        CurrentHealthDisplayed = playerHealthInfo.CurrentHealth;
    }

    private int CurrentHealthDisplayed
    {
        get { return currentHealthDisplayed; }
        set { currentHealthDisplayed = value; }
    }
}
