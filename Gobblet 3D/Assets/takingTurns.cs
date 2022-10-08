using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class takingTurns : MonoBehaviour
{
    public static string turn = "White";
    public Positions positionsScript;
    public TextMeshProUGUI textmesh;

    void Update()
    {
        if (positionsScript.CheckForWin() == "Null")
        {
            textmesh.text = turn + "'s turn.";
        }
        if (positionsScript.CheckForWin() == "Black")
        {
            textmesh.text = "Black wins!";
        }
        if (positionsScript.CheckForWin() == "White")
        {
            textmesh.text = "White wins!";
        }
    }
}
