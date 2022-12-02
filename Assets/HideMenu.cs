using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HideMenu : MonoBehaviour
{
    public static event Action<int> ExternalRefreshInventory;

    [SerializeField] public Transform offscreenPoint;
    [SerializeField] public bool startHidden;
    public bool isHidden = false;
    Vector3 oldPosition;

    public void Start()
    {
        if (startHidden)
        {
            ToggleHide();
        }
    }

    public void ToggleHide(int callerID = 0)
    {
        oldPosition = transform.position;
        transform.position = offscreenPoint.transform.position;
        offscreenPoint.transform.position = oldPosition;
        isHidden = !isHidden;
        ExternalRefreshInventory?.Invoke(callerID);
    }
}
