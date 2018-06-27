Feature: HomePage as anonymous

@mytag
Scenario Outline: Check buttons from header
	Given I go to the site as anonymous
	When I click button <button> at the header
	Then I am redirected to the <url> page
	And element <element> should be visible

	Examples: 
    | button    | url             | element      |
    | Contact   | /contact        | .contact-map |
    | Subscribe | /               | packages     |
    | Login     | /identity/login | .login-btn   |


Scenario Outline: Check sections on the homepage
	Given I go to the site as anonymous
	Then The <section> section should exist

	Examples: 
	| section                   |
	| Trial                     |
	| Products                  |
	| Key Features              |
	| Thank you to our sponsors |
	| Packages                  |
	| Meet the team             |
	| About us                  |


	Scenario Outline: Check social buttons on the homepage
	Given I go to the site as anonymous
	When I click social <button>
	Then The <url> should be opened

	Examples: 
	| button   | url                               |
	| LinkedIn | https://www.linkedin.com/company/ |
	| Twitter  | https://twitter.com/              |


	Scenario Outline: Check links in the footer on the homepage
	Given I go to the site as anonymous
	When I click <link> in the footer section
	Then I am redirected to the <url> page
	And the <page> title should be correct

	Examples: 
	| link                 | url              | page               |
	| Terms and Conditions | /TermsConditions | Terms & Conditions |
	| Privacy Policy       | /PrivacyPolicy   | Privacy Policy     |
	| Cookies              | /cookies         | Cookies            |
	| About                | /AboutUs         | About Us           |
	| Contact              | /contact         | Contact            |
	| FAQ                  | /FAQ             | FAQ                |

	

	Scenario Outline: User should be able to select a package
	Given I go to the site as anonymous
	When I select a <package> and click Sign Up Now in the packages section
	Then I am redirected to the <url> page
	
	Examples: 
	| package  | url                          |
	| Basic    | /User/Register               |
	| Advanced | /Checkout/?productId=1129808 |
	| Premium  | /Checkout/?productId=1129807 |

