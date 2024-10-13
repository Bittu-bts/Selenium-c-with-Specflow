Feature: POST a new user

@tag2
Scenario: Create a new user
    Given I have the POST API endpoint "https://gorest.co.in/public/v2/users"
    And I have the user data 
        """
        {
            "id": 190067,
            "name": "Aihuhi",
            "email": "babjhbai@spence-bednar.info",
            "gender": "male",
            "status": "inactive"
        }
        """
    When I send a POST request
    Then the Post response status code should be 201
    And the Post response should contain the user name
