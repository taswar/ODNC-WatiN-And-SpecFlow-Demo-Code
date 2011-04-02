Feature: Login
    In order to login to our AppStore
    As a visitor
    I want to be able to say that I was at the site

Scenario: Login as admin to MvcStore
    Given I have filled out all required information
    When I press Log In
    Then I should be redirected to the full list of record entries and see a Log Out message
	@ignore
Scenario: Adding items to shopping cart
    Given I have added items to my shopping cart
    When I press Cart
    Then I should be see a list of items I have in my cart