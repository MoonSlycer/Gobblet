using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public int xPos = 1;
    public int yPos = 1;
    public int size = 4;
    public int piece;
    public Vector2 totalPos;
    public string team = "White";
    public bool isExterior = true;
    public Positions positionsScript;

    public Material blackMat;
    public Material whiteMat;
    void Start()
    {
        SetTeam();
        isExterior = true;
    }
    void Update()
    {
        SetXPos();
        SetYPos();
        SetSize();
        GobbleCheck();
        totalPos = new Vector2(xPos, yPos);
    }
    void SetXPos()
    {
        if (xPos == 1) { this.gameObject.transform.position = new Vector3(-0.465f, this.gameObject.transform.position.y, this.gameObject.transform.position.z); }
        if (xPos == 2) { this.gameObject.transform.position = new Vector3(-0.141f, this.gameObject.transform.position.y, this.gameObject.transform.position.z); }
        if (xPos == 3) { this.gameObject.transform.position = new Vector3(0.179f, this.gameObject.transform.position.y, this.gameObject.transform.position.z); }
        if (xPos == 4) { this.gameObject.transform.position = new Vector3(0.503f, this.gameObject.transform.position.y, this.gameObject.transform.position.z); }
    }
    void SetYPos()
    {
        if (yPos == 1) { this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0.48f); }
        if (yPos == 2) { this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0.168f); }
        if (yPos == 3) { this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -0.144f); }
        if (yPos == 4) { this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -0.456f); }
    }
    void SetTeam()
    {
        if (team == "White") { this.gameObject.GetComponent<MeshRenderer>().material = whiteMat; }
        if (team == "Black") { this.gameObject.GetComponent<MeshRenderer>().material = blackMat; }
    }
    void SetSize()
    {
        if (size == 4) { this.gameObject.transform.localScale = new Vector3(.2f, .1f, .2f); this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 0.125f, this.gameObject.transform.position.z); }
        if (size == 3) { this.gameObject.transform.localScale = new Vector3(.15f, .075f, .15f); this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 0.1f, this.gameObject.transform.position.z); }
        if (size == 2) { this.gameObject.transform.localScale = new Vector3(.1f, .05f, .1f); this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 0.075f, this.gameObject.transform.position.z); }
        if (size == 1) { this.gameObject.transform.localScale = new Vector3(.05f, .025f, .05f); this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 0.05f, this.gameObject.transform.position.z); }
    }
    void GobbleCheck()
    {
        piece = 0;
        foreach (Vector2 i in positionsScript.piecePositions)
        {
            if (positionsScript.pieces[piece] != this.gameObject)
            {
                if (xPos == i.x && yPos == i.y)
                {
                    if (positionsScript.pieces[piece].GetComponent<Piece>().size > size)
                    {
                        isExterior = false;
                        return;
                    }
                    if (positionsScript.pieces[piece].GetComponent<Piece>().size < size)
                    {
                        isExterior = true;
                        return;
                    }
                }
            }
            piece++;
        }
        isExterior = true;
        return;
    }
}