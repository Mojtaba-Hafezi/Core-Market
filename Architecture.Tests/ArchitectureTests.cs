using FluentAssertions;
using NetArchTest.Rules;
namespace Architecture.Tests
{
    public class ArchitectureTests
    {
        public string DomainNamespace = "Domain";
        public string ApplicationNamespace = "Application";
        public string InfrastructurePersistanceNamespace = "Infrastructure.Persistance";
        public string WebAPINamespace = "WebAPI";

        [Fact]
        public void Domain_Should_Not_HaveDependencyOnOtherProjects()
        {
            //Arrange
            var assembly = typeof(Domain.Entities.Product).Assembly;

            string[] otherProjects = new[]
            {
                ApplicationNamespace,
                InfrastructurePersistanceNamespace,
                WebAPINamespace
            };

            //Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult();

            //Assert
            testResult.IsSuccessful.Should().BeTrue();

        }


        [Fact]
        public void Application_Should_Not_HaveDependencyOnOtherProjects()
        {
            //Arrange
            var assembly = typeof(Application.DTOs.ProductDTO).Assembly;

            string[] otherProjects = new[]
            {
                InfrastructurePersistanceNamespace,
                WebAPINamespace
            };

            //Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult();

            //Assert
            testResult.IsSuccessful.Should().BeTrue();

        }

        [Fact]
        public void Infrastructure_Persistance_Should_Not_HaveDependencyOnOtherProjects()
        {
            //Arrange
            var assembly = typeof(Infrastructure.Persistance.Context.AppDbContext).Assembly;

            string[] otherProjects = new[]
            {
                WebAPINamespace
            };

            //Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult();

            //Assert
            testResult.IsSuccessful.Should().BeTrue();

        }

    }
}
