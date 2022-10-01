using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    public Material selectedMat;
    public Piece pieceScript;
    Ray ray;
    RaycastHit hit;
    public Camera mainCamera;

    public bool isSelected;
    void Update()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.transform.gameObject == this.gameObject)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    isSelected = true;
                    PossiblePaths.movablePiece = this.gameObject;
                }
                GetComponent<MeshRenderer>().material = selectedMat;
            }
            if (hit.transform.gameObject != this.gameObject)
            {
                if (isSelected == false)
                {
                    Unselected();
                }
            }
        }
        else
        {
            if (isSelected == false)
            {
                Unselected();
            }
            if(Input.GetMouseButtonDown(0))
            {
                isSelected = false;
            }
        }
    }
    public void Unselected()
    {
        if (pieceScript.team == "White")
        {
            GetComponent<MeshRenderer>().material = pieceScript.whiteMat;
        }
        if (pieceScript.team == "Black")
        {
            GetComponent<MeshRenderer>().material = pieceScript.blackMat;
        }
    }
}
