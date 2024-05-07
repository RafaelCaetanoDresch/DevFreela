using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.UnitTests.Core.Entities;

public class ProjectTests
{
    private Project project = new Project(title: "Titulo Projeto",
                                          description: "Descrição do Projeto",
                                          clientID: Guid.NewGuid(),
                                          freelancerID: Guid.NewGuid(),
                                          totalCost: 10000);

    [Fact]
    public void TestIfProjectStartWorks()
    {
        //Arrange
        Assert.Equal(ProjectStatusEnum.Created, project.Status);
        Assert.Null(project.StartedAt);

        Assert.NotNull(project.Title);
        Assert.NotEmpty(project.Title);

        Assert.NotNull(project.Description);
        Assert.NotEmpty(project.Description);

        //Act
        project.Start();

        //Assert
        Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
        Assert.NotNull(project.StartedAt);

    }
}
