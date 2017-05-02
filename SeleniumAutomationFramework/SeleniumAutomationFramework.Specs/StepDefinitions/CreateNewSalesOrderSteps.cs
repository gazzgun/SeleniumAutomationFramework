using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumAutomationFramework.Common.Helpers;
using SeleniumAutomationFramework.Drivers;
using SeleniumAutomationFramework.PageObjects.Model;
using SeleniumAutomationFramework.PageObjects.PageFactory;
using SeleniumAutomationFramework.PageObjects.Sikuli;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumAutomationFramework.Specs.StepDefinitions
{
    [Binding]
    public class CreateNewSalesOrderSteps
    {
        Customer customer = new Customer();

        [Given(@"I navigate to the customer screen")]
        public void GivenINavigateToTheCustomerScreen()
        {
            Pages.HomePage.ClickCustomer();
            Thread.Sleep(500);
            Assert.True(Pages.CreateCustomerPage.GetTitle().Equals(SeleniumDriver.Instance.Title));
        }

        [Given(@"I create a new customer ""(.*)""")]
        public void GivenIAmOnTheHomeScreenAndICreateANewCustomer(string customerName)
        {
            customer.setCustomerDetails(customerName);
            //Pages.HomePage.ClickCustomer();
            Pages.HomePage.ClickCreateNewCustomer();
        }
        [When(@"I submit new customer details")]
        public void WhenISubmitNewCustomerDetails()
        {
            Pages.CreateCustomerPage.CreateNewCustomer(customer);
        }

        [Then(@"I should be able to see the new customer in the customer list")]
        public void ThenIShouldBeAbleToSeeTheNewCustomerInTheCustomerList()
        {
            Assert.True(Pages.HomePage.ConfirmCustomer(customer.number.ToString()), "Customer " + customer.name + "cannot be found");
           // HomePageSikuli.ReturnHome();

        }

        [Given(@"The customer ""(.*)"" exist")]
        public void GivenIAmOnTheHomeScreenAndTheCustomerExist(string customerId)
        {
           // Pages.HomePage.ClickCustomer();
            if (!Pages.HomePage.ConfirmCustomer(customerId))
            {
                customer.setCustomerDetails("QAWorks");
                Pages.HomePage.ClickCreateNewCustomer();
                Pages.CreateCustomerPage.CreateNewCustomer(customer);
            }
        }

        [Given(@"I select the customer to delete ""(.*)""")]
        public void GivenISelectTheCustomerToDelete(string customerID)
        {
            Pages.HomePage.SelectCustomerById(customerID);
        }

        [When(@"I delete the customer information")]
        public void WhenIDeleteTheCustomerInformation()
        {
            Pages.CreateCustomerPage.DeleteCustomer();
        }

        [Then(@"that customer should be deleted ""(.*)""")]
        public void ThenThatCustomerShouldBeDeleted(string customerId)
        {
            SeleniumHelper.Wait(1);
            Assert.False(Pages.HomePage.ConfirmCustomer(customerId), "Customer " + customerId + "cannot be found");
           // HomePageSikuli.ReturnHome();
        }

        [Given(@"I select a customer to modify based on their id ""(.*)""")]
        public void GivenIAmOnTheHomeScreenAndISelectACustomerToModifyBasedOnTheirId(string customerID)
        {
            Pages.HomePage.SelectCustomerById(customerID);
        }

     
        [When(@"I modify the phone number ""(.*)""")]
        public void WhenIModifyThePhoneNumber(string phoneNumber)
        {
            Pages.CreateCustomerPage.ModifyPhoneNumber(phoneNumber);
        }
       
        [Then(@"I should be able to see the updated phone number ""(.*)""")]
        public void ThenIShouldBeAbleToSeeTheUpdatedPhoneNumber(string phoneNumberResult)
        {
            Assert.True(Pages.HomePage.ConfirmCustomer(phoneNumberResult));
           // HomePageSikuli.ReturnHome();
        }




        



    }
}
