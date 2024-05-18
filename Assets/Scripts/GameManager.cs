using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI; //класс кнопок ui

public class GameManager : MonoBehaviour
{
    // кнопки GameManager
    public Button dealButton;
    public Button hitButton;
    public Button standButton;
    public Button betButton;

    //доступ скриптов к плеееру и дилеру 
    public PlayerScript playerScript;
    public PlayerScript dealerScript;

    void Start()
    {
        //Добавление отлика по нажатию кнопок
        dealButton.onClick.AddListener(() => DealClicked());
        hitButton.onClick.AddListener(() => HitClicked());
        standButton.onClick.AddListener(() => StandClicked());

        
    }

    
    private void DealClicked()
    {
        GameObject.Find("Deck").GetComponent<DeckScript>().Shuffle();
        playerScript.StartHand();
        dealerScript.StartHand();
    }

    private void HitClicked()
    {
        
    }

    private void StandClicked()
    {
        
    }
}
