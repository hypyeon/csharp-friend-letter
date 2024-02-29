using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FriendLetter
{
  class Program
  {
    static void Main(string[] args)
    {
      WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
      // beginning the process of creating a web app host, by creating a `builder` obj to configure web app host to be built. 

      builder.Services.AddControllersWithViews();
      // customizing the host `builder` by enabling the MVC framework as a service. invoking the `AddControllerWithVies()` method. 
      // services get added to web app host thru dependency injection - dependency: a class used within another class. 

      WebApplication app = builder.Build();
      // creates and returns web app host, saving in the variable `app`. 

      //app.UseDeveloperExceptionPage();

      app.UseHttpsRedirection();
      // enabling HTTPS redirection 
      // to get a security certificate, run `dotnet dev-certs https --trust` on console

      app.UseRouting();
      // ensuring host to match the website URL - routes to be defined in controller files

      app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
      );
      // establishing convention for routes to follow

      app.Run();
      // `app`: middleware - recieves and handles requests from a user to access a page within a website. 
    }
  }
}