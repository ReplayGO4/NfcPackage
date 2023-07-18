using System;
using Beamable;
using Beamable.Common;
using Beamable.Common.Shop;
using Beamable.Go4.Nfc;
using Beamable.Go4.Nfc.Common;
using Beamable.Server.Clients;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DynaProClient : MonoBehaviour
{

    [Header("Content")] 
    public ListingRef listingRef;
    
    [Header("Scene references")]
    public TMP_InputField amountInput;
    public Button chargeButton;
    public TextMeshProUGUI logText;

    [Header("Runtime data")] 
    public MagtekBeginPaymentResponse beginResponse;

    public MagtekFinishPaymentResponse finishResponse;
    void Start()
    {
        chargeButton.onClick.AddListener(ChargeFlow);
    }
    
    async void ChargeFlow()
    {
        logText.text = "";
        Log("Starting...");
        
        var ctx = BeamContext.Default;
        await ctx.OnReady;
        

        Log("logging payment request for " + listingRef.Id);
        beginResponse = await ctx.Microservices().GoPlay().BeginNfcPayment(new MagtekBeginPaymentRequest
        {
            listingRef = listingRef
        });

        Log("requesting charge for " + beginResponse.amount);
        if (!decimal.TryParse(beginResponse.amount, out var amount))
        {
            Log("invalid amount.");
            throw new Exception("invalid amount");
        }
        var charge = ctx.DynaProService().RequestCharge(amount, 15);
        charge.OnProgress += (progress) =>
        {
            Log("MSG: " + progress.status);
        };
        try
        {
            var res = await charge.ResultPromise;
            Log("received cryptogram: " + res.transactionResult);
        }
        catch (DynaProService.DynaProChargeTimeoutException)
        {
            Log("Maybe you walked away?");
            return;
        }

        Log("sending payment...");

        finishResponse = await ctx.Microservices().GoPlay().FinishNfcPayment(new MagtekFinishPaymentRequest
        {
            customerTransactionId = beginResponse.customerTransactionId,
            transactionAmount = beginResponse.amount,
            transactionCryptogram = charge.Result.transactionResult,
            nfcPaymentId = beginResponse.nfcPaymentId
        });

        Log("Success: " + finishResponse.success);
        Log("Message: " + finishResponse.status);
    }

    void Log(string log)
    {
        logText.text += log + "\n";
    }
}
