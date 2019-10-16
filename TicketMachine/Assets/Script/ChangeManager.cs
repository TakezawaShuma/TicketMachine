using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeManager : MonoBehaviour
{
    [SerializeField]
    Text tenYenText = null;
    [SerializeField]
    Text fiftyYenText = null;
    [SerializeField]
    Text hundredYenText = null;
    [SerializeField]
    Text fiveHundredYenText = null;
    [SerializeField]
    Text thousandYenText = null;
    [SerializeField]
    Text fiveThousandYenText = null;
    [SerializeField]
    Text tenThousandYenText = null;

    // 十円のおつり
    int tenYen = 0;
    // 五十円のおつり
    int fiftyYen = 0;
    // 百円のおつり
    int hundredYen = 0;
    // 五百円のおつり
    int fiveHundredYen = 0;
    // 千円のおつり
    int thousandYen = 0;
    // 五千円のおつり
    int fiveThousandYen = 0;
    // 1万円のおつり
    int tenThousandYen = 0;
    
    int change = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// おつりを計算する
    /// </summary>
    /// <param name="_charge">購入料金</param>
    /// <param name="_amount">投入額</param>
    /// <returns>おつり</returns>
    public int CashCalculate(int _charge, int _amount)
    {
        int ret = 0;
        ret = _amount - _charge;

        return ret;
    }

    /// <summary>
    /// おつりから金種と枚数を計算
    /// </summary>
    /// <param name="_changeAmount"></param>
    public void MakeChange(int _changeAmount)
    {
        int tmp = _changeAmount;
        // 一万円分を算出
        tenThousandYen = tmp / 10000;
        tmp -= 10000 * tenThousandYen;

        fiveThousandYen = tmp / 5000;
        tmp -= 5000 * fiveThousandYen;

        thousandYen = tmp / 1000;
        tmp -= 1000 * thousandYen;

        fiveHundredYen = tmp / 500;
        tmp -= 500 * fiveHundredYen;

        hundredYen = tmp / 100;
        tmp -= 100 * hundredYen;

        fiftyYen = tmp / 50;
        tmp -= 50 * fiftyYen;

        tenYen = tmp / 10;
        tmp -= 10 * tenYen;
    }

    /// <summary>
    /// おつりの金種の枚数を表示
    /// </summary>
    public void DisplayChange(int _charge, int _amount)
    {
        change = CashCalculate(_charge, _amount);
        gameObject.SetActive(true);
        MakeChange(change);
        Debug.Log("おつり表示");
        tenYenText.text = "x" + tenYen.ToString();
        fiftyYenText.text = "x" + fiftyYen.ToString();
        hundredYenText.text = "x" + hundredYen.ToString();
        fiveHundredYenText.text = "x" + fiveHundredYen.ToString();
        thousandYenText.text = "x" + thousandYen.ToString();
        fiveThousandYenText.text = "x" + fiveThousandYen.ToString();
        tenThousandYenText.text = "x" + tenThousandYen.ToString();
    }
    

}
