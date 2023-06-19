Feature: Planet search

Scenario: Search for planet based on ID
	Given the planet ID is: <PlanetID>
	When response status is: <ResponseStatus>
	Then the planet name is: <PlanetName>
Examples:
	| PlanetID | ResponseStatus | PlanetName |
	| 3        | OK             | Yavin IV   |
	| 1        | OK             | Tatooine   |
	| 2        | OK             | Alderaan   |
	| 4        | OK             | Hoth       |
	
