using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Sprite colorA;
    [SerializeField] private Sprite colorB;
    [SerializeField] private SpriteRenderer sRend;

    [SerializeField] private GameObject higtlight;
    public void Tileinit(bool isOfset)
    {
        if (isOfset)
        {
            sRend.sprite = colorB;
        }
        else
        {
            sRend.sprite = colorA;
        }
    }
    private void OnMouseDown()
    {
        UnitManager.insatance.setSelectTile(gameObject);
    }
    private void OnMouseEnter()
    {
        higtlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        higtlight.SetActive(false);
    }
}
