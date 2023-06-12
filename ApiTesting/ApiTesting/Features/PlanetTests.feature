Feature: Planet search

Scenario: Search for planet based on ID
	Given the planet ID is: 3
	When response status is: OK
	Then the planet name is: 'Yavin IV'