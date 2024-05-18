using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Игровые кнопки
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;
    public Button betBtn;

    private int standClicks = 0;

    // Доступ к скриптам дилера и игрока
    public PlayerScript playerScript;
    public PlayerScript dealerScript;

    // Обще-доступный текст для худа
    public Text scoreText;
    public Text dealerScoreText;
    public Text betsText;
    public Text cashText;
    public Text mainText;
    public Text standBtnText;

    // Вторая карта дилера (скрытая)
    public GameObject hideCard;
    // Ставка по умолчанию
    int pot = 0;

    void Start()
    {
        // Наложение на объект click способности
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StandClicked());
        betBtn.onClick.AddListener(() => BetClicked());
    }

    private void DealClicked()
    {
        
        // Сброс раунда, скрывает временный текст, подготавливает руку
        playerScript.ResetHand();
        dealerScript.ResetHand();
        // Скрывает счет руки на начало игры
        dealerScoreText.gameObject.SetActive(false);
        mainText.gameObject.SetActive(false);
        dealerScoreText.gameObject.SetActive(false);
        GameObject.Find("Deck").GetComponent<DeckScript>().Shuffle();
        playerScript.StartHand();
        dealerScript.StartHand();
        // Обновление руки на табло
        scoreText.text = "Hand: " + playerScript.handValue.ToString();
        dealerScoreText.text = "Hand: " + dealerScript.handValue.ToString();
        // Раскрывает руку дилера (скрытую карту)
        hideCard.GetComponent<Renderer>().enabled = true;
        // Кнопки управления видимости
        dealBtn.gameObject.SetActive(false);
        hitBtn.gameObject.SetActive(true);
        standBtn.gameObject.SetActive(true);
        standBtnText.text = "Stand";
        // Установка стандартной ставки
        pot = 40;
        betsText.text = "Bets: $" + pot.ToString();
        playerScript.AdjustMoney(-20);
        cashText.text = "$" + playerScript.GetMoney().ToString();

    }

    private void HitClicked()
    {
        // Проверка карт на столе (их нахождение)
        if (playerScript.cardIndex <= 10)
        {
            playerScript.GetCard();
            scoreText.text = "Hand: " + playerScript.handValue.ToString();
            if (playerScript.handValue > 20) RoundOver();
        }
    }

    private void StandClicked()
    {
        standClicks++;
        if (standClicks > 1) RoundOver();
        HitDealer();
        standBtnText.text = "Call";
    }

    private void HitDealer()
    {
        while (dealerScript.handValue < 16 && dealerScript.cardIndex < 10)
        {
            dealerScript.GetCard();
            dealerScoreText.text = "Hand: " + dealerScript.handValue.ToString();
            if (dealerScript.handValue > 20) RoundOver();
        }
    }

    // Проверка победы/ поражения, перебор руки
    void RoundOver()
    {
        // Булевые значения рук дилера и игрока (проверка на blackjack)
        bool playerBust = playerScript.handValue > 21;
        bool dealerBust = dealerScript.handValue > 21;
        bool player21 = playerScript.handValue == 21;
        bool dealer21 = dealerScript.handValue == 21;
        // Если stand нажат дважды, нет блекджека или перебора, выход из функции
        if (standClicks < 2 && !playerBust && !dealerBust && !player21 && !dealer21) return;
        bool roundOver = true;
        // У обоих перебор, возврат ставок
        if (playerBust && dealerBust)
        {
            mainText.text = "All Bust: Bets returned";
            playerScript.AdjustMoney(pot / 2);
        }
        // У игрока перебор, у дилера нет, или если дилер имеет руку больше, ПОБЕДА ДИЛЕРА
        else if (playerBust || (!dealerBust && dealerScript.handValue > playerScript.handValue))
        {
            mainText.text = "Dealer wins!";
        }
        // перебор дилерра, у игрока нет, или если игрок имеет руку больше, ПОБЕДА ИГРОКА
        else if (dealerBust || playerScript.handValue > dealerScript.handValue)
        {
            mainText.text = "You win!";
            playerScript.AdjustMoney(pot);
        }
        //Проверка на ничью, возврат ставок
        else if (playerScript.handValue == dealerScript.handValue)
        {
            mainText.text = "Push: Bets returned";
            playerScript.AdjustMoney(pot / 2);
        }
        else
        {
            roundOver = false;
        }
        // Установка ui для следущей партии
        if (roundOver)
        {
            hitBtn.gameObject.SetActive(false);
            standBtn.gameObject.SetActive(false);
            dealBtn.gameObject.SetActive(true);
            mainText.gameObject.SetActive(true);
            dealerScoreText.gameObject.SetActive(true);
            hideCard.GetComponent<Renderer>().enabled = false;
            cashText.text = "$" + playerScript.GetMoney().ToString();
            standClicks = 0;
        }
    }

    // Добавление денег ставки по нажатию
    void BetClicked()
    {
        Text newBet = betBtn.GetComponentInChildren(typeof(Text)) as Text;
        int intBet = int.Parse(newBet.text.ToString().Remove(0, 1));
        playerScript.AdjustMoney(-intBet);
        cashText.text = "$" + playerScript.GetMoney().ToString();
        pot += (intBet * 2);
        betsText.text = "Bets: $" + pot.ToString();
    }
}
