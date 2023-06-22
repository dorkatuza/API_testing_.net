Feature: People for the given species

As a Star Wars fan
I want to know the given species who belongs to

@tag1
Scenario: Get people for the species
	Given the species ID is: 2
	When response status is: OK
	Then the people are for the given species:
		| CharacterName |
		| C-3PO         |
		| R2-D2         |
		| R5-D4         |
		| IG-88         |