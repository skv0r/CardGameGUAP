using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private List<Card> deck;

    void Start()
    {
        InitializeDeck();
    }

    void InitializeDeck()
    {
        deck = new List<Card>();

        // Создание колоды из 52 карт
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        foreach (string suit in suits)
        {
            foreach (string value in values)
            {
                deck.Add(new Card(value, suit));
            }
        }
    }

    public Card DrawCard()
    {
        if (deck.Count == 0)
        {
            return null;
        }

        int index = Random.Range(0, deck.Count);
        Card drawnCard = deck[index];
        deck.RemoveAt(index);
        return drawnCard;
    }
}

public class Card
{
    public string value;
    public string suit;

    public Card(string value, string suit)
    {
        this.value = value;
        this.suit = suit;
    }
}
