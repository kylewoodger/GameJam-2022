using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCircle : MonoBehaviour
{
    public Material terrainMaterial;
    public Vector3 mousePos;

    private RaycastHit _Hit;

    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.gamePhase == GamePhase.PICK_DICE_LOCATION) {
            if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out _Hit)) 
            {
                mousePos = new Vector3(_Hit.point.x, _Hit.point.y, _Hit.point.z);
            }
            terrainMaterial.SetVector("_Center", new Vector4(mousePos.x, mousePos.y, mousePos.z, 0f));
        } else {
             terrainMaterial.SetVector("_Center", new Vector4(1000, 1000, 1000, 1f));
        }
    }
}
