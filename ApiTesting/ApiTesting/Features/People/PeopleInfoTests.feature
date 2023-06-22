Feature: People search

Scenario: Search for people based on ID
	Given the people ID is: <PeopleID>
	When response status is: <ResponseStatus>
	Then the people name is: <PeopleName>
Examples:
	| PeopleID | ResponseStatus | PeopleName  |
	| 5        | OK             | Leia Organa |
	| 2        | OK             | C-3PO       |
	| 3        | OK             | R2-D2       |
	| 4        | OK             | Darth Vader |