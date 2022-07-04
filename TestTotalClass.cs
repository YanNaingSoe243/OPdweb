
using Microsoft.AspNetCore.Components;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OPdWebApp
{

    public interface IPerson
    {
        Task<IEnumerable<Person>> GetAsync(int pageindex, int pagesize);

       
        Task<IEnumerable<VirtualPerson>> GetAsync(string search, int key);


        Task<Person> GetAsync(string id);

        Task<IEnumerable<Department>> GetDepart();


        Task<Person> UpsertAsync(Person customer);



        Task DeleteAsync(string customerId);
    }
    public interface IAuthenticationService
    {
        Task<LoginResult> Login(SiginModel login);

        LoginResult User { get; }
        Task Initialize();

        Task Logout();

        Task<LoginResult> Register(SiginUp register);
        Task<SiginUp> Update(SiginUp register);

        Task<IEnumerable<SiginUp>> UserList();




    }

    public interface IPatient
    {
        Task<IEnumerable<Patient>> GetAsync(int pageindex, int pagesize);


        Task<IEnumerable<Patient>> GetAsync(string search, int key);


        Task<Patient> GetAsync(string id);


        Task<Patient> UpsertAsync(Patient customer);



        Task DeleteAsync(string customerId);
    }
    public interface IDepart
    {
        Task<IEnumerable<Department>> GetAsync();


        Task<IEnumerable<Department>> GetAsync(string search);

              


        Task<Department> UpsertAsync(Department customer);



        Task DeleteAsync(string customerId);
    }
    public interface IRepositoryT
    {
        IPerson persons { get; }
        IDepart depart { get; }
        IPatient patient { get; }
        IAuthenticationService authentication { get; }
    }
    internal class HttpHelper
    {

        private readonly string _baseUrl;
        [Inject]
        protected IAuthenticationService authenticationService { get; set; }
        public HttpHelper(string baseUrl)
        {
            _baseUrl = baseUrl;
        }


        public async Task<TResult> GetAsync<TResult>(string controller)
        {
           

                using (var client = BaseClient())
                {
                    //var byteArray = Encoding.ASCII.GetBytes("username:password1234");
                    //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    //  client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationService.User.jwtBearer);
                    var response = await client.GetAsync(controller);
                    string json = await response.Content.ReadAsStringAsync();
                   
                    TResult obj = JsonConvert.DeserializeObject<TResult>(json);
                     return obj;
                }
         

        }
       
        public async Task<TResult> GetAsyncGetId<TResult>(string controller)
        {
            try
            {


                using (var client = BaseClient())
                {
                   // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationService.User.jwtBearer);
                    var response = await client.GetAsync(controller);
                    string json = await response.Content.ReadAsStringAsync();
                    TResult obj = JsonConvert.DeserializeObject<TResult>(json);
                    return obj;
                }
            }
            catch (Exception e)
            {

                var error = JsonConvert.DeserializeObject<TResult>(@"{error:'error'}");
                return error;
            }


        }
        public async Task<TResult> PostAsync<TRequest, TResult>(string controller, TRequest body)
        {
            using (var client = BaseClient())
            {
              //  client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationService.User.jwtBearer);
                var response = await client.PostAsync(controller, new JsonStringContent(body));
                string json = await response.Content.ReadAsStringAsync();
                TResult obj = JsonConvert.DeserializeObject<TResult>(json);
                return obj;
            }
        }
        public async Task<TResult> PustAsync<TRequest, TResult>(string controller, TRequest body)
        {
            using (var client = BaseClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationService.User.jwtBearer);
                var response = await client.PostAsync(controller, new JsonStringContent(body));

                string json = await response.Content.ReadAsStringAsync();
                TResult obj = JsonConvert.DeserializeObject<TResult>(json);
                return obj;
            }
        }


        public async Task DeleteAsync(string controller, string objectId)
        {
            using (var client = BaseClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationService.User.jwtBearer);
                await client.DeleteAsync($"{controller}/{objectId}");

            }

        }


        private HttpClient BaseClient() => new HttpClient { BaseAddress = new Uri(_baseUrl) };


        private class JsonStringContent : StringContent
        {

            public JsonStringContent(object obj)
                : base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
            { }
        }
    }


    public class RestRepositoryT : IRepositoryT
    {
        private readonly string _url;

        public RestRepositoryT(string url)
        {

            _url = url;

        }
        public IPerson persons => new RestPerson(_url);
        public IPatient patient => new RestPatient(_url);
    
        public IAuthenticationService authentication => new RestAuthentication(_url);

        public IDepart depart =>  new RestDepartment(_url);
    }
    public class RestDepartment: IDepart
    {
        private readonly HttpHelper _http;
        // private readonly OPDContext appDbContext;
        public RestDepartment(string baseUrl)
        {
            _http = new HttpHelper(baseUrl);
            // appDbContext = oPDContext;
        }

        public async Task DeleteAsync(string customerId)=> _http.GetAsync<IEnumerable<Department>>($"depdelete/{customerId}");
        //await _http.DeleteAsync("depdelete", customerId);


        public async Task<IEnumerable<Department>> GetAsync()=> await _http.GetAsync<IEnumerable<Department>>($"depfindall");

        public async Task<IEnumerable<Department>> GetAsync(string search)=> await _http.GetAsync<IEnumerable<Department>>($"depfindone/{search}");


        public async Task<Department> UpsertAsync(Department customer)=> await _http.PostAsync<Department, Department>($"depcreate", customer);
        
    }
    public class RestAuthentication : IAuthenticationService
    {
        [Inject]
        Blazored.LocalStorage.ILocalStorageService localStorage { get; set; }
        private readonly HttpHelper _http;

        public LoginResult User { get; set; }
        public RestAuthentication(string baseUrl)
        {
            _http = new HttpHelper(baseUrl);

            User = new LoginResult();
            //  localStorage.SetItemAsync("User", User.jwtBearer);
        }

        public async Task Initialize()
        {

            User.jwtBearer = await localStorage.GetItemAsync<string>("User");


        }

        public async Task<LoginResult> Login(SiginModel login)
        {

            User = await _http.PostAsync<SiginModel, LoginResult>("login", login);
          //  await localStorage.SetItemAsync("User", User.jwtBearer);

            // await _localStorageService.SetItem("user", User);
            return User;
        }

        public async Task Logout()
        {
            try
            {
                User = null;
                await localStorage.RemoveItemAsync("User");
            }
            catch
            {

            }
            //  await _localStorageService.RemoveItem("user");

        }

        public async Task<LoginResult> Register(SiginUp register)
        {

            User = await _http.PostAsync<SiginUp, LoginResult>("register", register);

            return User;
        }

        public async Task<IEnumerable<SiginUp>> UserList()
        {
          var obj=  await _http.GetAsync<IEnumerable<SiginUp>>($"registerlist");
            return obj;
        }

        public async Task<SiginUp> Update(SiginUp register) => await _http.PostAsync<SiginUp, SiginUp>("registerupdate", register);

    }
    public class RestPerson : IPerson
    {
        private readonly HttpHelper _http;
        // private readonly OPDContext appDbContext;
        public RestPerson(string baseUrl)
        {
            _http = new HttpHelper(baseUrl);
            // appDbContext = oPDContext;
        }
        public async Task<IEnumerable<Person>> GetAsync(int pageindex, int pagesize)
        {
            int offest = (pageindex - 1) * pagesize;
            var personlist = await _http.GetAsync<IEnumerable<Person>>($"opdpersonfindall");
            // return await _http.GetAsync<IEnumerable<Person>>($"person/index={offest}&pagesize={pagesize}");
            return personlist;
            //var personlist= await _http.GetAsync<IEnumerable<Person>>($"person/index={offest}&pagesize={pagesize}");
            //await appDbContext.persons.AddRangeAsync(personlist.ToList());
            //return personlist;
        }

        //[HttpGet("index={index}&pagesize={pagesize}")]

        public async Task<IEnumerable<VirtualPerson>> GetAsync(string search, int key) =>
            await _http.GetAsync<IEnumerable<VirtualPerson>>($"opdpersonfindsearch?search={search}");
        //[HttpGet("serch")]

        public async Task<Person> GetAsync(string id)
        {
            return await _http.GetAsyncGetId<Person>($"opdpatientfindone/{id}");
        }
      

        public async Task<Person> UpsertAsync(Person person)
        {
            Person person1 = null;
            try
            {


                person1= await _http.PostAsync<Person, Person>("opdpatientcreate", person);
            }
            catch(Exception ex)
            {
               
            }
            return person1;
        }
           
       


        public async Task DeleteAsync(string Id) => await _http.DeleteAsync("person", Id);

        public async Task<IEnumerable<Department>> GetDepart() => await _http.GetAsync<IEnumerable<Department>>($"depfindall");

       

      

    }

    public class RestPatient : IPatient
    {
        private readonly HttpHelper _http;

        public RestPatient(string baseUrl)
        {
            _http = new HttpHelper(baseUrl);

        }
        public async Task<IEnumerable<Patient>> GetAsync(int pageindex, int pagesize)
        {
            int offest = (pageindex - 1) * pagesize;
            return await _http.GetAsync<IEnumerable<Patient>>($"opdpatientfindall?page={offest}&size={pagesize}");

           // return await _http.GetAsync<IEnumerable<Patient>>($"opdpatientfindall");

        }

        //[HttpGet("index={index}&pagesize={pagesize}")]

        public async Task<IEnumerable<Patient>> GetAsync(string id, int key) =>
            await _http.GetAsync<IEnumerable<Patient>>($"opdpatientfindone/{id}");
        // await _http.GetAsync<IEnumerable<Patient>>($"patient/search?value={search}");


        public async Task<Patient> GetAsync(string id) => await _http.GetAsync<Patient>($"opdpatientfindone/{id}");


        public async Task<Patient> UpsertAsync(Patient person) => await _http.PostAsync<Patient, Patient>("patient", person);



        public async Task DeleteAsync(string Id) => await _http.DeleteAsync("patient", Id);

    }




}
