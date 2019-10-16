using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronicCardData : MonoBehaviour
{
    public int balance;
}

/// <summary>
/// 電子マネー処理サーバーとの通信用パケット
/// </summary>
public class ElectronicPacket
{
    // -1 = 取引失敗 / 1 = 取引成功 / 0 = 送信
    public int transaction;
    // 引去額
    public int withdrawal;
    // 残高
    public int balance;
}