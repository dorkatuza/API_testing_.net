Feature: Feature1

As a Star Wars fan
I want to know who's residence is the given planet

@tag1
Scenario: Get residence for the planet
	Given the planet ID is: 1
	When response status is: OK
	Then the planet is the residence for people like:
	| CharacterName      |
	#|https://swapi.dev/api/people/1/ |
	| Luke Skywalker     |
	| C-3PO              |
	| Darth Vader        |
	| Owen Lars          |
	| Beru Whitesun lars |
	| R5-D4              |
	| Biggs Darklighter  |
	| Anakin Skywalker   |
	| Shmi Skywalker     |
	| Cliegg Lars        |
