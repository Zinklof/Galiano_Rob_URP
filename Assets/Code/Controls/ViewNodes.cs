using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class ViewNodes : MonoBehaviour
{
    [Header("Nodes")]
    [SerializeField] private List<GameObject> nodes = new List<GameObject>();
    [Header("References")]
    [SerializeField] private int references = 0;
    [Header("Debug View Variables")]
    [SerializeField] private bool viewEnabled = false;
    
    private void ControlsManager()
    {
        if (Input.GetKeyUp(KeyCode.N)) 
        {
            if (viewEnabled == false)
                viewEnabled = true ;
            else
                viewEnabled = false ;
        }
    }

    private void DrawNodes()
    {
        foreach (GameObject node in nodes)
        {
           if (viewEnabled)
            {
                node.SetActive(true);
            }
           else
            {
                node.SetActive(false);
            }
        }
    }

    void Update()
    {
        ControlsManager();

        DrawNodes();
    }
}
