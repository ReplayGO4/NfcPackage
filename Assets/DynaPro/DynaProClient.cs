using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Beamable;
using Beamable.Common;
using Beamable.Common.Shop;
using Beamable.Server.Clients;
using DynaPro;
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
        //
        // if (!decimal.TryParse(amountInput.text, out var amount))
        // {
        //     Log("Invalid amount :( Enter a decimal number of cents.");
        //     return;
        // }
        //
        //
        var ctx = BeamContext.Default;
        await ctx.OnReady;
        
        // Log("requesting charge for " + amount);
        // var charge = ctx.DynaProService().RequestCharge(amount, 5);
        // charge.OnProgress += (progress) =>
        // {
        //     Log("MSG: " + progress.status);
        // };
        // try
        // {
        //     var res = await charge.ResultPromise;
        //     Log("received cryptogram: " + res.transactionResult);
        // }
        // catch (DynaProService.DynaProChargeTimeoutException)
        // {
        //     Log("Maybe you walked away?");
        // }

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
        }

        Log("sending payment...");

        // for (var i = 0; i < 10; i++)
        // {
        //     ctx.Microservices().GoPlay().FinishNfcPayment(new MagtekFinishPaymentRequest
        //     {
        //         customerTransactionId = beginResponse.customerTransactionId,
        //         transactionAmount = beginResponse.amount,
        //         transactionCryptogram = charge.Result.transactionResult,
        //         nfcPaymentId = beginResponse.nfcPaymentId
        //     });
        // }

        finishResponse = await ctx.Microservices().GoPlay().FinishNfcPayment(new MagtekFinishPaymentRequest
        {
            customerTransactionId = beginResponse.customerTransactionId,
            transactionAmount = beginResponse.amount,
            transactionCryptogram = charge.Result.transactionResult,
            nfcPaymentId = beginResponse.nfcPaymentId
        });

        Log("Success: " + finishResponse.success);
        Log("Message: " + finishResponse.status);
        // Log("sending to C#MS");
        // var req = new MagtekPaymentRequest
        // {
        //     amount = amount.ToString(CultureInfo.InvariantCulture),
        //     transactionToken = res.transactionResult
        // };
        // var netRes = await ctx.Microservices().GoPlay().StartDynaProPurchase(req);
        // Log("Got back payment status: " + netRes);
    }

    void Log(string log)
    {
        logText.text += log + "\n";
    }
}
