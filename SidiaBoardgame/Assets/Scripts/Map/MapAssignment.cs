using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapAssignment : MonoBehaviour
{
    public MapManagement map;
    public PlayerInfos player1;
    void Start()
    {
        map.player1Tile[0] = 1;
        map.player1Tile[1] = 1;
        map.player2Tile[0] = 14;
        map.player2Tile[1] = 14;

        GameObject[] tilesArray = GameObject.FindGameObjectsWithTag("Tile");
        int rowAmount = GameObject.FindGameObjectsWithTag("Row").Length;
        map.tiles = new GameObject[rowAmount, tilesArray.Length / rowAmount];

        foreach (GameObject tile in tilesArray)
        {
            string parentName = tile.transform.parent.name;
            string parentNameDigits = "";
            string nameDigits = "";
            int rowNumber;
            int colNumber;
            Tile tileComponent = tile.GetComponent<Tile>();
            
            foreach (char c in parentName)
            {
                if (Char.IsDigit(c))
                {
                    parentNameDigits += c;
                }
            }

            foreach (char c in tile.name)
            {
                if (Char.IsDigit(c))
                {
                    nameDigits += c;
                }
            }


            rowNumber = parentNameDigits.Length > 0 ? int.Parse(parentNameDigits) : 0;
            colNumber = nameDigits.Length > 0 ? int.Parse(nameDigits) : 0;
            map.tiles[rowNumber, colNumber] = tile;
            tileComponent.row = rowNumber;
            tileComponent.col = colNumber;

            int[,] attackable = map.AttackableTiles(player1);
            for (int i = 0; i < 8; i++)
            {
                if (attackable[i, 0] == rowNumber && attackable[i, 1] == colNumber && map.player2Tile[0] == rowNumber && map.player2Tile[1] == colNumber)
                    tileComponent.attackable = true;
            }

            int[,] moveable = map.MoveableTiles(player1);
            if (!tileComponent.attackable)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (moveable[i, 0] == rowNumber && moveable[i, 1] == colNumber)
                        tileComponent.moveable = true;
                }
            }
            
        }
        map.SpawnCollectables();

        player1.moves = 3;
        player1.turn = true;
    }
}
