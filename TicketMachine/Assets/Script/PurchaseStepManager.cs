using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseStepManager : MonoBehaviour
{
    [SerializeField]
    GameObject page1 = default(GameObject);

    [SerializeField]
    GameObject page2 = default(GameObject);
    [SerializeField]
    GameObject charg = default(GameObject);
    [SerializeField]
    GameObject amountLabel = default(GameObject);
    [SerializeField]
    GameObject amount = default(GameObject);
    [SerializeField]
    ChangeManager change = default(ChangeManager);


    //[SerializeField]
    //GameObject page3 = default(GameObject);
    //[SerializeField]
    //Text tenText = null;
    //[SerializeField]
    //Text fiftyText = null;
    //[SerializeField]
    //Text hundredText = null;
    //[SerializeField]
    //Text fiveHundredsText = null;
    //[SerializeField]
    //Text thousandText = null;
    //[SerializeField]
    //Text fiveThousandText = null;
    //[SerializeField]
    //Text tenThousandText = null;
    //[SerializeField]
    //MoneyManager moneyManager = default(MoneyManager);

    int[] moneyType = new int[7] { 10, 50, 100, 500, 1000, 5000, 10000 };

    int totleInput = 0;

    bool changeFlag = false;
    string str = "";

    // Start is called before the first frame update
    void Start()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        //page3.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (page2.activeInHierarchy)
        {
            // 投入額を表示
            amount.GetComponentInChildren<Text>().text = totleInput.ToString();
            str = charg.GetComponentInChildren<Text>().text;
            if (str != "")
            {

                // 投入額が料金を超えたらおつりを出す
                if (totleInput >= int.Parse(str))
                {
                    change.DisplayChange(int.Parse(str), totleInput);
                    TurnPage3();
                }
            }
        }

    }

    /// <summary>
    /// 現金支払いボタンを押したときのイベント
    /// </summary>
    public void PushCashButton()
    {
        page1.SetActive(false);
        page2.SetActive(true);
        charg.GetComponentInChildren<Text>().text = "130";
        amountLabel.GetComponentInChildren<Text>().text = "投入額";

    }

    /// <summary>
    /// 電子マネー支払いボタンを押したときのイベント
    /// </summary>
    public void PushElectroButton()
    {
        page1.SetActive(false);
        page2.SetActive(true);
        charg.GetComponentInChildren<Text>().text = "124";
        amountLabel.GetComponentInChildren<Text>().text = "支払額";
    }
    private void TurnPage3()
    {
        page2.SetActive(false);
        //page3.SetActive(true);
    }

    private void SetPage3()
    {

    }

    /// <summary>
    /// 戻るボタンを押したときのイベント
    /// </summary>
    public void PushBackButton()
    {
        if (page1.activeInHierarchy == true)
        {

        }
        else if (page2.activeInHierarchy == true)
        {
            page1.SetActive(true);
            page2.SetActive(false);
        }
    }

    /// <summary>
    /// 金種によってトータル額を加算していく
    /// </summary>
    /// <param name="_throw"></param>
    public void CalculateInput(int _throw)
    {
        totleInput += _throw;
    }

    public bool ChangeFlag { get { return changeFlag; } }
    public int TotleInput { get { return totleInput; } }
    public int Charge { get{ return int.Parse(str); } }

    public void Clear()
    {
        changeFlag = false;
        totleInput = 0;
        page1.SetActive(true);
        page2.SetActive(false);
    }
}
