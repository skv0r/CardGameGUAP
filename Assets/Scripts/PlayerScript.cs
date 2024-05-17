using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // весь модуль исполняет функционал игрока и дилера

    // получаем скрипты
    public CardScript cardScript;
    public DeckScript deckScript;

    // калькулятор суммы  рук дилера/плеера
    public int handValue = 0;

    // деньги на ставку
    private int money = 1000;

    // массив карт на столе
    public  GameObject[] hand;
    // индекс карты которое вскроют некст
    public int cardIndex = 0;

    // отслеживаем очки с 1 до 11
    List<CardScript> aceList = new List<CardScript>();



    public void StartHand()
    {
        GetCard();
        GetCard();
    }

    //выдача руки игроку или дилеру
    public int GetCard()
    {
        int cardValue = deckScript.DealCard(hand[cardIndex].GetComponent<CardScript>());

        //показ карты на экране

        hand[cardIndex].GetComponent<Renderer>().enabled = true;
        // добавление карты в руку 
        handValue += cardValue;
        //если 1 = туз  
        if (cardValue == 1)
        {
            aceList.Add(hand[cardIndex].GetComponent<CardScript>());
        }
        //проверка считать 11 а не 1 туз

        //AceCheck();
        cardIndex++;
        return handValue;
    }
}
