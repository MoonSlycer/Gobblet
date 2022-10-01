using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossiblePaths : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public Camera mainCamera;
    public static GameObject movablePiece;

    public void Update()
    {
        if (movablePiece != null)
        {
            if (movablePiece.GetComponent<PieceMovement>().isSelected == true)
            {
                Pathselector();
            }
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
                }
                if (hit.transform.gameObject != this.gameObject)
                {
                    GetComponent<MeshRenderer>().enabled = false;
                }
            }
    }

}
