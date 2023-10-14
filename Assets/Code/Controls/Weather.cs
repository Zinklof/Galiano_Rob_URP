using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    [SerializeField] GameObject rainObject;
    [SerializeField] GameObject snowObject;
    [SerializeField] int weatherID;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            weatherID++;
        }
        if (weatherID >= 3)
        {
            weatherID = 0;
        }
    }

    private void FixedUpdate()
    {
        if (weatherID == 0)
        {
            rainObject.SetActive(false);
            snowObject.SetActive(false);
        }
        else if (weatherID == 1)
        {
            snowObject.SetActive(false);
            rainObject.SetActive(true);
        }
        else if (weatherID == 2)
        {
            rainObject.SetActive(false);
            snowObject.SetActive(true);
        }
    }
}
