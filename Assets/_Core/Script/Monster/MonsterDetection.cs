using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterDetection : MonoBehaviour
{
    #region Settings
    #region AI
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    #endregion
    #region Set Point
    public Vector3 walkPoint;
    bool walkPointSet;
    float walkPointRange = 30f;
    #endregion
    #region Delay
    private List<Action> AIAction;
    private int indexFunctionBehavior = 0;
    private float delayBeforeSwitch = 30;
    private float counter = 0;
    #endregion
    #endregion

    #region Meths
    #region Target Search
    void SetPoint()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    void SearchWalkPoint()
    {
        // Calculate random point in range
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;

    }
    void PlayerFollow()
    {
        walkPointSet = false;
        agent.SetDestination(player.position);
    }
    #endregion
    #region Comportement
    void SwitchComportement()
    {
        counter += Time.deltaTime;
        if (counter > delayBeforeSwitch)
        {
            indexFunctionBehavior++;
            counter = 0;
        }
        if (indexFunctionBehavior >= AIAction.Count)
        {
            indexFunctionBehavior = 0;
        }
        AIAction[indexFunctionBehavior]();
    }
    void AIActions()
    {
        AIAction = new List<Action>();
        AIAction.Add(SetPoint);
        AIAction.Add(PlayerFollow);
    }
    #endregion
    #endregion
    #region Meths Unity
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        AIActions();
    }
    private void Update()
    {
        SwitchComportement();
    }
    #endregion
}