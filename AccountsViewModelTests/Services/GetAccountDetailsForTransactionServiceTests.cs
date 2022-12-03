//using System.Collections.Generic;
//using System.Text.RegularExpressions;
//using AccountLib.Model.Accounts;
//using Moq;
//using AccountsViewModel.EntityViewModels.Interfaces;
//using AccountsViewModel.Factories.Interfaces.RegexFactories;
//using Xunit;
//using AccountsViewModel.Xunit.Tests.Services.Tests;
//using AccountsViewModel.Services.Interfaces;
//using AccountsViewModel.Services;
//
//namespace AccountsViewModelTests.Services
//{
//    public class GetAccountDetailsForTransactionServiceTests
//    {
//        GetAccountDetailsForTransactionService sut;
//        ICollection<Account> debitList;
//        ICollection<Account> creditList;
//        Mock<ITransactionViewModel> transactionViewModel;
//        Mock<IRegexFactory> regexFactory;
//
//        public GetAccountDetailsForTransactionServiceTests(IList<Account>? debitlist)
//        {
//            debitList = new List<Account>
//        {
//            new ExpenseAccount
//            {
//            Id=2,
//                    Name="PERSIL MACH LIQ1L"
//            },
//            new ExpenseAccount
//            {
//            Id=3,
//                Name="NAT S/ NETTLE 50G"
//            }
//        };
//            creditList = new List<Account>
//        {
//        new CurrencyAccount
//        {
//            Id=4,
//            Name="CREDIT CARD"
//        },
//        new CurrencyAccount
//        {
//            Id=5,
//            Name="Cash"
//        }
//        };
//            transactionViewModel = new Mock<ITransactionViewModel>();
//            regexFactory = new Mock<IRegexFactory>();
//
//            transactionViewModel.Setup(a => a.DebitAccountSelectionList)
//                .Returns(debitList);
//            transactionViewModel.Setup(a => a.CreditAccountSelectionList)
//                .Returns(creditList);
//
//            IList<Account>? debitlist = debitList as IList<Account>;
//
//            _ = regexFactory.Setup(a => a.CreateRegex(debitlist[0].Name))
//               .Returns(new Regex(debitlist[0].Name));
//            _ = regexFactory.Setup(a => a.CreateRegex(debitlist[1].Name))
//               .Returns(new Regex(debitlist[1].Name));
//
//            IList<Account>? creditlist = creditList as IList<Account>;
//            _ = regexFactory.Setup(a => a.CreateRegex(creditlist[0].Name))
//                .Returns(new Regex(creditlist[0].Name));
//            regexFactory.Setup(a => a.CreateRegex(creditlist[1].Name))
//                .Returns(new Regex(creditlist[1].Name));
//
//            sut = new GetAccountDetailsForTransactionService(regexFactory.Object);
//        }
//
//        public void ShouldImplementIGetAccountDetailsForTransactionService()
//        {
//            Assert.IsAssignableFrom<IGetAccountDetailsForTransactionService>(sut);
//        }
//
//        public void ShouldGetDebitAccountFromTextAndTransactionViewModel()
//        {
//            string teststring =
//                   "622114306778 \n" +
//                   "PERSIL MACH LIQ1L 499.00 A \n";
//            sut.GetDebitAccountForTransactionFromText(teststring, transactionViewModel.Object);
//            transactionViewModel.VerifySet(a => a.DebitAccountId = 2);
//        }
//
//        public void ShouldGetCreditAccountFromTextAndTransactionViewModel()
//        {
//            sut.GetCreditAccountForTransactionFromText(SampleDocument.Text, transactionViewModel.Object);
//            transactionViewModel.VerifySet(a => a.CreditAccountId = 4);
//        }
//
//    }
//}
