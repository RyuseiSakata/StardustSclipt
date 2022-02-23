using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day4_NFP : MonoBehaviour
{
    public static bool TriggerNFP;
    public bool destroyNFP;

    // Start is called before the first frame update
    void Start()
    {
        destroyNFP = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerNFP && Input.GetKeyDown(KeyCode.Z)&&Message2.Instance.coment)
        {
            Debug.Log("You are King.");
            destroyNFP = true;

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("GoodGame.");
            TriggerNFP = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("GomiGame.");
            TriggerNFP = false;
        }
    }
}
