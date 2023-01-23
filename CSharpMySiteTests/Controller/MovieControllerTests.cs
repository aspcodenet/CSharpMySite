using System.Net.Security;
using AutoFixture;
using CSharpMySite.Controllers;
using CSharpMySite.Data;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CSharpMySiteTests.Controller;

[TestClass]
public class MovieControllerTests
{
    private MovieController sut;
    private ApplicationDbContext context;
    private Fixture fixture = new Fixture();

    [TestInitialize]
    public void Init()
    {
        var connection = new SqliteConnection("Filename=:memory:");
        connection.Open();
        var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(connection)
            .Options;
        context = new ApplicationDbContext(contextOptions);
        context.Database.EnsureCreated();


        sut = new MovieController(context);
    }

    [TestMethod]
    public void When_calling_get_all_items_should_be_returned()
    {
        //Arrange - i databasen ska det finnas 3 movies
        context.Genres.Add( fixture.Create<Genre>() );
        context.SaveChanges();


        for(var i = 0; i < 3; i++)
        {
            var m = fixture.Create<Movie>();
            m.Genre = context.Genres.First();
            context.Movies.Add( m );
        }
        //context.Movies.Add(fioxture.CreaTEW
        //context.Movies.Add(new Movie { Id = 2, Genre = context.Genres.First(), Director = "AAA", Title = "432423", Year = 1234 });
        //context.Movies.Add(new Movie { Id = 3, Genre = context.Genres.First(), Director = "AAA", Title = "432423", Year = 1234 });
        context.SaveChanges();

        //Act
        var result = sut.Get().ToList();
        
        //Assert
        Assert.AreEqual(3, result.Count);
    }


}