Feature: Films on the given planet

As a Star Wars fan
I want to know which films were set on the given planet

Scenario: Get film list for the planet
	Given the planet ID is: 1
	When response status is: OK
	Then the planet is the place for films like:
		| FilmTitle            |
		| A New Hope           |
		| Return of the Jedi   |
		| The Phantom Menace   |
		| Attack of the Clones |
		| Revenge of the Sith  |