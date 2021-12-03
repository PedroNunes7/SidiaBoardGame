using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoveToClick : MonoBehaviour
{
    NavMeshAgent agent;
    public PlayerInfos player;
    public GameObject turnPass;
    public MapManagement map;
    public CollectableCounter counter;
    public GameObject battleButton;
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
                    if (hit.transform.gameObject.GetComponent<Tile>().moveable && player.moves >= 1)
                    {
                        agent.destination = hit.transform.position;
                        player.moves--;
                        hit.transform.gameObject.GetComponent<Tile>().collectable = false;
                        AssignPosition(hit.transform.gameObject.GetComponent<Tile>());
                    }
                    if (hit.transform.gameObject.GetComponent<Tile>().attackable)
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
        if (player.moves <= 0)
        {
            turnPass.SetActive(true);
        }
    }

    private void AssignPosition(Tile tileComponent)
    {
        map.player1Tile[0] = tileComponent.row;
        map.player1Tile[1] = tileComponent.col;

        foreach (GameObject tile in map.tiles)
        {
            Tile iterableComponent = tile.GetComponent<Tile>();
            iterableComponent.moveable = false;
            iterableComponent.attackable = false;

            int[,] attackable = map.AttackableTiles(1);
            for (int i = 0; i < 8; i++)
            {
                if (attackable[i, 0] == iterableComponent.row && attackable[i, 1] == iterableComponent.col && map.player2Tile[0] == iterableComponent.row && map.player2Tile[1] == iterableComponent.col)
                    iterableComponent.attackable = true;
            }

            int[,] moveable = map.MoveableTiles(1);
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
}
