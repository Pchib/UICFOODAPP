using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Linq;
//using UICFoodOrderApp.Model;
using System.Threading.Tasks;
using UICFOODAPP.Model;
using Xamarin.Forms;

namespace UICFOODAPP.Services
{
    public class UserService
    {
        FirebaseClient client;
        public UserService()
        {
            client = new FirebaseClient("https://testapp-25bd6-default-rtdb.firebaseio.com/");
        }


        // to check for existing user
        public async Task<bool> IsUserExists(string uname)
        {
            var user = (await client.Child("Users").OnceAsync<User>())
                .Where(u => u.Object.Username == uname).FirstOrDefault();
            Console.WriteLine("IsUserExists" + uname);
            Console.WriteLine("IsUserExists" + user);
            // Console.WriteLine("+++++++++++-hgkkdlldrolk-" + user1);
            //Console.WriteLine("+++++++++++-hgkkdlldrolk-" + user2);
            return (user != null);
        }
        public async Task<bool> LoginUser(string uname, string password)
        {
            var user = (await client.Child("Users").OnceAsync<User>())
                .Where(u => u.Object.Username == uname).Where(u => u.Object.Password == password).FirstOrDefault();
            Console.WriteLine("IsUserExists" + uname);
            Console.WriteLine("IsUserExists" + user);
            // Console.WriteLine("+++++++++++-hgkkdlldrolk-" + user1);
            //Console.WriteLine("+++++++++++-hgkkdlldrolk-" + user2);
            return (user != null);
        }
       // public async Task<bool> LoginUser(string uname, string password)
        //{
        //    var user = (await client.Child("User").OnceAsync<User>())
         //       .Where(u => u.Object.Username == uname).FirstOrDefault();
         //   Console.WriteLine("LoginUser------------hgkkdlldrolk-" + uname);
         //   Console.WriteLine("LoginUser" + password);
         //   Console.WriteLine("+VLoginUser-" + user);
            //;


            //var Result2 = Result.ToString();
          //  return (user != null);
        //}

        public async Task<bool> RegisterUser(string uname , string password)
        {
            if (await IsUserExists(uname)== false)
            {

                await client.Child("Users")
                    .PostAsync(new User()
                    {
                        Username = uname,
                        Password = password
                    });
                return true;
            }
            else
            {
                return false;
            }
        }

      

         

    }
}
