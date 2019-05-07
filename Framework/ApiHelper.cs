using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Models;
using Newtonsoft.Json;
using RestSharp;


namespace Framework
{
    public class ApiHelper
    {
        private ApiHelper() { }

        private IRestRequest _request;

        private IRestClient _client;

        private IRestResponse _response;

        private static ApiHelper instance = null;

        public static ApiHelper GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApiHelper();
                }
                return instance;
            }
        }

        private IRestRequest CreateRequest(RequestDetails requestDetails, object jsonBody = null)
        {
            _request = new RestRequest(requestDetails.ResourceEndpoint, requestDetails.MethodType);

            if (requestDetails.RequestParameterList == null) return _request;

            foreach (var parameter in requestDetails.RequestParameterList)
            {
                _request.AddParameter(parameter.Name, parameter.Value, parameter.ParameterType);
            }

            _request.AddJsonBody(jsonBody);

            return _request;

        }

        private IRestResponse ExecuteRequest(IRestRequest request)
        {
            _client = new RestClient(AppSettings.BaseUrl);

            _response = _client.Execute(request);

            request.Parameters.Clear();

            return _response;

        }


        public IRestResponse GetAllPosts()
        {
            _request = CreateRequest(new RequestDetails
            {
                MethodType = Method.GET,
                ResourceEndpoint = $"{Endpoint.Posts}"

            });

            return ExecuteRequest(_request);
        }

        public IRestResponse GetSpecificPost(int id)
        {
            _request = CreateRequest(new RequestDetails
            {
                MethodType = Method.GET,
                ResourceEndpoint = $"{Endpoint.Posts}/{id}"

            });

            return ExecuteRequest(_request);
        }

        public IRestResponse GetUserInformation(string id)
        {
            _request = CreateRequest(new RequestDetails
            {
                MethodType = Method.GET,
                ResourceEndpoint = $"{Endpoint.Users}/{1}"
            });

            return ExecuteRequest(_request);
        }

        public T ResponseContent<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public IRestResponse WriteAPost(WriteAPostScenarioType postScenarioType)
        {
            _request = CreateRequest(new RequestDetails()
            {
                ResourceEndpoint = Endpoint.Posts,
                MethodType = Method.POST,
                RequestParameterList = new List<RequestParameter>()
                    {
                        new RequestParameter()
                        {
                            ParameterType = ParameterType.HttpHeader,
                            Name = "Content-Type",
                            Value = "application/json; charset=UTF-8"
                        }
                    }
            }, postScenarioType);

            return ExecuteRequest(_request);

        }

        public bool IsPostIdPresent(int id)
        {
            _response = GetAllPosts();

            var posts = ResponseContent<List<Posts>>(_response);

            return posts.Any(p => p.id == Convert.ToInt32(id));

        }

        public bool IsCommentIdPresent(int id)
        {
            _response = GetAllComments();

            var posts = ResponseContent<List<Comment>>(_response);

            return posts.Any(p => p.id == Convert.ToInt32(id));

        }

        public bool IsAlbumIdPresent(int id)
        {
            _response = GetAllAlbums();

            var posts = ResponseContent<List<Album>>(_response);

            return posts.Any(p => p.id == Convert.ToInt32(id));

        }

        public bool IsPhotoIdPresent(int id)
        {
            _response = GetAllPhotos();

            var posts = ResponseContent<List<Photo>>(_response);

            return posts.Any(p => p.id == Convert.ToInt32(id));

        }

        public bool IsUserIdPresent(int id)
        {
            _response = GetAllUsers();

            var posts = ResponseContent<List<User>>(_response);

            return posts.Any(p => p.id == Convert.ToInt32(id));

        }

        public bool IsTodoIdPresent(int id)
        {
            _response = GetAllTodos();

            var posts = ResponseContent<List<Todo>>(_response);

            return posts.Any(p => p.id == Convert.ToInt32(id));

        }

        public IRestResponse GetSpecificComment(int id)
        {
            _request = CreateRequest(new RequestDetails()
            {
                MethodType = Method.GET,
                ResourceEndpoint = $"{Endpoint.Comments}/{id}",

            });

            return ExecuteRequest(_request);
        }

        public IRestResponse GetAllComments()
        {
            _request = CreateRequest(new RequestDetails()
            {
                MethodType = Method.GET,
                ResourceEndpoint = Endpoint.Comments,

            });

            return ExecuteRequest(_request);
        }

        public IRestResponse GetSpecificAlbum(int id)
        {
            _request = CreateRequest(new RequestDetails()
            {
                MethodType = Method.GET,
                ResourceEndpoint = $"{Endpoint.Albums}/{id}",

            });

            return ExecuteRequest(_request);
        }

        public IRestResponse GetAllAlbums()
        {
            _request = CreateRequest(new RequestDetails
            {
                MethodType = Method.GET,
                ResourceEndpoint = $"{Endpoint.Albums}"

            });

            return ExecuteRequest(_request);
        }

        public IRestResponse GetSpecificPhoto(int id)
        {
            _request = CreateRequest(new RequestDetails
            {
                MethodType = Method.GET,
                ResourceEndpoint = $"{Endpoint.Photos}/{id}"

            });

            return ExecuteRequest(_request);
        }

        public IRestResponse GetAllPhotos()
        {
            _request = CreateRequest(new RequestDetails
            {
                MethodType = Method.GET,
                ResourceEndpoint = $"{Endpoint.Photos}"

            });

            return ExecuteRequest(_request);
        }

        public IRestResponse GetSpecificUser(int id)
        {
            _request = CreateRequest(new RequestDetails
            {
                MethodType = Method.GET,
                ResourceEndpoint = $"{Endpoint.Users}/{id}"

            });

            return ExecuteRequest(_request);
        }

        public IRestResponse GetAllUsers()
        {
            _request = CreateRequest(new RequestDetails
            {
                MethodType = Method.GET,
                ResourceEndpoint = $"{Endpoint.Users}"

            });

            return ExecuteRequest(_request);
        }

        public IRestResponse GetSpecificTodo(int id)
        {
            _request = CreateRequest(new RequestDetails
            {
                MethodType = Method.GET,
                ResourceEndpoint = $"{Endpoint.Todos}/{id}"

            });

            return ExecuteRequest(_request);
        }

        public IRestResponse GetAllTodos()
        {
            _request = CreateRequest(new RequestDetails
            {
                MethodType = Method.GET,
                ResourceEndpoint = $"{Endpoint.Todos}"

            });

            return ExecuteRequest(_request);
        }

        public IRestResponse DeletePost(int id)
        {
            _request = CreateRequest(new RequestDetails()
            {
                MethodType = Method.DELETE,
                ResourceEndpoint = $"{Endpoint.Photos}/{id}"

            });

            return ExecuteRequest(_request);
        }

        public IRestResponse DeleteComment(int id)
        {
            _request = CreateRequest(new RequestDetails()
            {
                MethodType = Method.DELETE,
                ResourceEndpoint = $"{Endpoint.Comments}/{id}"

            });

            return ExecuteRequest(_request);

        }

        public IRestResponse DeleteAlbum(int id)
        {
            _request = CreateRequest(new RequestDetails()
            {
                MethodType = Method.DELETE,
                ResourceEndpoint = $"{Endpoint.Albums}/{id}"

            });

            return ExecuteRequest(_request);

        }

        public IRestResponse DeletePhoto(int id)
        {
            _request = CreateRequest(new RequestDetails()
            {
                MethodType = Method.DELETE,
                ResourceEndpoint = $"{Endpoint.Photos}/{id}"

            });

            return ExecuteRequest(_request);

        }
        public IRestResponse DeleteUser(int id)
        {
            _request = CreateRequest(new RequestDetails()
            {
                MethodType = Method.DELETE,
                ResourceEndpoint = $"{Endpoint.Users}/{id}"

            });

            return ExecuteRequest(_request);

        }

        public IRestResponse DeleteTodo(int id)
        {
            _request = CreateRequest(new RequestDetails()
            {
                MethodType = Method.DELETE,
                ResourceEndpoint = $"{Endpoint.Todos}/{id}"

            });

            return ExecuteRequest(_request);

        }

        public IRestResponse UpdatePost(Posts postType)
        {
            _request = CreateRequest(new RequestDetails()
            {
                MethodType = Method.PUT,
                ResourceEndpoint = $"{Endpoint.Posts}/{postType.id}",
                RequestParameterList = new List<RequestParameter>()
               {
                   new RequestParameter()
                   {
                       ParameterType = ParameterType.HttpHeader,
                       Name = "Content-Type",
                       Value = "application/json; charset=UTF-8"
                   }
               }
            }, postType);

            return ExecuteRequest(_request);


        }

        public IRestResponse PatchPostTitle(int id, string newTitle)
        {
            

            _request = CreateRequest(new RequestDetails()
            {
                MethodType = Method.PATCH,
                ResourceEndpoint = $"{Endpoint.Posts}/{id}",
                RequestParameterList = new List<RequestParameter>()
                {
                    new RequestParameter()
                    {
                        ParameterType = ParameterType.HttpHeader,
                        Name = "Content-Type",
                        Value = "application/json; charset=UTF-8"
                    }
                }
            },new NewPostTitle(){title = newTitle});

            return ExecuteRequest(_request);
        }
    }
}
