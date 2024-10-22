Feature: Google Search
  In order to validate search functionality on Google
  As a user
  I want to search for "Valuemomentum"

  Scenario: Search for Valuemomentum on Google
    Given I am on the Google homepage
    When I search for "Valuemomentum"
    Then I should see "Valuemomentum" in the search results
