Feature: Get Request

@tag1
Scenario: User Get the data
	Given I have the API endpoint "https://gorest.co.in/public/v2/users/7467348"
    When I send a GET request
    Then the Get response status code should be 200
    And the Get response should contain the user name
