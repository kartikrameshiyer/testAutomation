Feature: User Login
  In order to access the system
  As a user
  I want to login with valid credentials

  Scenario: Login with valid credentials
    Given I am on the login page
    When I enter valid credentials
    Then I should be logged in successfully
