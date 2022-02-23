using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSighnBoard : MonoBehaviour
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
    private TestMessage messageScript;
    private bool TriggerSB2;
    private idou pos;

    // Start is called before the first frame update
    void Start()
    {
        plPos = GameObject.Find("Player").GetComponent<Transform>();
        //StartCoroutine("Test");
    }




    // Update is called once per frame
    void Update()
    {
      if(TriggerSB2&&Input.GetKeyDown(KeyCode.Z))
        {
        Debug.Log("bbb");

      //  Message2.Instance.message2(signboard);
        TestMessage.Instance.StartCoroutine("WriteRoutine",signboard);

    }
}

/*  private IEnumerator Test()
  {
    Debug.Log("動けー１");
        if(TriggerSB2&&Input.GetKeyDown(KeyCode.Z))
        {
          Debug.Log("動けー２");
          TestMessage.Instance.WriteRoutine(signboard);
        }
  yield return new WaitForFixedUpdate();
        StartCoroutine("Test");
  }*/

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
