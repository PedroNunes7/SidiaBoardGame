using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    
    public bool moveable = false;
    public bool attackable = false;
    public bool collectable = false;
    public int row;
    public int col;

    private void Update()
    {
        ColoringTiles();
    }
    public void ColoringTiles()
    {
        if (moveable)
            GetComponent<Renderer>().material.color = Color.yellow;
        if (attackable)
            GetComponent<Renderer>().material.color = Color.red;
        if(!moveable && !attackable)
            GetComponent<Renderer>().material.color = Color.white;
    }
}
