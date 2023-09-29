using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Android;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] RobMesh robMesh = null;
    [SerializeField] GameObject ballObject = null;
    [SerializeField] Material ballMaterial = null;
    [SerializeField] Material ballEmissive = null;

    private void BlueBall()
    {
        ballMaterial.SetColor("_Color", Color.blue);
        ballEmissive.SetColor("_Emission", Color.blue);
    }
    private void GreenBall()
    {
        ballMaterial.SetColor("_Color", Color.green);
        ballEmissive.SetColor("_Emission", Color.green);
    }
    private void RedBall()
    {
        ballMaterial.SetColor("_Color", Color.red);
        ballEmissive.SetColor("_Emission", Color.red);
    }

    private void Update()
    {
        bool temp = robMesh.DoesBallExist();

        if (temp)
        {
            return;
        }
        else if (!temp)
        {
            int tempint = Random.Range(0, 3);

            ballObject.SetActive(true);

            switch (tempint)
            {
                case 0:
                    RedBall(); break;
                case 1:
                    GreenBall(); break;
                case 2:
                    BlueBall(); break;
                case 3:
                    Debug.Log("Random Number was 3"); break;
            }

            ballObject.transform.position = new Vector3(-2, 0.5f, -10);
        }
    }
}
