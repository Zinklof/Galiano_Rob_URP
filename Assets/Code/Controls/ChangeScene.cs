using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private int sceneID;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            SceneManager.LoadScene(sceneID);
        }
    }
}
