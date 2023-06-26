Feature: Film list search

Scenario: Search for the star wars films
	Given the film endpoint: /films
	When response status is: OK
	Then the film titles are:
		| FilmTitles              |
		| A New Hope              |
		| The Empire Strikes Back |
		| Return of the Jedi      |
		| The Phantom Menace      |
		| Attack of the Clones    |
		| Revenge of the Sith     |