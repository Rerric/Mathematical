using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public int x;
    public int y;

    private Item _item;

    public Item item
    {
        get => _item;

        set
        {
            if (_item == value) return;

            _item = value;
            icon.SpriteRenderer.sprite = _item.sprite; 
        }
    }

    public GameObject icon;

    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
