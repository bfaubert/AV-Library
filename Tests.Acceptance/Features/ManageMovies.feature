Feature: Manage movies
	In order to keep track of the movies we own
	As a movie lover
	I want to be able to view, add, edit and remove movies in our collection

@mytag
Scenario: View a list of available movies
	Given I am logged in
	When I navigate to /en/movies
	Then the list of movies should appear on the screen
