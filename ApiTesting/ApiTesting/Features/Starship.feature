Feature: Starship search

Scenario: Search for starship based on ID
	Given the starship ID is: <StarshipID>
	When response status is: <ResponseStatus>
	Then the starship name is: <StarshipName>
Examples:
	| StarshipID | ResponseStatus | StarshipName     |
	| 3          | OK             | Star Destroyer   |
	| 9          | OK             | Death Star       |
	| 21         | OK             | Slave 1          |
	| 31         | OK             | Republic Cruiser |