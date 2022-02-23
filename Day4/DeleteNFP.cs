using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteNFP : MonoBehaviour
{
    public bool DestroyNFP;
    public Day4_NFP day4_NFP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (day4_NFP.destroyNFP)
        {
            Destroy(this.gameObject);
        }
    }
}
