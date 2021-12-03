using UnityEngine;

[CreateAssetMenu(fileName = "Map Management", menuName = "VariableReferences/MapManagement")]
public class MapManagement : ScriptableObject
{
    public GameObject[,] tiles;
    public int[] player1Tile = new int [2];
    public int[] player2Tile = new int [2];
    public GameObject[] collectables;

    public void SpawnCollectables()
    {
        foreach (GameObject tile in tiles)
        {
            Tile tileComponent = tile.GetComponent<Tile>();
            if (!PlayerInTile(tileComponent) && !tileComponent.collectable)
            {
                tileComponent.collectable = true;
                Instantiate(collectables[Random.Range(0, collectables.Length)], tile.transform);
            }
        }
    }

    private bool PlayerInTile(Tile tileComponent)
    {
        return (tileComponent.row == player1Tile[0] && tileComponent.col == player1Tile[1]) || (tileComponent.row == player2Tile[0] && tileComponent.col == player2Tile[1]);
    }
    public int[,] MoveableTiles(int player)
    {
        int[,] moveable = new int[4,2];
        if (player == 1)
        {
            moveable[0, 0] = player1Tile[0] + 1;
            moveable[0, 1] = player1Tile[1];
            moveable[1, 0] = player1Tile[0] - 1;
            moveable[1, 1] = player1Tile[1];
            moveable[2, 0] = player1Tile[0];
            moveable[2, 1] = player1Tile[1] + 1;
            moveable[3, 0] = player1Tile[0];
            moveable[3, 1] = player1Tile[1] - 1;
        }
        else
        {
            moveable[0, 0] = player2Tile[0] + 1;
            moveable[0, 1] = player2Tile[1];
            moveable[1, 0] = player2Tile[0] - 1;
            moveable[1, 1] = player2Tile[1];
            moveable[2, 0] = player2Tile[0];
            moveable[2, 1] = player2Tile[1] + 1;
            moveable[3, 0] = player2Tile[0];
            moveable[3, 1] = player2Tile[1] - 1;
        }
        
        return moveable;
    }

    public int [,] AttackableTiles(int player)
    {
        int[,] attackable = new int[8, 2];
        if (player == 1)
        {
            attackable[0, 0] = player1Tile[0] + 1;
            attackable[0, 1] = player1Tile[1];
            attackable[1, 0] = player1Tile[0] - 1;
            attackable[1, 1] = player1Tile[1];
            attackable[2, 0] = player1Tile[0];
            attackable[2, 1] = player1Tile[1] + 1;
            attackable[3, 0] = player1Tile[0];
            attackable[3, 1] = player1Tile[1] - 1;
            attackable[4, 0] = player1Tile[0] + 1;
            attackable[4, 1] = player1Tile[1] + 1;
            attackable[5, 0] = player1Tile[0] + 1;
            attackable[5, 1] = player1Tile[1] - 1;
            attackable[6, 0] = player1Tile[0] - 1;
            attackable[6, 1] = player1Tile[1] + 1;
            attackable[7, 0] = player1Tile[0] - 1;
            attackable[7, 1] = player1Tile[1] - 1;
        }
        else
        {
            attackable[0, 0] = player2Tile[0] + 1;
            attackable[0, 1] = player2Tile[1];
            attackable[1, 0] = player2Tile[0] - 1;
            attackable[1, 1] = player2Tile[1];
            attackable[2, 0] = player2Tile[0];
            attackable[2, 1] = player2Tile[1] + 1;
            attackable[3, 0] = player2Tile[0];
            attackable[3, 1] = player2Tile[1] - 1;
            attackable[4, 0] = player2Tile[0] + 1;
            attackable[4, 1] = player2Tile[1] + 1;
            attackable[5, 0] = player2Tile[0] + 1;
            attackable[5, 1] = player2Tile[1] - 1;
            attackable[6, 0] = player2Tile[0] - 1;
            attackable[6, 1] = player2Tile[1] + 1;
            attackable[7, 0] = player2Tile[0] - 1;
            attackable[7, 1] = player2Tile[1] - 1;
        }
        return attackable;
    }
}
