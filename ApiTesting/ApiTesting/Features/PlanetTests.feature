Feature: Planet search

Scenario: Search for planet based on ID
	Given the planet ID is: <PlanetID>
	When response status is: OK
	Then the planet name is: <PlanetName>
	Examples: 
	| PlanetID | PlanetName |
	| 3        | Yavin IV   |
	| 1        | Tatooine   |
	| 2        | Alderaan   |
	| 4        | Hoth       |
	
