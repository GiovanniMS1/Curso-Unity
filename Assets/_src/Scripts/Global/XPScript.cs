using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class XPScript : MonoBehaviour
{
    public int XPArmor;

    private Transform player;

    bool isReady;

    private void Start()
    {
        isReady = false;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        isReady = true;
    }

    private void Update()
    {
        
    }
}
