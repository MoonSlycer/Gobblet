using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positions : MonoBehaviour
{
    public List<Vector2> piecePositions = new List<Vector2>();
    public GameObject[] pieces;

    void Update()
    {
        UpdatePiecePositions();
    }
    void UpdatePiecePositions()
    {
        piecePositions.Clear();
        pieces = GameObject.FindGameObjectsWithTag("Piece");
        for (int i = 0; i < pieces.Length; i++)
        {
            piecePositions.Add(pieces[i].GetComponent<Piece>().totalPos);
        }
    }

}
