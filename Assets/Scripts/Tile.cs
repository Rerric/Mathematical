using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Tile : MonoBehaviour
{
    public int x;
    public int y;

    public SpriteRenderer icon;

    private Item _item;

    public Item Item
    {
        get => _item;

        set
        {
            if (_item == value) return;

            _item = value;
            icon.sprite = _item.sprite; 
        }
    }

    public Button button;

    private void Start() => button.onClick.AddListener(call: () => Board.Instance.Select(tile: this));
} 
