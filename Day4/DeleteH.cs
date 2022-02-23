using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteH : MonoBehaviour
{
    public bool DestroyH;
    public Day4_Hole day4_Hole;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (day4_Hole.destroyHole)
        {
            Destroy(this.gameObject);
        }
    }
}
