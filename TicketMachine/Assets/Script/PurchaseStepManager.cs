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
    GameObject charg = default(GameObject);     // 引去額
    [SerializeField]
    GameObject amountLabel = default(GameObject);   // 投入額のラベル
    [SerializeField]
    GameObject amount = default(GameObject);    // 投入額
    [SerializeField]
    ChangeManager change = default(ChangeManager);

    

    [SerializeField]
    GameObject page3 = default(GameObject);
    [SerializeField]
    Text tenText = null;
    [SerializeField]
    Text fiftyText = null;
    [SerializeField]
    Text hundredText = null;
    [SerializeField]
    Text fiveHundredsText = null;
    [SerializeField]
    Text thousandText = null;
    [SerializeField]
    Text fiveThousandText = null;
    [SerializeField]
    Text tenThousandText = null;
    [SerializeField]
    Text electronicBalance = null;

    [SerializeField]
    MoneyManager moneyManager = default(MoneyManager);
    [SerializeField]
    TicketMachineManager ticketManager = default(TicketMachineManager);


    int[] moneyType = new int[7] { 10, 50, 100, 500, 1000, 5000, 10000 };

    int totleInput = 0;

    bool changeFlag = false;
    // 引去額の文字列
    string str = "";

    // Start is called before the first frame update
    void Start()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);
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

    /// <summary>
    /// 購入後のページに移動する
    /// </summary>
    public void TurnPage3()
    {
        page2.SetActive(false);
        page3.SetActive(true);
        SetPage3();
        ticketManager.CreateTicket();
    }

    /// <summary>
    /// 購入後のページをセットする
    /// </summary>
    private void SetPage3()
    {
        List<int> nums = new List<int>();
        for (int i = 0; i < 7; i++)
        {
            nums.Add(moneyManager.GetNowUseMoney(moneyType[i]));
        }
        tenText.text = "x" + nums[0].ToString();
        fiftyText.text = "x" + nums[1].ToString();
        hundredText.text = "x" + nums[2].ToString();
        fiveHundredsText.text = "x" + nums[3].ToString();
        thousandText.text = "x" + nums[4].ToString();
        fiveThousandText.text = "x" + nums[5].ToString();
        tenThousandText.text = "x" + nums[6].ToString();

        electronicBalance.text = moneyManager.ElectronicBalance.ToString();
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
            totleInput = 0;
            moneyManager.AllReset(); ticketManager.AllReset();
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
