using UnityEngine;

[CreateAssetMenu(fileName = "Player X Infos", menuName = "VariableReferences/PlayerInfo")]
public class PlayerInfos : ScriptableObject
{
    public string nickname;
    public int life;
    public int maxLife;
    public int damage;
    public int maxDamage;
    public bool turn = false;
    public int dices = 3;
    public int moves = 3;
}
