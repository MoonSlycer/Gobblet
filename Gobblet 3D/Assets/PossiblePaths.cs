using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossiblePaths : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public Camera mainCamera;
    public static GameObject movablePiece;
    public string name;

    public void Start()
    {
        name = this.gameObject.name;
    }
    public void Update()
    {
        if (movablePiece != null)
        {
            if (movablePiece.GetComponent<PieceMovement>().isSelected == true)
            {
                Pathselector();
            }
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
    public void Pathselector()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject == this.gameObject)
            {
                GetComponent<MeshRenderer>().enabled = true;
                if(Input.GetMouseButtonDown(0))
                {
                    movablePiece.GetComponent<Piece>().xPos = int.Parse(name.Substring(0, 1));
                    movablePiece.GetComponent<Piece>().yPos = int.Parse(name.Substring(2, 1));
                    movablePiece.GetComponent<PieceMovement>().isSelected = false;
                    GetComponent<MeshRenderer>().enabled = false;
                }
            }
            if (hit.transform.gameObject != this.gameObject)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }


}
