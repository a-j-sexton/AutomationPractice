Feature: Create Account


Background:
	Given I am using a browser
	And I have navigated to "http://automationpractice.com/index.php"
	And I am a new customer
	And I am logged out

Scenario: Customer can create an account
	When I register a new account
	Then I am logged in

Scenario: Existing customer can login
	Given I have registered a new account
	And I am logged out
	When I login
	Then I am logged in