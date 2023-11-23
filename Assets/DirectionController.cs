using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionController : MonoBehaviour
{
    public GameObject WEDir;
    public GameObject NWDir;
    public GameObject SDir;
    public GameObject NDir;

    private Dictionary<Direction, GameObject> directionObjects = new Dictionary<Direction, GameObject>();
    private void Start()
    {
        directionObjects[Direction.SouthWest] = WEDir;
        directionObjects[Direction.NorthWest] = NWDir;
        directionObjects[Direction.South] = SDir;
        directionObjects[Direction.North] = NDir;
    }

    public void SwitchDir(Direction newDirection)
    {
        WEDir.SetActive(newDirection == Direction.SouthWest);
        NWDir.SetActive(newDirection == Direction.NorthWest);
        SDir.SetActive(newDirection == Direction.South);
        NDir.SetActive(newDirection == Direction.North);
    }
    public Animator GetDirectionAnimator(Direction newDirection)
    {      
        if (directionObjects.TryGetValue(newDirection, out GameObject directionObject))
        {
            if (directionObject != null)
            {
                Animator directionAnimator = directionObject.GetComponent<Animator>();
                return directionAnimator;
            }
        }

        return null;
    }
    // public void SetAnimation(Direction newDirection, string animationString, bool HasAction)
    // {
    //     GameObject directionObject = GetDirectionObject(newDirection);

    //     if (directionObject != null)
    //     {
    //         Animator directionAnimator = directionObject.GetComponent<Animator>();
    //         directionAnimator.SetBool(animationString, HasAction);
    //     }
    // }
    // public void SetAnimationInt(Direction newDirection, string animationString, int amount)
    // {
    //     GameObject directionObject = GetDirectionObject(newDirection);

    //     if (directionObject != null)
    //     {
    //         Animator directionAnimator = directionObject.GetComponent<Animator>();
    //         directionAnimator.SetInteger(animationString, amount);
    //     }
    // }
    // public void SetTriggerAnimation(Direction newDirection, string animationString)
    // {
    //     GameObject directionObject = GetDirectionObject(newDirection);

    //     if (directionObject != null)
    //     {
    //         Animator directionAnimator = directionObject.GetComponent<Animator>();
    //         directionAnimator.SetTrigger(animationString);
    //     }
    // }

    private GameObject GetDirectionObject(Direction newDirection)
    {
        if (directionObjects.TryGetValue(newDirection, out GameObject directionObject))
        {
            return directionObject;
        }

        return null;
    }
}

public enum Direction
{
    None,
    NorthWest, //西北
    North, //北
    South, //南
    SouthWest //西南
}
