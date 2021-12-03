using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterCard : MonoBehaviour
{
    public PlayerInfos player;
    public CharacterStatus character;

    public TextMeshProUGUI charLife;
    public TextMeshProUGUI charDamage;
    // Start is called before the first frame update
    void Start()
    {
        charLife.text = "Vida : " + character.life;
        charDamage.text = "Ataque : " + character.damage;
    }

    public void ChosenCharacter()
    {
        player.life = character.life;
        player.maxLife = character.life;
        player.damage = character.damage;
        player.maxDamage = character.damage;
    }

}
