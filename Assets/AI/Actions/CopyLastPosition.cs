using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class CopyLastPosition : RAINAction
{
    private Vector3 _lastPosition;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
        _lastPosition = new Vector3();
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        GameObject playerPos = ai.WorkingMemory.GetItem<GameObject>("formPlayer");

        _lastPosition.x = playerPos.transform.position.x;
        _lastPosition.y = playerPos.transform.position.y;
        _lastPosition.z = playerPos.transform.position.z;

        Vector3 playerDir = playerPos.transform.forward;

        ai.WorkingMemory.SetItem<Vector3>("playerLastPosition", _lastPosition);

        ai.WorkingMemory.SetItem<Vector3>("playerLookAt", playerDir);

        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}