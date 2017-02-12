using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINDecision]
public class CheckObjectiveDistance : RAINDecision
{
    private int _lastRunning = 0;

    private float distance = 0.0f;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);

        distance = ai.WorkingMemory.GetItem<float>("maxDistance");

        _lastRunning = 0;
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {

        Vector3 playerPosition = ai.WorkingMemory.GetItem<Vector3>("playerLastPosition");

        //Debug.Log(Vector3.Distance(playerPosition, ai.Body.transform.position));

        if (Vector3.Distance(playerPosition, ai.Body.transform.position) <= distance)
            return ActionResult.SUCCESS;
        else
            return ActionResult.FAILURE;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}