using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Toy : MonoBehaviour
{
  public string[] signboard = {"ここに今にも壊れそうなsikakuがある。",
                     "これを調べますか？"};
  /*public string[] signboard1={"ここに今にも壊れそうな円がある。",
                     "これを調べますか？"};*/

    public float speakLine = 0.9f;

    public GameObject button;
    public Transform plPos;
  //  public Transform pos;
    //public GameObject gameObject;
    [SerializeField]
  	private Message2 messageScript;
    private bool TriggerSB2;
    private idou pos;

    // Start is called before the first frame update
    void Start()
    {
        plPos = GameObject.Find("Player").GetComponent<Transform>();



    }



    // Update is called once per frame
    void Update()
    {

      if(TriggerSB2&&Input.GetKeyDown(KeyCode.Z)&&Message2.Instance.coment)
        {
        Debug.Log("bbb");

      Message2.Instance.StartCoroutine("WriteRoutine",signboard);
      //ここの下にifの条件分を書いて分岐する

    }
}

private IEnumerator DelayCoroutine(float seconds, UnityAction callback)
{
   yield return new WaitForSeconds(seconds);
   callback?.Invoke();
}


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            TriggerSB2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("iii");
            TriggerSB2 = false;
        }
    }
}
