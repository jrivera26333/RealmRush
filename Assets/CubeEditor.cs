using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode][SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [Range(1f, 20f)]
    [SerializeField] float gridSize = 0;

    TextMesh textMesh;

    private void Start()
    {

    }

    private void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize; //We get a decimal and then round to nearest int to snap
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize; //We get a decimal and then round to nearest int to snap
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = snapPos.x / gridSize + "," + snapPos.z / gridSize; //Since we have a rounded value we are getting the grid cord
        textMesh.text = labelText;
        gameObject.name = labelText;


    }
}
