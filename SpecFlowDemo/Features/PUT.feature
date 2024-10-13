Feature: Update an existing user
    In order to modify user information


@tag3
Scenario: Update a user
	Given I have the PUT API endpoint "https://gorest.co.in/public/v2/users/7467348"  
    And I have the updated user data
        """
        {
            "id": 7467348,
            "name": "name1",
            "email": "updated_emmail@example.com",
            "gender": "female",
            "status": "active"
        }
        """
    When I send a PUT request
    Then the Put response status code should be 200
    And the Put response should contain the updated user name
