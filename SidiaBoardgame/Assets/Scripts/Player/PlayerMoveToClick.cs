using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoveToClick : MonoBehaviour
{
    NavMeshAgent agent;
    public PlayerInfos player;
    public MapManagement map;
    public CollectableCounter counter;
    public GameObject battleButton;
    public AudioSource walkSound;
    public ParticleSystem walkParticle;
    public ParticleSystem battleParticle;
    private void Start()
    { 
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            int layerMask = LayerMask.GetMask("Tile");
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, layerMask))
            {
                if (hit.transform.gameObject.tag == "Tile")
                {
                    if (hit.transform.gameObject.GetComponent<Tile>().moveable && player.moves >= 1 && player.turn)
                    {
                        agent.destination = hit.transform.position;
                        player.moves--;
                        hit.transform.gameObject.GetComponent<Tile>().collectable = false;
                        walkSound.Play();
                        walkParticle.Play();
                        AssignPosition(hit.transform.gameObject.GetComponent<Tile>());
                    }
                    if (hit.transform.gameObject.GetComponent<Tile>().attackable && player.turn)
                    {
                        if (!player.alreadyAttacked)
                        {
                            battleButton.SetActive(true);
                            player.alreadyAttacked = true;
                        }
                    }
                }
            }
                
        }
    }

    private void AssignPosition(Tile tileComponent)
    {
        if (player.player1)
        {
            map.player1Tile[0] = tileComponent.row;
            map.player1Tile[1] = tileComponent.col;
        }
        else if (player.player2)
        {
            map.player2Tile[0] = tileComponent.row;
            map.player2Tile[1] = tileComponent.col;
        }
        

        foreach (GameObject tile in map.tiles)
        {
            Tile iterableComponent = tile.GetComponent<Tile>();
            iterableComponent.moveable = false;
            iterableComponent.attackable = false;

            int[,] attackable = map.AttackableTiles(player);
            for (int i = 0; i < 8; i++)
            {
                if (player.player1)
                {
                    if (attackable[i, 0] == iterableComponent.row && attackable[i, 1] == iterableComponent.col && map.player2Tile[0] == iterableComponent.row && map.player2Tile[1] == iterableComponent.col)
                        iterableComponent.attackable = true;
                }
                if (player.player2)
                {
                    if (attackable[i, 0] == iterableComponent.row && attackable[i, 1] == iterableComponent.col && map.player1Tile[0] == iterableComponent.row && map.player1Tile[1] == iterableComponent.col)
                        iterableComponent.attackable = true;
                }
                
            }

            int[,] moveable = map.MoveableTiles(player);
            if (!iterableComponent.attackable)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (moveable[i, 0] == iterableComponent.row && moveable[i, 1] == iterableComponent.col)
                    {
                        iterableComponent.moveable = true;
                    }

                }
            }

        }

        if (counter.remainingCollectables <= 25)
        {
            map.SpawnCollectables();
            counter.remainingCollectables = 254;
        }
    }

    public void BattleEffect()
    {
        battleParticle.Play();
    }
}
