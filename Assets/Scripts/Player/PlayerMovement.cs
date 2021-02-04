using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask WhatCanBeClick;
    public GraphicRaycaster graphicRaycaster;
    private NavMeshAgent navigationMesh;
    private List<RaycastResult> results;
    private PointerEventData ped;


    void Start()
    {
        results = new List<RaycastResult>();
        navigationMesh = GetComponent<NavMeshAgent>();
        ped = new PointerEventData(null);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            ped.position = Input.mousePosition;
            graphicRaycaster.Raycast(ped, results);
            if (results.Count == 0)
            {
                Ray destnationRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(destnationRay, out hitInfo, 500, WhatCanBeClick))
                {
                    navigationMesh.SetDestination(hitInfo.point);
                }
            }
            results.Clear();
        }

    }
}
