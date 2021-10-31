using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Wallet : MonoBehaviour
{
    [SerializeField] private bool devmode;
    [SerializeField] public float currentBalance;
    [SerializeField] private TextMeshProUGUI BalanceUI, BalanceShadowUI;
    [SerializeField] private bool sendAlerts;
    private void Awake()
    {
        ResetMoney(true);
    }

    public void RemoveMoney(float amount)
    {
        currentBalance -= amount;
        RefreshWallet();
    }
    public void AddMoney(float amount)
    {
        currentBalance += amount;
        RefreshWallet();
    }
    public void SetMoney(float value)
    {
        currentBalance = value;
        RefreshWallet();
    }
    private void RefreshWallet()
    {
        if (currentBalance >= 0)
        {
            PlayerPrefs.SetFloat("Wallet", currentBalance);
            BalanceUI.text = PlayerPrefs.GetFloat("Wallet").ToString();
            BalanceShadowUI.text = PlayerPrefs.GetFloat("Wallet").ToString();
            if (sendAlerts)
            {
                print($"Wallet updated, balance: {currentBalance}");
            }
        }
        else
        {
            currentBalance = 0;
        }
    }
    [ContextMenu("ResetMoney")]
    private void ResetMoneyInspector()
    {
        ResetMoney(false);
    }
    private void ResetMoney(bool awake)
    {
        PlayerPrefs.DeleteKey("Wallet");
        currentBalance = 0;
        if (!awake)
        {
            Debug.LogWarning("Deleted all money in wallet");
        }
    }
    private void Update()
    {
        if (devmode)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (Input.GetKeyDown(KeyCode.E) || Input.GetKey(KeyCode.E))
                {
                    AddMoney(100);
                }
            }
        }
    }
}