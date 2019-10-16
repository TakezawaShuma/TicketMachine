using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketMachineManager : MonoBehaviour
{
    [SerializeField]
    SlotController coinSlot = default(SlotController);
    [SerializeField]
    SlotController electoroSlot = default(SlotController);
    [SerializeField]
    MoneyManager moneyManager = default(MoneyManager);
    [SerializeField]
    PurchaseStepManager purchaseStep = default(PurchaseStepManager);
    [SerializeField]
    Canvas canvas = null;

    bool cashPaymentFlag = false;
    bool electroPaymentFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 現金が投入口に入れられた
            if (coinSlot.HitFlag && cashPaymentFlag)
            {
                int haveCash = moneyManager.NowHaveCash;
                moneyManager.DestroyMoney(false);
                purchaseStep.CalculateInput(haveCash);
            }
            // 電子マネーで支払われた
            else if (electoroSlot.HitFlag && electroPaymentFlag)
            {
                moneyManager.DestroyMoney(true);
                // ここで処理サーバーにカード残高と引去額を送る
                // SendElectronicData();
                
                // カードの残高を取得
                int balance = moneyManager.NowHaveCard;
                if (balance >= purchaseStep.Charge)
                {
                    moneyManager.ElectronicBalance = moneyManager.SubBfromA(balance, purchaseStep.Charge);
                    purchaseStep.TurnPage3();
                }
                else
                {

                }
            }
            // 投入口以外でクリックされた
            else
            {
                moneyManager.DestroyMoney(true);
            }

        }
    }

    public void CreateTicket()
    {
        var coin = (GameObject)Resources.Load("TicketPrefab");
        var tmp = Instantiate(coin);
        tmp.transform.SetParent(canvas.transform, false);
        tmp.transform.position = new Vector3(840+150, 525);
    }
    /// <summary>
    /// 現金払いを選択したら
    /// </summary>
    public void FlagPaymentCash()
    {
        cashPaymentFlag = true;
    }
    /// <summary>
    /// 電子マネー払いを選択したら
    /// </summary>
    public void FlagPaymentElectro()
    {
        electroPaymentFlag = true;
    }

    /// <summary>
    /// 取引開始とカード内のお金の量を送る
    /// </summary>
    public void SendElectronicData()
    {

    }

    /// <summary>
    /// 取引の成否等の受信
    /// </summary>
    public void RecvPaymentResult()
    {
        // 此処で情報を受け取る
        ElectronicPacket packet;
    }

    /// <summary>
    /// リセット
    /// </summary>
    public void AllReset()
    {
        cashPaymentFlag = false;
        electroPaymentFlag = false;
    }
}
