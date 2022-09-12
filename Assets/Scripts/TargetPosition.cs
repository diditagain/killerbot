using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetPosition : MonoBehaviour
{
    [SerializeField] Image aimUI;
    void Update()
    {
        aimUI.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }
}
