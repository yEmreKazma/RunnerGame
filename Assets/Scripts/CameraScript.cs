using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    private Vector3 offSet;
    void Start()
    {
        offSet = this.transform.position;
    }

    
    void LateUpdate()
    {
        FollowTheTarget();
    }

    private void FollowTheTarget()
    {
        this.transform.position = offSet + target.position;
    }
}
