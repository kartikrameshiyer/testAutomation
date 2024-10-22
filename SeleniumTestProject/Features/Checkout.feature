Feature: Checkout Process
  In order to complete a purchase
  As a user
  I want to check out with valid payment details

  Scenario: Complete checkout process
    Given I am on the checkout page
    When I enter valid payment details
    Then the order should be placed successfully
