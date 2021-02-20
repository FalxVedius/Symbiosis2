using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThroughWalls : MonoBehaviour
{
    private Shader oldShader;
    public Shader transparentShader;
    public GameObject characterObject;
    public Camera cam;

    private GameObject selection = null;

    void Update()
    {
        Vector3 characterPos = characterObject.transform.position;

        if (selection != null && selection.GetComponent<MeshRenderer>().material != null)
        {
            selection.GetComponent<MeshRenderer>().material.shader = oldShader;
            selection = null;
        }

        Ray ray = new Ray(cam.transform.position, characterPos - cam.transform.position);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            selection = hit.transform.gameObject;
            if (selection.GetComponent<Material>() != null)
            {
                oldShader = selection.GetComponent<MeshRenderer>().material.shader;

                selection.gameObject.GetComponent<MeshRenderer>().material.shader = transparentShader;
            }
        }

    }
}
