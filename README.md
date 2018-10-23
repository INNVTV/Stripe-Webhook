[![Build Status](https://dev.azure.com/Github-Samples/Stripe-Webhook/_apis/build/status/INNVTV.Stripe-Webhook)](https://dev.azure.com/Github-Samples/Stripe-Webhook/_build/latest?definitionId=2)

# Stripe Webhook
A template for developing Stripe webhooks to take actions on your customer data from Stripe events.

## Microservices Ready
Messages are sent to a queue for background processes to pick up and take actions on.

## Azure Focused
Azure storage queues are built into the template. Can be replaced with a messaging system of your choice.

## Exceptions
Exceptions are logged in a table storage account for historical debugging.

## Stripe Webhook Documentation
https://stripe.com/docs/webhooks

### Testing your webhooks
![Testing WEbhooks](https://github.com/INNVTV/Stripe-Webhook/blob/master/_docs/imgs/stripe-test-webhook.png)

## Stripe.net Package Documentation
Uses Stripe.net official C# SDK: https://github.com/stripe/stripe-dotnet



