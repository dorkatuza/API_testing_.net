Feature: Species search

Scenario: Search for species based on ID
	Given the species ID is: <SpeciesID>
	When response status is: <ResponseStatus>
	Then the species name is: <SpeciesName>
Examples:
	| SpeciesID | ResponseStatus | SpeciesName |
	| 1         | OK             | Human       |
	| 2         | OK             | Droid       |
	| 3         | OK             | Wookie      |
	| 4         | OK             | Rodian      |
	| 5         | OK             | Hutt        |