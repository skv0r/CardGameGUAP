using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Deck deck; // Ссылка на объект Deck
    public Transform[] cardPositions; // Массив для позиций карт на столе

    void Start()
    {
        if (deck == null)
        {
            Debug.LogError("Deck is not assigned in the GameManager.");
            return;
        }

        if (cardPositions == null || cardPositions.Length == 0)
        {
            Debug.LogError("Card positions are not assigned in the GameManager.");
            return;
        }

        SetupGame();
    }

    void SetupGame()
    {
        DistributeCards();
    }

    void DistributeCards()
    {
        for (int i = 0; i < cardPositions.Length; i++)
        {
            if (cardPositions[i] == null)
            {
                Debug.LogError($"CardPosition{i + 1} is not assigned in the GameManager.");
                continue;
            }

            Card drawnCard = deck.DrawCard();
            if (drawnCard != null)
            {
                GameObject cardObject = new GameObject("Card");
                cardObject.transform.position = cardPositions[i].position;

                // Добавьте компонент SpriteRenderer и настройте спрайт карты
                SpriteRenderer sr = cardObject.AddComponent<SpriteRenderer>();
                sr.sprite = GetCardSprite(drawnCard);
            }
            else
            {
                Debug.LogError("Drawn card is null.");
            }
        }
    }

    Sprite GetCardSprite(Card card)
    {
        // Логика для получения спрайта карты на основе ее значения и масти
        return null; // Здесь должна быть фактическая логика получения спрайта
    }
}
