using NUnit.Framework;
using SeleniumAutomationFramework.Common.Helpers;
using SeleniumAutomationFramework.PageObjects.Model;
using SeleniumAutomationFramework.PageObjects.PageFactory;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumAutomationFramework.Specs.StepDefinitions
{
    [Binding]
    public class CreateNewSalesOrderSteps
    {
        Customer customer = new Customer();

        [Given(@"I am on the home screen and I navigate to create a new customer ""(.*)""")]
        public void GivenIAmOnTheHomeScreenAndINavigateToCreateANewCustomer(string customerName)
        {
            customer.setCustomerDetails(customerName);
            Pages.HomePage.ClickCustomer();
        }
            


        [When(@"I enter the new customer details")]
        public void WhenIEnterTheNewCustomerDetails()
        {
            Pages.CreateCustomerPage.CreateNewCustomer(customer);
        }
        [Then(@"I should be able to see the new customer in the customer list")]
        public void ThenIShouldBeAbleToSeeTheNewCustomerInTheCustomerList()
        {
            Assert.True(Pages.HomePage.ConfirmCustomer(customer.number.ToString()), "Customer " + customer.name + "cannot be found");
        }

        [Given(@"I am on the home screen and I select the customer to delete ""(.*)""")]
        public void GivenIAmOnTheHomeScreenAndISelectTheCustomerToDelete(string customerID)
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
        }
        [Given(@"I am on the home screen and i select a customer to modify based on their id ""(.*)""")]
        public void GivenIAmOnTheHomeScreenAndISelectACustomerToModifyBasedOnTheirId(string customerID)
        {
            Pages.HomePage.SelectCustomerById(customerID);
        }

        [When(@"I modify their phone number ""(.*)""")]
        public void WhenIModifyTheirPhoneNumber(string phoneNumber)
        {
            Pages.CreateCustomerPage.ModifyPhoneNumber(phoneNumber);
        }

        [Then(@"I should be able to see their new phone number ""(.*)""")]
        public void ThenIShouldBeAbleToSeeTheirNewPhoneNumber(string phoneNumberResult)
        {
            Assert.True(Pages.HomePage.ConfirmCustomer(phoneNumberResult));
        }



    }
}
