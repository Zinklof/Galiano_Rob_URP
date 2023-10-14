using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToRob : MonoBehaviour
{
    [SerializeField] GameObject robObject = null;
    [SerializeField] private bool attached = false;

    private void Awake()
    {
        robObject = GameObject.FindGameObjectWithTag("rob");
    }

    public bool SetAttached(bool state)
    {
        if (state == true)
        {
            attached = true;
        }
        else if (state  == false)
        {
            attached = false;
        }

        if (attached == state)
        {
            return true;
        }
        else 
        { 
            return false;
        }
    }

    public void Kill()
    {
        GameObject.Destroy(this.gameObject);
    }
    
    void Update()
    {
        if (attached)
        {
            transform.position = new Vector3(robObject.transform.position.x, robObject.transform.position.y + 1f, robObject.transform.position.z);
        }
    }
}
