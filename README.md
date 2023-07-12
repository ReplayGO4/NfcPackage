# MagtekUnityExample
an example Unity project that integrates Beamable and the Magtek DynaProX

## Pre-reqs

This sample project requires some configuration before it is usable.

1. You must build and have a `Cli.exe` program available. Get this from [the CLI repo](https://github.com/ReplayGO4/MagtekCli/tree/main)
2. You must be on a windows machine.
3. You must have a DynaProX available, and plugged in via _USB_
4. You must have a Beamable Organization available for testing

## Setup

1. Open the Unity project, and use the Beamable Toolbox to sign into a Beamable Organization.
2. You must either publish the content in the repo, or configure a new Listing, Sku, and Currency content that will be used in the demo. If you configure your own, you'll need to update the Listing in the demo scene.
3. The `Assets/DynaPro/Resources/DynaProSettings.asset` file has a 'Command Path' setting that you should configure to point to your local `Cli.exe` build.
4. Run the StorageObject
5. Run the Microservice
6. Run the Sample Scene
7. Push the "Start Charge" button.

## Technical Overview

See [the Unity example script](https://github.com/ReplayGO4/MagtekUnityExample/blob/main/Assets/DynaPro/DynaProClient.cs) to follow the basic flow from the client's perspective.


When the player clicks the "Start Charge" button, the payment flow begins. 
1. The `BeginNfcPayment` method is called on the C#MS. This records a transaction in the Database and creates a usable transaction ID. It also fetches the purchase price from the Beamable listing. If the configured listing has any unsupported properties, then the call to the C#MS will fail.
2. The client gets the response, which includes the purchase amount.
3. The client uses `Cli.exe` to issue a charge command to the attached DynaProX card reader.
4. The client listens for events from the `Cli.exe` charge command, and logs the messaging to the user.
5. The user taps their card.
6. The client receives the payment token, and calls `FinishNfcPayment` on the C#MS.
7. The `FinishNfcPayment` function calls MagTek's payment gateway (MPPGv4) to process the payment.
8. Then it fulfills the configured offer from the purchased listing.

 
