Feature: Pilots for the given vehicle

As a Star Wars fan
I want to know who was the pilot of the given vehicle

@tag1
Scenario: Get pilots for the vehicle
	Given the vehicle ID is: 14
	When response status is: OK
	Then the pilots are of the given vehicle:
	| CharacterName      |
	| Luke Skywalker     |
	| Wedge Antilles     |