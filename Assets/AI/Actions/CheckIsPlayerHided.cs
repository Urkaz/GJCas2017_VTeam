using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINDecision]
public class CheckIsPlayerHided : RAINDecision
{
    
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        Vector3 posToHide = ai.WorkingMemory.GetItem<Vector3>("hidePos");
        if (Vector3.Distance(ai.Body.transform.position, posToHide) < 0.5)
            return ActionResult.SUCCESS;
        else
            return ActionResult.FAILURE;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}