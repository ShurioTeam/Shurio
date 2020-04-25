using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardScript : MonoBehaviour
{
    public string stageName;
    public string clearCondition;
    private int flagNum = 0;
    private int clearFlagNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject clearBoard = GameObject.Find("ClearCondition");
        InputField input = clearBoard.GetComponentInChildren<InputField>();
        input.text = "[ステージ]:" + stageName + "\n";
        input.text += "[フラグの数]:" + (clearFlagNum - flagNum) + "\n";
        input.text += "[クリアー条件]:" + clearCondition + "\n";
        Debug.Log("ClearCondition:" + input.text);
    }

    void SetClearFlagCount(int clearFlagNum) {
        this.clearFlagNum = clearFlagNum;
    }
    public void SetFlagNum(int flagNum) {
        this.flagNum = flagNum;
    }
}
