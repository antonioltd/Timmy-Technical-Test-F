Feature: TestFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@posts
Scenario: Get a specific post
	Given Posts rest endpoint is up
	When I request to get a post with id number 1
	Then the system will return 200 code
	And the title of the post is 'sunt aut facere repellat provident occaecati excepturi optio reprehenderit'

@posts	
Scenario: Get all posts
	Given Posts rest endpoint is up
	When I request to get all posts
	Then the system will return 200 code
	And the total number of posts is 100

@posts
Scenario: Write a post successfully
	Given Posts rest endpoint is up
	When I request to write a post with detail:
	| title  | body                     | userId |
	| brexit | What happen after brexit | 1      |
	Then the system will return 201 code
	And returns a new id

@posts
Scenario: Update a post
	Given Posts rest endpoint is up
	When I request to update a post with following details:
	| title         | body         | userId | id |
	| updated title | updated body | 1      | 1  |
	Then the system will return 200 code
	And the post is updated

@posts
Scenario: Patch title of a post
Given Posts rest endpoint is up
	When I request to patch value of a title with 'new title' by id number 1
	Then the system will return 200 code
	And the title is updated
	

@posts
Scenario: Delete a post
	Given Posts rest endpoint is up
	When I request to delete a post with id number 1
	Then the system will return 200 code
	And the post is deleted


@comments
Scenario: Get a specific comment
	Given Comments rest endpoint is up
	When I request to get a comment with id number 1
	Then the system will return 200 code
	And the comment details are:
	| postId | id | name                         | email              | body                                                                                                                                                    |
	| 1      | 1  | id labore ex et quam laborum | Eliseo@gardner.biz | laudantium enim quasi est quidem magnam voluptate ipsam eos\ntempora quo necessitatibus\ndolor quam autem quasi\nreiciendis et nam sapiente accusantium |


@comments
Scenario: Get all comments
	Given Comments rest endpoint is up
	When I request to get all comments
	Then the system will return 200 code
	And the total number of comments is 500

@comment
Scenario: Delete a comment
	Given Comments rest endpoint is up
	When I request to delete a comment with id number 1
	Then the system will return 200 code
	And the comment is deleted

@albums
Scenario: Get specific album
	Given Albums rest endpoint is up
	When I request to get an album with id number 1
	Then the system will return 200 code 
	And the album details are:
	| userId | id | title                 |
	| 1      | 1  | quidem molestiae enim |

@albums
Scenario: Get all albums
	Given Albums rest endpoint is up
	When I request to get all album
	Then the system will return 200 code
	And the total number of albums is 100
		
@albums
Scenario: Delete a album
	Given Comments rest endpoint is up
	When I request to delete a album with id number 1
	Then the system will return 200 code
	And the album is deleted

@photos
Scenario: Get specific photo
	Given Photos rest endpoint is up
	When I request to get a photo with id number 1
	Then the system will return 200 code 
	And the photo details are:
	| albumId | id | title                                              | url                                    | thumbnailUrl                           |
	| 1       | 1  | accusamus beatae ad facilis cum similique qui sunt | https://via.placeholder.com/600/92c952 | https://via.placeholder.com/150/92c952 |

@photos
Scenario: Get all photos
	Given Photos rest endpoint is up
	When I request to get all photos
	Then the system will return 200 code
	And the total number of photos is 5000

@photos
Scenario: Delete a photo
	Given Photo rest endpoint is up
	When I request to delete a photo with id number 1
	Then the system will return 200 code
	And the photo is deleted

@users
Scenario: Get specific user
	Given Users rest endpoint is up
	When I request to get a user with id number 1
	Then the system will return 200 code 
	And the user details are:																										   
	| id | name          | userName | email             | addressStreet | addressSuite | addressCity | addressZipcode | addressGeoLat | addressGeoLng | phone                 | website       | companyName     | comapanyCatchPhrase                    | companyBs                   |
	| 1  | Leanne Graham | Bret     | Sincere@april.biz | Kulas Light   | Apt. 556     | Gwenborough | 92998-3874     | -37.3159      | 81.1496       | 1-770-736-8031 x56442 | hildegard.org | Romaguera-Crona | Multi-layered client-server neural-net | harness real-time e-markets |
	
@users
Scenario: Get all users
	Given Users rest endpoint is up
	When I request to get all users
	Then the system will return 200 code
	And the total number of user is 10

@users
Scenario: Delete a user
	Given User rest endpoint is up
	When I request to delete a user with id number 1
	Then the system will return 200 code
	And the user is deleted

@todos
Scenario: Get specific todo
	Given Todos rest endpoint is up
	When I request to get an todo with id number 1
	Then the system will return 200 code 
	And the todo details are:
	| userId | id | title              | completed |
	| 1      | 1  | delectus aut autem | false     |
	
@todos
Scenario: Get all todos
	Given Todos rest endpoint is up
	When I request to get all todos
	Then the system will return 200 code
	And the total number of todos is 200   

@todos
Scenario: Delete a todo
	Given User rest endpoint is up
	When I request to delete a todo with id number 1
	Then the system will return 200 code
	And the todo is deleted
       
       
       
																										   
																										   
																										   
																										   
																										   
																										   
