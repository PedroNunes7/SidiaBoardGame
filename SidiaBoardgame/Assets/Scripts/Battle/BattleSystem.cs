using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class BattleSystem : MonoBehaviour
{
    public AudioSource punchSound;
    public PlayerInfos player1;
    public PlayerInfos player2;

    int[] dicesPlayer1 = new int[3];
    int[] dicesPlayer2 = new int[3];

    int battlesWonPlayer2 = 0;
    int battlesWonPlayer1 = 0;

    #region Text Variables
    public TextMeshProUGUI player1Name;
    public TextMeshProUGUI player2Name;
    public TextMeshProUGUI firstDicePlayer1;
    public TextMeshProUGUI secondDicePlayer1;
    public TextMeshProUGUI thirdDicePlayer1;
    public TextMeshProUGUI firstDicePlayer2;
    public TextMeshProUGUI secondDicePlayer2;
    public TextMeshProUGUI thirdDicePlayer2;
    public TextMeshProUGUI showWinner;

    #endregion
    public void RandomizeDices()
    {
        for (int i = 0; i < 3; i++)
        {
            dicesPlayer1[i] = UnityEngine.Random.Range(1, 6);
        }  

        for (int i = 0; i < 3; i++)
        {
            dicesPlayer2[i] = UnityEngine.Random.Range(1, 6);
        }
            
    }
    public void OrganizeDices()
    {
        Array.Sort(dicesPlayer1);
        Array.Sort(dicesPlayer2);
        Array.Reverse(dicesPlayer1);
        Array.Reverse(dicesPlayer2);
    }

    public void CompareResults()
    {
        for (int i = 0; i < 3; i++)
        {
            if (dicesPlayer1[i] > dicesPlayer2[i])
                battlesWonPlayer1++;
            if (dicesPlayer1[i] < dicesPlayer2[i])
                battlesWonPlayer2++;
            if (dicesPlayer1[i] == dicesPlayer2[i] && player1.turn)
                battlesWonPlayer1++;
            if (dicesPlayer1[i] == dicesPlayer2[i] && player2.turn)
                battlesWonPlayer2++;
        }
    }

    public void ShowDices()
    {
        player1Name.text = player1.nickname;
        player2Name.text = player2.nickname;
        firstDicePlayer1.text = dicesPlayer1[0].ToString();
        firstDicePlayer2.text = dicesPlayer2[0].ToString();
        secondDicePlayer1.text = dicesPlayer1[1].ToString();
        secondDicePlayer2.text = dicesPlayer2[1].ToString();
        thirdDicePlayer1.text = dicesPlayer1[2].ToString();
        thirdDicePlayer2.text = dicesPlayer2[2].ToString();


    }
    public void StartBattle()
    {
        RandomizeDices();
        OrganizeDices();
        CompareResults();
        ShowDices();
        punchSound.Play();
        if (battlesWonPlayer1 > battlesWonPlayer2)
        {
            player2.life -= player1.damage;
            showWinner.text = player1.nickname + " venceu a batalha!";
        }
        else
        {
            player1.life -= player2.damage;
            showWinner.text = player2.nickname + " venceu a batalha!";
        }
        battlesWonPlayer1 = 0;
        battlesWonPlayer2 = 0;
            
    }
    
    


}
