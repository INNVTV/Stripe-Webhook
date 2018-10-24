[![Build Status](https://dev.azure.com/Github-Samples/Stripe-Webhook/_apis/build/status/INNVTV.Stripe-Webhook)](https://dev.azure.com/Github-Samples/Stripe-Webhook/_build/latest?definitionId=2)

# Stripe Webhook
A template for developing Stripe webhooks to take actions on your customer data from Stripe events, log them in table storage and send a message queue for further action via background process.

### Exceptions
Exceptions are logged in a table storage account for historical debugging.

## Stripe Webhook Documentation
https://stripe.com/docs/webhooks

### Testing your webhooks
Use the webhooks tester provided by Strpe to test the flow of your webhooks logic across all event types:

![Testing WEbhooks](https://github.com/INNVTV/Stripe-Webhook/blob/master/_docs/imgs/stripe-test-webhook.png)

### Stripe.net Package Documentation
Uses Stripe.net official C# SDK: https://github.com/stripe/stripe-dotnet



