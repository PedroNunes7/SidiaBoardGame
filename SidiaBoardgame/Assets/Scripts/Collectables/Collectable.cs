using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public PlayerInfos player1;
    public PlayerInfos player2;
    public CollectableCounter counter;
    public AudioClip coinSound;

    [SerializeField]
    bool healthCollectable = false;
    [SerializeField]
    bool damageCollectable = false;
    [SerializeField]
    bool moveCollectable = false;

    [SerializeField]
    bool common = false;
    [SerializeField]
    bool rare = false;
    [SerializeField]
    bool epic = false;
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            #region Player 1 variables

            if (player1.turn)
            {
                if (healthCollectable)
                {
                    HealthCollectableBuff(player1);
                }
                if (damageCollectable)
                {
                    DamageCollectableBuff(player1);

                }
                if (moveCollectable)
                {
                    MoveCollectableBuff(player1);
                }
                if (player1.life > player1.maxLife)
                    player1.life = player1.maxLife;
            }
            #endregion

            #region Player 2 variables

            if (player2.turn)
            {
                if (healthCollectable)
                {
                    HealthCollectableBuff(player2);
                }
                if (damageCollectable)
                {
                    DamageCollectableBuff(player2);
                }
                if (moveCollectable)
                {
                    MoveCollectableBuff(player2);
                }
                if (player2.life > player2.maxLife)
                    player2.life = player2.maxLife;
            }
            #endregion

            counter.remainingCollectables--;
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            Destroy(this.gameObject);
        }
    }

    #region Collectable Functions
    public void HealthCollectableBuff(PlayerInfos player)
    {
        if (common)
            player.life++;
        if (rare)
            player.life += 2;
        if (epic)
            player.life += 4;
    }
    public void DamageCollectableBuff(PlayerInfos player)
    {
        if (common)
            player.damage++;
        if (rare)
            player.damage += 2;
        if (epic)
            player.damage += 4;
    }
    public void MoveCollectableBuff(PlayerInfos player)
    {
        if (common)
            player.moves++;
        if (rare)
            player.moves += 2;
        if (epic)
            player.moves += 4;
    }

    public void RandomizeTier()
    {
        int tier = Random.Range(1, 20);
        if (tier <= 12)
            common = true;
        if (tier >= 13 && tier <= 18)
            rare = true;
        if (tier >=19)
            epic = true;
    }

    public void ColoringByTier()
    {
        if (common)
            GetComponent<Renderer>().material.color = Color.green;
        if (rare)
            GetComponent<Renderer>().material.color = Color.cyan;
        if (epic)
            GetComponent<Renderer>().material.color = Color.magenta;
    }
    #endregion

    private void OnEnable()
    {
        common = false;
        rare = false;
        epic = false;
        RandomizeTier();
        ColoringByTier();
    }
     
}
