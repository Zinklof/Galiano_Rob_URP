using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHud : MonoBehaviour
{
    [SerializeField] private GameObject controls;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (controls.activeInHierarchy)
            {
                controls.SetActive(false);
            }
            else
            {
                controls.SetActive(true);
            }
        }
    }
}
