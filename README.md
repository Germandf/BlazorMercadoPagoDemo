# Steps for paying in Sandbox mode (testing):

- Load the `MercadoPagoTest` environment variable in your computer using your Mercado Pago Developer account.
- Do not use [Testing Accounts](https://www.mercadopago.com.ar/developers/panel/test-users). If you do so, the api will return a `One of the user is a testing account` error, even when it's in Sandbox mode.
- Grab one of the [Testing Cards](https://www.mercadopago.com.ar/developers/es/docs/checkout-pro/additional-content/test-cards)

### Pay with a logged in user's account's money

- Select `Log In with my Mercado Pago's account`
- Log In with a real account
- Pay

### Pay with a debit/credit card

- Select `New Card`
- Fill the empty spaces with a testing card and use APRO as owner's name
- Fill the dni with a random number (for example 12345678)
- Fill the email with a random valid email (for example your personal email)
- Pay

### Pay with cash

- Select `Pay with cash`
- Select any of the available providers
- Fill the email with a random valid email (for example your personal email)
- Pay