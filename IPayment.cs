using System;

namespace PaymentSystemAdapterExample
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }
    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Обработка платежа на сумму {amount} руб. через PayPal.");
        }
    }

    public class StripePaymentService
    {
        public void MakeTransaction(double totalAmount)
        {
            Console.WriteLine($"Проведение транзакции на сумму {totalAmount} руб. через Stripe.");
        }
    }

    public class StripePaymentAdapter : IPaymentProcessor
    {
        private readonly StripePaymentService _stripeService;

        public StripePaymentAdapter(StripePaymentService stripeService)
        {
            _stripeService = stripeService;
        }

        public void ProcessPayment(double amount)
        {
            _stripeService.MakeTransaction(amount);
        }
    }
    public class SquarePaymentService
    {
        public void ProcessPaymentAmount(double paymentAmount)
        {
            Console.WriteLine($"Проведение платежа на сумму {paymentAmount} руб. через Square.");
        }
    }

    public class SquarePaymentAdapter : IPaymentProcessor
    {
        private readonly SquarePaymentService _squareService;

        public SquarePaymentAdapter(SquarePaymentService squareService)
        {
            _squareService = squareService;
        }

        public void ProcessPayment(double amount)
        {
            _squareService.ProcessPaymentAmount(amount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IPaymentProcessor paypalProcessor = new PayPalPaymentProcessor();
            paypalProcessor.ProcessPayment(100.0);

            StripePaymentService stripeService = new StripePaymentService();
            IPaymentProcessor stripeAdapter = new StripePaymentAdapter(stripeService);
            stripeAdapter.ProcessPayment(200.0);

            SquarePaymentService squareService = new SquarePaymentService();
            IPaymentProcessor squareAdapter = new SquarePaymentAdapter(squareService);
            squareAdapter.ProcessPayment(300.0);
        }
    }
}

