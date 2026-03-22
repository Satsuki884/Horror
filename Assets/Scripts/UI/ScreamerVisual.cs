using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreamerVisual : MonoBehaviour
{
    [SerializeField] private List<Sprite> _screamerSprites;
    [SerializeField] private Image _spriteRenderer;
    private void Start()
    {
        _spriteRenderer.sprite = _screamerSprites[UnityEngine.Random.Range(0, _screamerSprites.Count)];
    }

}