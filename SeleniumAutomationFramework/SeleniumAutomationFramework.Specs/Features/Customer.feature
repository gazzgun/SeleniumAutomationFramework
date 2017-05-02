Feature: CreateNewSalesOrder
	As a user  
	I want to add, delete and modify customers 
	So as I can keep track of my sales throughout my bussiness.

	Scenario Outline: Create new customer card
	Given I am on the home screen and I navigate to create a new customer "<CustomerName>"
	When I enter the new customer details
	Then I should be able to see the new customer in the customer list
	
	Examples:
	| CustomerName |
	| QAWorks      |
	

	Scenario Outline: Delete Customer
	Given I am on the home screen and I select the customer to delete "<CustomerID>"
	And the customer <customerID> exist	When I delete the customer information
	Then that customer should be deleted "<CustomerID>"
	
	Examples:
	| CustomerID |
	| 012345     |

	Scenario Outline: Modify Customer Phone Number
	Given I am on the home screen and i select a customer to modify based on their id "<CustomerID>"
	When I modify their phone number "<NewNumber>"
	Then I should be able to see their new phone number "<NumberResult>"

	Examples: 
	| CustomerID | NewNumber | NumberResult |
	| 01121212   | 346236424 | 346236424    |
	| 01121212   | 987654321 | 546541245    |
		
		
		
		
		
	

	

	

	
	