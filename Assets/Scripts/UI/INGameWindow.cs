using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class INGameWindow : Window
{
    [SerializeField] private TMP_Text _PiecesText;

    private int _PiecesCount = 0;

    public void StartGame()
    {
        Open();
    }

    public void OnPieceCollected()
    {
        _PiecesCount++;
        _PiecesText.text = _PiecesCount.ToString();
    }
}
