using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positions : MonoBehaviour
{
    public List<Vector2> piecePositions = new List<Vector2>();
    public GameObject[] pieces;
    public int wPieces;
    public int bPieces;

    void Update()
    {
        UpdatePiecePositions();
        CheckForWin();
        if(CheckForWin() == "White")
        {
            Debug.Log("White wins!");
        }
        if(CheckForWin() == "Black")
        {
            Debug.Log("Black wins!");
        }
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
    public string CheckForWin()
    {
        int piece = 0;
        wPieces = 0;
        bPieces = 0;
        List<Vector2> winningWXpos1 = new List<Vector2>();
        List<Vector2> winningWXpos2 = new List<Vector2>();
        List<Vector2> winningWXpos3 = new List<Vector2>();
        List<Vector2> winningWXpos4 = new List<Vector2>();
        List<Vector2> winningWYpos1 = new List<Vector2>();
        List<Vector2> winningWYpos2 = new List<Vector2>();
        List<Vector2> winningWYpos3 = new List<Vector2>();
        List<Vector2> winningWYpos4 = new List<Vector2>();

        List<Vector2> winningBXpos1 = new List<Vector2>();
        List<Vector2> winningBXpos2 = new List<Vector2>();
        List<Vector2> winningBXpos3 = new List<Vector2>();
        List<Vector2> winningBXpos4 = new List<Vector2>();
        List<Vector2> winningBYpos1 = new List<Vector2>();
        List<Vector2> winningBYpos2 = new List<Vector2>();
        List<Vector2> winningBYpos3 = new List<Vector2>();
        List<Vector2> winningBYpos4 = new List<Vector2>();
        foreach (Vector2 i in piecePositions)
        {
            if (pieces[piece].GetComponent<Piece>().team == "White" && pieces[piece].GetComponent<Piece>().isExterior == true)
            {
                if(i.x == 1)
                {
                    winningWXpos1.Add(i);
                }
                if (i.x == 2)
                {
                    winningWXpos2.Add(i);
                }
                if (i.x == 3)
                {
                    winningWXpos3.Add(i);
                }
                if (i.x == 4)
                {
                    winningWXpos4.Add(i);
                }
                if (i.y == 1)
                {
                    winningWYpos1.Add(i);
                }
                if (i.y == 2)
                {
                    winningWYpos2.Add(i);
                }
                if (i.y == 3)
                {
                    winningWYpos3.Add(i);
                }
                if (i.y == 4)
                {
                    winningWYpos4.Add(i);
                }
            }
            if (pieces[piece].GetComponent<Piece>().team == "Black" && pieces[piece].GetComponent<Piece>().isExterior == true)
            {
                if (i.x == 1)
                {
                    winningBXpos1.Add(i);
                }
                if (i.x == 2)
                {
                    winningBXpos2.Add(i);
                }
                if (i.x == 3)
                {
                    winningBXpos3.Add(i);
                }
                if (i.x == 4)
                {
                    winningBXpos4.Add(i);
                }
                if (i.y == 1)
                {
                    winningBYpos1.Add(i);
                }
                if (i.y == 2)
                {
                    winningBYpos2.Add(i);
                }
                if (i.y == 3)
                {
                    winningBYpos3.Add(i);
                }
                if (i.y == 4)
                {
                    winningBYpos4.Add(i);
                }
            }
            piece++;
        }
        if(winningWXpos1.Count == 4 || winningWXpos2.Count == 4 || winningWXpos3.Count == 4 || winningWXpos4.Count == 4 || winningWYpos1.Count == 4 || winningWYpos2.Count == 4 || winningWYpos3.Count == 4 || winningWYpos4.Count == 4)
        {
            return "White";
        }
        if (winningBXpos1.Count == 4 || winningBXpos2.Count == 4 || winningBXpos3.Count == 4 || winningBXpos4.Count == 4 || winningBYpos1.Count == 4 || winningBYpos2.Count == 4 || winningBYpos3.Count == 4 || winningBYpos4.Count == 4)
        {
            return "Black";
        }
        return "Null";
    }

}
