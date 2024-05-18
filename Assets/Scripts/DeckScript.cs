using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class DeckScript : MonoBehaviour
{
    public Sprite[] cardSprites;
    int[] cardValues = new int[53]; //задали столу массив 52 карт, поочередно каждой масти от туза к королю (после чего в объекте закину спрайты карт)
    int currentIndex = 0;
     
    void Start()
    {
        GetCardValues();
    }

    // Update is called once per frame
    void GetCardValues()
    {   
        int num = 0;
        //Цикл назначения значения картам
        for (int i = 0; i < cardSprites.Length; i++)
        {  
            num = i;
            //считает до блока количества карт (52) (А-К)
            num %= 13;
            //вычисление туза как 1 или 10
            if (num < 10 || num == 0)
            {
                num = 10;
            }
            cardValues[i] = num++;
        }
        currentIndex = 1;
    }

    public void Shuffle()
    {
        for (int i = cardSprites.Length -1; i > 0; --i)
        {
        int j = Mathf.FloorToInt(Random.Range(0.0f,1.0f) * cardSprites.Length - 1) + 1;
        Sprite face = cardSprites[i];
        cardSprites[i] =  cardSprites[j];
        cardSprites[j] = face;

        int value = cardValues[i];
        cardValues[i] = cardValues[j];
        cardValues[j] = value;
        }
    }

    public int DealCard(CardScript cardScript)
    {
        cardScript.SetSprite(cardSprites[currentIndex]);
        cardScript.SetValue(cardValues[currentIndex]);
        currentIndex++;
        return cardScript.GetValueOfCard();
    }

    public Sprite GetCardBack()
    {
        return  cardSprites[0];
    }
}

