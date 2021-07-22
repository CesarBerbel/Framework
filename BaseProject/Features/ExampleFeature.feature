Feature: Example Page
	In order to show how it works
	As a automation QA
	I want to search for Valtech on search engines

Scenario Outline: Checking Valtech search results 
Given I navigate to the search page <url>
And I fill the search input with <term>
When I press ok
Then I should be directed to result page for <term>
Examples:
| Engine        | url                    | term    |
| google        | http:\\google.com      | Valtech |
| Duck Duck Go  | http:\\duckduckgo.com  | Valtech |