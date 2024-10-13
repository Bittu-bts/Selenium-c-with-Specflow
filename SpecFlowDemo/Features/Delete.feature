Feature: Delete an existing user
    In order to remove a user from the system

@tag1
Scenario: Delete a user
	Given I have the DELETE API endpoint "https://gorest.co.in/public/v2/users/7467348"
    When I send a DELETE request
    Then the Delete response status code should be 204
