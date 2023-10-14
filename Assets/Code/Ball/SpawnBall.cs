using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Android;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] RobMesh robMesh = null;
    [SerializeField] GameObject redBall = null;
    [SerializeField] GameObject greenBall = null;
    [SerializeField] GameObject blueBall = null;
    [SerializeField] Vector3 spawnPosition = Vector3.zero;
    [SerializeField] Material ballMaterial = null;
    [SerializeField] Material ballEmissive = null;

    private void BlueBall()
    {
        GameObject ball = Instantiate(blueBall);
        ball.transform.position = spawnPosition;
        robMesh.SetBallColor(3);

    }
    private void GreenBall()
    {
        GameObject ball = Instantiate(greenBall);
        ball.transform.position = spawnPosition;
        robMesh.SetBallColor(2);
    }
    private void RedBall()
    {
        GameObject ball = Instantiate(redBall);
        ball.transform.position = spawnPosition;
        robMesh.SetBallColor(1);
    }

    private void RunCode()
    {
        bool temp = robMesh.DoesBallExist();

        if (temp)
        {
            return;
        }
        else if (!temp)
        {
            int tempint = Random.Range(0, 3);

            switch (tempint)
            {
                case 0:
                    RedBall(); Debug.Log("red"); break;
                case 1:
                    GreenBall(); Debug.Log("green"); break;
                case 2:
                    BlueBall(); Debug.Log("blue"); break;
                case 3:
                    Debug.Log("Random Number was 3"); break;
            }
            robMesh.SetBallExistsTrue();
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        { 
            RunCode();
        }
    }
}
