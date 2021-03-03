using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonesInitializer : MonoBehaviour
{
    [SerializeField] private GameObject ZonesObject;
    [SerializeField] private Zone[] Zones;
    void Start()
    {
        ZonesObject.SetActive(false);
    }

}
