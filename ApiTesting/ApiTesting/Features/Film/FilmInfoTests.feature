Feature: Film search

Scenario: Search for film based on ID
	Given the film ID is: <FilmID>
	When response status is: <ResponseStatus>
	Then the film title is: <FilmTitle>
Examples:
	| FilmID | ResponseStatus | FilmTitle            |
	| 1      | OK             | A New Hope           |
	| 3      | OK             | Return of the Jedi   |
	| 4      | OK             | The Phantom Menace   |
	| 5      | OK             | Attack of the Clones |
	| 6      | OK             | Revenge of the Sith  |