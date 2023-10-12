using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class RobMesh : MonoBehaviour
{
    [Header("Agent")]
    [SerializeField] NavMeshAgent agent;
    [Header("Nodes")]
    [SerializeField] Transform homeNode;
    [SerializeField] Transform ballNode;
    [SerializeField] Transform rbNode;
    [SerializeField] Transform gbNode;
    [SerializeField] Transform bbNode;
    [Header("animators")]
    [SerializeField] Animator redAnimator;
    [SerializeField] Animator blueAnimator;
    [SerializeField] Animator greenAnimator;
    [Header("code references")]
    [SerializeField] AttachToRob attachToRob;
    [Header("Debug Variables")]
    [SerializeField] private int objective = 0;
    [SerializeField] private bool hasBall = false;
    [SerializeField] private bool ballExists = true;
    [SerializeField] private int ballColor = 1;
    [SerializeField] private LineRenderer line;
    [SerializeField] private Transform objectiveNode = null;
    [SerializeField] private bool drawPaths = false;

    public void GetPath()
    {
        line.SetPosition(0, transform.position);

        agent.SetDestination(objectiveNode.position);

        if (drawPaths)
        DrawPath(agent.path);
    }

    public void DrawPath(NavMeshPath path)
    {
        line.SetVertexCount(path.corners.Length);

        for (int i = 1; i < path.corners.Length; i++)
        {
            line.SetPosition(i, path.corners[i]);
        }
    }

    private void DetermineObjective()
    {
        if (hasBall == false && ballExists == true)
        {
            objective = 1;
        }
        else if (hasBall == true)
        {
            if (ballColor == 1)
            {
                objective = 2;
            }
            else if (ballColor == 2)
            {
                objective = 3;
            }
            else if (ballColor == 3)
            {
                objective = 4;
            }
        }
        else if (!hasBall && !ballExists)
        {
            objective = 5;
        } 
    }

    public void SetBallExistsTrue()
    {
        ballExists = true;
    }

    public void SetHasBall(bool state)
    {
        hasBall = state;
    }

    public void SetBallColor(int num)
    {
        ballColor = num;
    }

    public bool DoesBallExist()
    {
        if (!ballExists)
            return false;
        else 
            return true;
    }

    private void SetObjective()
    {
        switch (objective)
        {
            case 0:
                break;
            case 1:
                objectiveNode = ballNode; break;
            case 2:
                objectiveNode = rbNode; break;
            case 3:
                objectiveNode = gbNode; break;
            case 4:
                objectiveNode = bbNode; break;
            case 5:
                objectiveNode = homeNode; break;
        }
    }

    private void CheckForBox()
    {
        if (Vector3.Distance(rbNode.position, transform.position) < 0.5f)
        {
            redAnimator.SetTrigger("open");
            hasBall = false;
            ballExists = false;
            attachToRob.SetAttached(false);
        }
        if (Vector3.Distance(gbNode.position, transform.position) < 0.5f)
        {
            greenAnimator.SetTrigger("open");
            hasBall = false;
            ballExists = false; 
            attachToRob.SetAttached(false);
        }
        if (Vector3.Distance(bbNode.position, transform.position) < 0.5f)
        {
            blueAnimator.SetTrigger("open");
            hasBall = false;
            ballExists = false;
            attachToRob.SetAttached(false);
        }
    }

    private void CheckForBall()
    {
        if (Vector3.Distance(ballNode.position, transform.position) < .5f)
        {
            hasBall = true;
            attachToRob.SetAttached(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBall)
        {
            CheckForBox();
        }

        if (!hasBall && ballExists)
        {
            CheckForBall();
        }

        DetermineObjective();
        SetObjective();
        
        GetPath();

        if (Input.GetKeyUp(KeyCode.P))
        {
            if (drawPaths)
            {
                drawPaths = false;
            }
            else
            {
                drawPaths = true;
            }
        }
    }
}
