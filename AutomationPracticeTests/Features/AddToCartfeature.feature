Feature: AddToCartfeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background:
	Given I am using a browser
	And I have navigated to "http://automationpractice.com/index.php"
	And I am a new customer
	And I have registered an account
	And I am logged in

Scenario: Order dress by highest price shows the higest price item first
	Given I go to the 'Dresses' tab
	When I order results by 'Price: Highest first"
	Then the first product is priced "$50.99"

Scenario: I can add the most expensive item to the cart
	Given I go to the 'Dresses' tab
	When I add the item priced "$50.99" to the cart
	Then an item priced "$50.99" is in the cart

Scenario: Carts are retained across sessions
	Given I go to the 'Dresses' tab
	And I add the item priced "$50.99" to the cart
	And I logout
	When I login
	And I go to the 'View my shopping cart' tab
	Then an item priced "$50.99" is in the cart
