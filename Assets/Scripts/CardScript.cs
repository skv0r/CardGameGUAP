using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    // Значения карт, 2 пик = 2 итд
    public int value = 0;

    public int GetValueOfCard() 
    {
        return value;
    }

    public void SetValue(int newValue)
    {
        value = newValue;
    }

    public string GetSpriteName() 
    {
        return GetComponent<SpriteRenderer>().sprite.name;
    }

    public void SetSprite(Sprite newSprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    public void ResetCard()
    {
        Sprite back = GameObject.Find("DeckController").GetComponent<DeckScript>().GetCardBack();
        gameObject.GetComponent<SpriteRenderer>().sprite = back;
        value = 0;
    }
}

