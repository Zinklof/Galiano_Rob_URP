using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class ToggleGraphics : MonoBehaviour
{
    [SerializeField] private bool graphics = true;
    [SerializeField] private GameObject graphicsObject = null;
    [SerializeField] private GameObject reflectionProbe = null;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            if (!graphics)
            {
                graphics = true;
            }
            else
            {
                graphics = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (graphics)
        {
            graphicsObject.SetActive(true);
            reflectionProbe.SetActive(true);
        }
        if (!graphics)
        {
            graphicsObject.SetActive(false);
            reflectionProbe.SetActive(false);
        }
    }
}
