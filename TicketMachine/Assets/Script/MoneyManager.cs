using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class MoneyManager : MonoBehaviour
{
    Canvas canvas;
    GameObject haveNow = null;


    [SerializeField]
    int maxTenYen = 0;          // 十円の最大数
    [SerializeField]
    int maxFiftyYen = 0;        // 五十円の最大数
    [SerializeField]
    int maxHundredYen = 0;      // 百円の最大数
    [SerializeField]
    int maxFiveHundredYen = 0;  // 五百円の最大数
    [SerializeField]
    int maxThousandYen = 0;     // 千円の最大数
    [SerializeField]
    int maxFiveThousandYen = 0; // 五千円の最大数
    [SerializeField]
    int maxTenThousandYen = 0;  // 1万円の最大数
    [SerializeField]
    int electronicMoney1 = 0;
    [SerializeField]
    int electronicMoney2 = 0;


    int nowTenYen = 0;          // 十円の残り数
    int nowFiftyYen = 0;        // 五十円の残り数
    int nowHundredYen = 0;      // 百円の残り数
    int nowFiveHundredYen = 0;  // 五百円の残り数
    int nowThousandYen = 0;     // 千円の残り数
   int nowFiveThousandYen = 0;  // 五千円の残り数
    int nowTenThousandYen = 0;  // 1万円の残り数
 


    // Start is called before the first frame update
    void Start()
    {
        // 自分を親を設定する
        canvas = transform.gameObject.GetComponent<Canvas>();
        nowTenYen = maxTenYen;
        nowFiftyYen = maxFiftyYen;
        nowHundredYen = maxHundredYen;
        nowFiveHundredYen = maxFiveHundredYen;
        nowThousandYen = maxThousandYen;
        nowFiveThousandYen = maxFiveThousandYen;
        nowTenThousandYen = maxTenThousandYen;

    }

    // Update is called once per frame
    void Update()
    {
    }


    // お金をクリックしたらお金(クローン)を作る
    public void CreateTenCoin()
    {
        if (nowTenYen > 0)
        {
            var coin = (GameObject)Resources.Load("CoinImagePrefab");
            var tmp = Instantiate(coin);
            tmp.transform.SetParent(canvas.transform, false);
            tmp.GetComponent<Image>().rectTransform.position = Input.mousePosition;
            tmp.GetComponent<Image>().sprite = Resources.Load<Sprite>("Ten");
            tmp.GetComponentInChildren<Text>().text = "10";
            tmp.gameObject.AddComponent<MouseMove>();
            tmp.name = "money";
            haveNow = tmp;
            nowTenYen--;
        }
    }
    public void CreateFiftyCoin()
    {
        if (nowFiftyYen > 0)
        {
            var coin = (GameObject)Resources.Load("CoinImagePrefab");
            var tmp = Instantiate(coin);
            tmp.transform.SetParent(canvas.transform, false);
            tmp.GetComponent<Image>().rectTransform.position = Input.mousePosition;
            tmp.GetComponent<Image>().sprite = Resources.Load<Sprite>("Fifty");
            tmp.GetComponentInChildren<Text>().text = "50";
            tmp.gameObject.AddComponent<MouseMove>();
            tmp.name = "money";
            haveNow = tmp;
            nowFiftyYen--;
        }
    }
    public void CreateHundredCoin()
    {
        if (nowHundredYen > 0)
        {
            var coin = (GameObject)Resources.Load("CoinImagePrefab");
            var tmp = Instantiate(coin);
            tmp.transform.SetParent(canvas.transform, false);
            tmp.GetComponent<Image>().rectTransform.position = Input.mousePosition;
            tmp.GetComponent<Image>().sprite = Resources.Load<Sprite>("OneHundred");
            tmp.GetComponentInChildren<Text>().text = "100";
            tmp.gameObject.AddComponent<MouseMove>();
            tmp.name = "money";
            haveNow = tmp;
            nowHundredYen--;
        }
    }
    public void CreateFiveHundredsCoin()
    {
        if (nowFiveHundredYen > 0)
        {
            var coin = (GameObject)Resources.Load("CoinImagePrefab");
            var tmp = Instantiate(coin);
            tmp.transform.SetParent(canvas.transform, false);
            tmp.GetComponent<Image>().rectTransform.position = Input.mousePosition;
            tmp.GetComponent<Image>().sprite = Resources.Load<Sprite>("FiveHundred");
            tmp.GetComponentInChildren<Text>().text = "500";
            tmp.gameObject.AddComponent<MouseMove>();
            tmp.name = "money";
            haveNow = tmp;
            nowFiveHundredYen--;
        }
    }
    public void CreateThousandBill()
    {
        if (nowThousandYen > 0)
        {
            var coin = (GameObject)Resources.Load("BillImagePrefab");
            var tmp = Instantiate(coin);
            tmp.transform.SetParent(canvas.transform, false);
            tmp.GetComponent<Image>().rectTransform.position = Input.mousePosition;
            tmp.GetComponent<Image>().sprite = Resources.Load<Sprite>("Thousand");
            tmp.GetComponentInChildren<Text>().text = "1000";
            tmp.gameObject.AddComponent<MouseMove>();
            tmp.name = "money";
            haveNow = tmp;
            nowThousandYen--;
        }
    }
    public void CreateFiveThousandBill()
    {
        if (nowFiveThousandYen >0)
        {
            var coin = (GameObject)Resources.Load("BillImagePrefab");
            var tmp = Instantiate(coin);
            tmp.transform.SetParent(canvas.transform, false);
            tmp.GetComponent<Image>().rectTransform.position = Input.mousePosition;
            tmp.GetComponent<Image>().sprite = Resources.Load<Sprite>("FiveThousand");
            tmp.GetComponentInChildren<Text>().text = "5000";
            tmp.gameObject.AddComponent<MouseMove>();
            tmp.name = "money";
            haveNow = tmp;
            nowFiveThousandYen--;
        }
    }
    public void CreateTenThousandBill()
    {
        if (nowTenThousandYen > 0)
        {
            var coin = (GameObject)Resources.Load("BillImagePrefab");
            var tmp = Instantiate(coin);
            tmp.transform.SetParent(canvas.transform, false);
            tmp.GetComponent<Image>().rectTransform.position = Input.mousePosition;
            tmp.GetComponent<Image>().sprite = Resources.Load<Sprite>("TenThousand");
            tmp.GetComponentInChildren<Text>().text = "10000";
            tmp.gameObject.AddComponent<MouseMove>();
            tmp.name = "money";
            haveNow = tmp;
            nowTenThousandYen--;
        }
    }



    /// <summary>
    /// 今使った金種の量を取得する
    /// </summary>
    /// <param name="_yen"></param>
    /// <returns></returns>
    public int GetNowUseMoney(int _yen)
    {
        int ret = 0;
        switch (_yen)
        {
            case 10:
                ret = maxTenYen - nowTenYen;
                break;
            case 50:
                ret = maxFiftyYen - nowFiftyYen;
                break;
            case 100:
                ret = maxHundredYen - nowHundredYen;
                break;
            case 500:
                ret = maxFiveHundredYen - nowFiveHundredYen;
                break;
            case 1000:
                ret = maxThousandYen - nowThousandYen;
                break;
            case 5000:
                ret = maxFiveThousandYen - nowFiveThousandYen;
                break;
            case 10000:
                ret = maxTenThousandYen - nowTenThousandYen;
                break;
            default:
                ret = -1;
                break;
        }
        return ret;
    }

    /// <summary>
    /// お金を戻したか時の処理
    /// </summary>
    /// <param name="_yen"></param>
    private void MinusUseMoney(int _yen)
    {
        switch (_yen)
        {
            case 10:
                nowTenYen++;
                break;
            case 50:
                nowFiftyYen++;
                break;
            case 100:
                nowHundredYen++;
                break;
            case 500:
                nowFiveHundredYen++;
                break;
            case 1000:
                nowThousandYen++;
                break;
            case 5000:
                nowFiveThousandYen++;
                break;
            case 10000:
                nowTenThousandYen++;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 今持っているお金を消す
    /// </summary>
    /// <param name="_minus">true = 使ってない</param>
    public void DestroyMoney(bool _minus)
    {
        if(haveNow!=null)
        {
            Debug.Log(haveNow.name);
            int i = int.Parse(haveNow.GetComponentInChildren<Text>().text);
            if (_minus) { MinusUseMoney(i); }
            Destroy(haveNow);
        }
    }

    /// <summary>
    /// 今持っているお金の種類を取得する
    /// </summary>
    /// <returns></returns>
    public int NowHaveCash { get {  return int.Parse(haveNow.GetComponentInChildren<Text>().text);} }

}
