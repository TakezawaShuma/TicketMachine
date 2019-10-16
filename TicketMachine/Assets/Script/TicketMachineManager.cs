using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                moneyManager.DestroyMoney(false);
            }
            // 投入口以外でクリックされた
            else
            {
                moneyManager.DestroyMoney(true);
            }

        }
    }

    private void CreateTicket()
    {

    }

    public void FlagPaymentCash()
    {
        cashPaymentFlag = true;
    }
    public void FlagPaymentElectro()
    {
        electroPaymentFlag = true;
    }
}
