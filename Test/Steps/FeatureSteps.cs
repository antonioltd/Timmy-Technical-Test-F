using Framework;
using Framework.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Test.Steps
{
    [Binding]
    public class FeatureSteps
    {
        ApiHelper api = ApiHelper.GetInstance;
        private IRestResponse _response;

        [Given(@"(.*) rest endpoint is up")]
        public void GivenPostsRestEndpointIsUp(string resource)
        {
            Console.WriteLine($"{resource.ToUpper()} rest endpoint is up.");
        }

        [When(@"I request to get a post with id number (\d+)")]
        public void RequestToGetPostWithIdNumber(int id)
        {
            _response = api.GetSpecificPost(id);
        }

        [When(@"I request to get an album with id number (\d+)")]
        public void WhenIRequestToGetAnAlbumWithIdNumber(int id)
        {
            _response = api.GetSpecificAlbum(id);
        }

        [When(@"I request to get a photo with id number (\d+)")]
        public void WhenIRequestToGetAPhotoWithIdNumber(int id)
        {
            _response = api.GetSpecificPhoto(id);
        }

        [When(@"I request to get a user with id number (\d+)")]
        public void WhenIRequestToGetAUserWithIdNumber(int id)
        {
            _response = api.GetSpecificUser(id);
        }

        [When(@"I request to get an todo with id number (\d+)")]
        public void WhenIRequestToGetAnTodoWithIdNumber(int id)
        {
            _response = api.GetSpecificTodo(id);
        }



        [When(@"I request to write a post with detail:")]
        public void WriteAPost(Table table)
        {
            var post = table.CreateInstance<WriteAPostScenarioType>();

            _response = api.WriteAPost(post);
        }

        [Then(@"the system will return (\d+) code")]
        public void SystemResponseCode(int statusCode)
        {
            Assert.That((int)_response.StatusCode, Is.EqualTo(statusCode));
        }

        [Then(@"the post is updated")]
        public void ThenThePostIsUpdated()
        {

            var newPostDetails = api.ResponseContent<Posts>(_response);

            var sourceResponse = api.GetSpecificPost(newPostDetails.id);
            var sourceData = api.ResponseContent<Posts>(sourceResponse);
           
            Assert.Multiple(() =>
            {
                Assert.AreEqual(newPostDetails.body, sourceData.body,"Failed updated post body.");
                Assert.AreEqual(newPostDetails.title, sourceData.title, "Failed updated post title.");
            });
            
        }

        [Then(@"the title is updated")]
        public void ThenTheTitleIsUpdated()
        {
            var newPostDetails = api.ResponseContent<Posts>(_response);

            var sourceResponse = api.GetSpecificPost(newPostDetails.id);

            var sourceData = api.ResponseContent<Posts>(sourceResponse);

            Assert.AreEqual(newPostDetails.title, sourceData.title,"Failed to patch the post.");

        }


        [Then(@"the title of the post is '(.*)'")]
        public void TitleOfThePost(string title)
        {
            var post = api.ResponseContent<Posts>(_response);

            Assert.AreEqual(title, post.title);
        }

        [When(@"I request to get all posts")]
        public void RequestToGetAllPosts()
        {
            _response = api.GetAllPosts();
        }

        [When(@"I request to get all comments")]
        public void WhenIRequestToGetAllComments()
        {
            _response = api.GetAllComments();
        }

        [When(@"I request to get all album")]
        public void WhenIRequestToGetAllAlbum()
        {
            _response = api.GetAllAlbums();
        }

        [When(@"I request to get all photos")]
        public void WhenIRequestToGetAllPhotos()
        {
            _response = api.GetAllPhotos();
        }

        [When(@"I request to get all users")]
        public void WhenIRequestToGetAllUsers()
        {
            _response = api.GetAllUsers();
        }

        [When(@"I request to get all todos")]
        public void WhenIRequestToGetAllTodos()
        {
            _response = api.GetAllTodos();
        }

        [When(@"I request to delete a post with id number (\d+)")]
        public void WhenIRequestToDeleteAPostWithIdNumber(int id)
        {
            _response = api.DeletePost(id);
                ScenarioContext.Current.Add("currentPostId", id);
        }

        [When(@"I request to update a post with following details:")]
        public void WhenIRequestToUpdateAPostWithFollowingDetails(Table table)
        {
            var post = table.CreateInstance<Posts>();
            
            _response = api.UpdatePost(post);

        }

        [When(@"I request to patch value of a title with '(.*)' by id number (\d+)")]
        public void WhenIRequestToPatchValueOfATitleWithByIdNumber(string newTitle, int id)
        {
            _response = api.PatchPostTitle(id, newTitle);
        }



        [When(@"I request to delete a comment with id number (\d+)")]
        public void WhenIRequestToDeleteACommentWithIdNumber(int id)
        {
            _response = api.DeleteComment(id);
            ScenarioContext.Current.Add("currentCommentId", id);
        }

        [When(@"I request to delete a album with id number (\d+)")]
        public void WhenIRequestToDeleteAlbumWithIdNumber(int id)
        {
            _response = api.DeleteAlbum(id);
            ScenarioContext.Current.Add("currentAlbumId", id);
        }


        [When(@"I request to delete a photo with id number (\d+)")]
        public void WhenIRequestToDeleteAPhotoWithIdNumber(int id)
        {
            _response = api.DeletePhoto(id);
            ScenarioContext.Current.Add("currentPhotoId", id);
        }


        [When(@"I request to delete a user with id number (\d+)")]
        public void WhenIRequestToDeleteAUserWithIdNumber(int id)
        {
            _response = api.DeleteUser(id);
            ScenarioContext.Current.Add("currentUserId", id);
        }


        [When(@"I request to delete a todo with id number (\d+)")]
        public void WhenIRequestToDeleteATodoWithIdNumber(int id)
        {
            _response = api.DeleteTodo(id);
            ScenarioContext.Current.Add("currentTodoId", id);
        }




        [When(@"I request to get a comment with id number (\d+)")]
        public void WhenIRequestToGetACommentWithIdNumber(int id)
        {
            _response = api.GetSpecificComment(id);
        }

        [Then(@"the post is deleted")]
        public void ThenThePostIsDeleted()
        {
            var id = ScenarioContext.Current.Get<int>("currentPostId");

            api.IsPostIdPresent(id);

            //Verify id is successfully deleted
            Assert.IsFalse(api.IsPostIdPresent(id), "Failed to delete post with ID: " + id);
        }

        [Then(@"the comment is deleted")]
        public void ThenTheCommentIsDeleted()
        {
            var id = ScenarioContext.Current.Get<int>("currentCommentId");

            api.IsCommentIdPresent(id);

            //Verify id is successfully deleted
            Assert.IsFalse(api.IsCommentIdPresent(id), "Failed to delete comment with ID: " + id );
        }

        [Then(@"the album is deleted")]
        public void ThenTheAlbumIsDeleted()
        {
            var id = ScenarioContext.Current.Get<int>("currentAlbumId");

            api.IsAlbumIdPresent(id);

            //Verify id is successfully deleted
            Assert.IsFalse(api.IsAlbumIdPresent(id), "Failed to delete album with ID: " + id);
        }

        [Then(@"the photo is deleted")]
        public void ThenThePhotoIsDeleted()
        {
            var id = ScenarioContext.Current.Get<int>("currentPhotoId");

            api.IsPhotoIdPresent(id);

            //Verify id is successfully deleted
            Assert.IsFalse(api.IsPostIdPresent(id), "Failed to delete photo with ID: " + id);
        }

        [Then(@"the user is deleted")]
        public void ThenTheUserIsDeleted()
        {
            var id = ScenarioContext.Current.Get<int>("currentUserId");

            api.IsUserIdPresent(id);

            //Verify id is successfully deleted
            Assert.IsFalse(api.IsPostIdPresent(id), "Failed to delete user with ID: " + id);
        }

        [Then(@"the todo is deleted")]
        public void ThenTheTodoIsDeleted()
        {
            var id = ScenarioContext.Current.Get<int>("currentTodoId");

            api.IsTodoIdPresent(id);

            //Verify id is successfully deleted
            Assert.IsFalse(api.IsPostIdPresent(id), "Failed to delete todo with ID: " + id);
        }

       [Then(@"the comment details are:")]
        public void ThenTheCommentDetailsAre(Table table)
        {
            var comment = table.CreateInstance<Comment>();

            var data = api.ResponseContent<Comment>(_response);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(comment.id, data.id);
                Assert.AreEqual(comment.body, data.body);
                Assert.AreEqual(comment.email, data.email);
                Assert.AreEqual(comment.name, data.name);
                Assert.AreEqual(comment.postId, data.postId);
            });
            
        }

        [Then(@"the user details are:")]
        public void ThenTheUserDetailsAre(Table table)
        {
            var user = table.CreateInstance<CreateUserScenarioType>();

            var data = api.ResponseContent<User>(_response);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(user.id, data.id);
                Assert.AreEqual(user.email, data.email);
                Assert.AreEqual(user.name, data.name);
                Assert.AreEqual(user.userName, data.username);

                Assert.AreEqual(user.addressCity, data.address.city);
                Assert.AreEqual(user.addressStreet, data.address.street);
                Assert.AreEqual(user.addressZipcode, data.address.zipcode);
                Assert.AreEqual(user.addressSuite, data.address.suite); Assert.AreEqual(user.addressZipcode, data.address.zipcode);

                Assert.AreEqual(user.addressGeoLat, data.address.geo.lat);
                Assert.AreEqual(user.addressGeoLng, data.address.geo.lng);

                Assert.AreEqual(user.phone, data.phone);
                Assert.AreEqual(user.website, data.website);
                Assert.AreEqual(user.companyName, data.company.name);
                Assert.AreEqual(user.companyCatchPhrase, data.company.catchPhrase);
                Assert.AreEqual(user.companyBs, data.company.bs);


            });
        }


        [Then(@"the album details are:")]
        public void ThenTheAlbumDetailsAre(Table table)
        {
            var album = table.CreateInstance<Album>();

            var data = api.ResponseContent<Album>(_response);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(album.id, data.id);
                Assert.AreEqual(album.title, data.title);
                Assert.AreEqual(album.userId, data.userId);
            });
        }

        [Then(@"the photo details are:")]
        public void ThenThePhotoDetailsAre(Table table)
        {
            var photo = table.CreateInstance<Photo>();

            var data = api.ResponseContent<Photo>(_response);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(photo.id, data.id);
                Assert.AreEqual(photo.title, data.title);
                Assert.AreEqual(photo.albumId, data.albumId);
                Assert.AreEqual(photo.url, data.url);
                Assert.AreEqual(photo.thumbnailUrl, data.thumbnailUrl);
            });
        }

        [Then(@"the todo details are:")]
        public void ThenTheTodoDetailsAre(Table table)
        {
            var todo = table.CreateInstance<Todo>();

            var data = api.ResponseContent<Todo>(_response);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(todo.id, data.id);
                Assert.AreEqual(todo.title, data.title);
                Assert.AreEqual(todo.userId, data.userId);
                Assert.AreEqual(todo.completed, data.completed);
                
            });

        }


        [Then(@"the total number of posts is (\d+)")]
        public void ThenTheTotalNumberOfPostsIs(int numberOfPosts)
        {
            var posts = api.ResponseContent<IList<Posts>>(_response);

            Assert.AreEqual(numberOfPosts, posts.Count);
        }

        [Then(@"the total number of photos is (\d+)")]
        public void ThenTheTotalNumberOfPhotosIs(int numberOfPhotos)
        {
            var posts = api.ResponseContent<IList<Posts>>(_response);

            Assert.AreEqual(numberOfPhotos, posts.Count);
        }

        [Then(@"the total number of user is (\d+)")]
        public void ThenTheTotalNumberOfUserIs(int numberOfUsers)
        {
            var posts = api.ResponseContent<IList<User>>(_response);

            Assert.AreEqual(numberOfUsers, posts.Count);
        }


        [Then(@"the total number of albums is (.*)")]
        public void ThenTheTotalNumberOfAlbumsIs(int numberOfAlbums)
        {
            var albums = api.ResponseContent<IList<Album>>(_response);

            Assert.AreEqual(numberOfAlbums, albums.Count);
        }


        [Then(@"the total number of comments is (\d+)")]
        public void ThenTheTotalNumberOfCommentsIs(int numberOfComments)
        {
            var comments = api.ResponseContent<IList<Comment>>(_response);

            Assert.AreEqual(numberOfComments,comments.Count);
        }

        [Then(@"the total number of todos is (\d+)")]
        public void ThenTheTotalNumberOfTodosIs(int numberOfTodos)
        {
            var comments = api.ResponseContent<IList<Comment>>(_response);

            Assert.AreEqual(numberOfTodos, comments.Count);
        }

        [Then(@"returns a new id")]
        public void ReturnsANewId()
        {
            dynamic data = JsonConvert.DeserializeObject(_response.Content);

            //new Id
            var id = data.id.Value;
            Assert.NotNull(id);

            //Verify id is successfully add
            Assert.IsTrue(api.IsPostIdPresent(Convert.ToInt32(id)), "Failed to write a post.");

        }

    }
}
