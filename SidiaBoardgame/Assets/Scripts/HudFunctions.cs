using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HudFunctions : MonoBehaviour
{
    public PlayerInfos player1;
    public PlayerInfos player2;

    public GameObject winnerMessage;
    public TextMeshProUGUI winnerText;

    public TextMeshProUGUI player1Name;
    public TextMeshProUGUI player1Life;
    public TextMeshProUGUI player1Damage;
    public TextMeshProUGUI player1Move;

    public TextMeshProUGUI player2Name;
    public TextMeshProUGUI player2Life;
    public TextMeshProUGUI player2Damage;
    public TextMeshProUGUI player2Move;

    void Update()
    {
        player1Name.text = player1.nickname;
        player1Life.text = "Vida : " + player1.life.ToString();
        player1Damage.text = "Ataque : " + player1.damage.ToString();
        player1Move.text = "Movimentos : " + player1.moves.ToString();

        player2Name.text = player2.nickname;
        player2Life.text = "Vida : " + player2.life.ToString();
        player2Damage.text = "Ataque : " + player2.damage.ToString();
        player2Move.text = "Movimentos : " + player2.moves.ToString();  
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ResetStatus()
    {
        player1.life = player1.maxLife;
        player1.damage = player1.maxDamage;
        player2.life = player2.maxLife;
        player2.damage = player2.maxDamage;
    }
    public void TurnPass()
    {
        if (player1.turn && !player2.turn)
        {
            player1.moves = 0;
            player1.turn = false;
            player1.damage = player1.maxDamage;
            player2.moves = 3;
            player2.turn = true;
            player2.alreadyAttacked = false;
        }
        else if (player2.turn && !player1.turn)
        {
            player2.moves = 0;
            player2.turn = false;
            player2.damage = player2.maxDamage;
            player1.moves = 3;
            player1.turn = true;
            player1.alreadyAttacked = false;
        }
    }
    
    public void CheckWinner()
    {
        if (player1.life <= 0)
        {
            winnerMessage.SetActive(true);
            winnerText.text = player2.nickname + " venceu!";
        }
        if (player2.life <= 0)
        {
            winnerMessage.SetActive(true);
            winnerText.text = player1.nickname + " venceu!";
        }
    }
}
