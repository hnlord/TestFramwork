Feature: Test time and material module


@add
Scenario: Verify if User can add time and material 
	Given I have logged into the system successfully	
	When I add a Time and Material 
	Then close the browser


@edit
Scenario: Verify if User can edit "time and material" 
	Given user have logged into the system successfully	
	When user edit a record of "Time and Material" 
	Then system can close the browser

@delete
Scenario: Verity is User can delete on record
	Given user has logged into the system
	When user delete a record of "Time and Material"
	Then system can close the browser