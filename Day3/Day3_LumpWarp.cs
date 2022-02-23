using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day3_LumpWarp : MonoBehaviour
{
    [SerializeField] Lump lump;
    private int count_warp;

    // Start is called before the first frame update
    void Start()
    {
        count_warp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(lump.Light_ON == false && count_warp == 0)
        {
            Debug.Log("Warp");
            count_warp++;
        }
    }
}
