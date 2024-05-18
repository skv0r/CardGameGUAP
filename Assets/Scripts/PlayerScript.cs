using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//PlayerScript это функионал игрока и дилера (обоих), получение денег, ставка денег, получение карт, подсчет тузов как 1 или 11 
public class PlayerScript : MonoBehaviour
{

    // Получение скриптов карт и стола
    public CardScript cardScript;   
    public DeckScript deckScript;

    // Сумма колоды (руки) у игрока/дилера
    public int handValue = 0;

    // Стартовое значение денег при запуске игры
    private int money = 1000;

    // Массив карт на столе
    public GameObject[] hand;
    // Индекс следующей карты для игры
    public int cardIndex = 0;
    // Остлеживание туза от 1 до 11
    List<CardScript> aceList = new List<CardScript>();

    public void StartHand()
    {
        GetCard();
        GetCard();
    }

    // Добавление значения к руке дилера/игрока
    public int GetCard()
    {
        // Получение значения карты, чтобы использовать на столе
        int cardValue = deckScript.DealCard(hand[cardIndex].GetComponent<CardScript>());
        // Показ карт столе
        hand[cardIndex].GetComponent<Renderer>().enabled = true;
        // Добавление карты в тотал рук
        handValue += cardValue;
        // Если значение 1, то туз 11
        if(cardValue == 1)
        {
            aceList.Add(hand[cardIndex].GetComponent<CardScript>());
        }
        // Если значение 11, то присвоится стандартное значение 1
        AceCheck();
        cardIndex++;
        return handValue;
    }

    // Поиск нужного значения туза (1 или 11)
    public void AceCheck()
    {
        // for each ace in the lsit check
        foreach (CardScript ace in aceList)
        {
            if(handValue + 10 < 22 && ace.GetValueOfCard() == 1)
            {
                // если доходит, то присваивается card object value и hand
                ace.SetValue(11);
                handValue += 10;
            } else if (handValue > 21 && ace.GetValueOfCard() == 11)
            {
                // если доходит, то присваивается gameobject value и hand value
                ace.SetValue(1);
                handValue -= 10;
            }
        }
    }

    // Добавление денег на баланс для ставок
    public void AdjustMoney(int amount)
    {
        money += amount;
    }

    // Вывод пользователю количество денег в данный момент
    public int GetMoney()
    {
        return money;
    }

    // Скрывает все карты, сбрасывает значения блоков рук и всех вспомогательных функций
    public void ResetHand()
    {
        for(int i = 0; i < hand.Length; i++)
        {
            hand[i].GetComponent<CardScript>().ResetCard();
            hand[i].GetComponent<Renderer>().enabled = false;
        }
        cardIndex = 0;
        handValue = 0;
        aceList = new List<CardScript>();
    }
}
