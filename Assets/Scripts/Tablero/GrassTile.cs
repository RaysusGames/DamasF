using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTile : Tile
{
    [SerializeField] protected Sprite colorA;
    [SerializeField] protected Sprite colorB;

    public override void Tileinit (int x , int y)
    {
        bool isOffset;
        if ((x+y)%2 == 1)
        {
            isOffset = true;
        }
        else
        {
            isOffset = false;
        }

        if (isOffset)
        {
            sRend.sprite = colorB;

        }
        else
        {
            sRend.sprite = colorA;
        }
    }
}
