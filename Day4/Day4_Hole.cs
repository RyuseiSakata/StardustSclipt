using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day4_Hole : MonoBehaviour
{
    public static bool TriggerFP;
    public bool destroyHole;

    // Start is called before the first frame update
    void Start()
    {
        destroyHole = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerFP && Input.GetKeyDown(KeyCode.Z)&&Message2.Instance.coment)
        {
            Debug.Log("Our leader is GOD.");
            destroyHole = true;

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("GOOD.");
            TriggerFP = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("BAD.");
            TriggerFP = false;
        }
    }
}
