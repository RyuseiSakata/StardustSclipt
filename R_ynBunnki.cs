using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R_ynBunnki : MonoBehaviour
{
  public Text textA;
  public Text textB;
  public GameObject button;
  public int sn;
  public GameObject gameObject;
  public string[] signboard;
    // Start is called before the first frame update
    void Start()
    {
      button.SetActive(false);
      gameObject = GameObject.Find("Event");
    }

    // Update is called once per frame
    public void SelectTextA()
    {
      button.SetActive(false);
      Message.Instance.setEndFlag(false);
      //Debug.Log(getBFlag());

      this.gameObject.SendMessage("Onyes");
        Debug.Log("A押された!");

    }
    public void SelectTextB()
    {
      button.SetActive(false);
        Debug.Log("B押された!");

        this.gameObject.SendMessage("Onno");

    }
}
