using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces;

public interface IProjectService
{
    List<ProjectViewModel> GetAll(string query);
    ProjectDetailsViewModel GetById(Guid Id);

    Guid Create(NewProjectInputModel inputModel);

    void Update(UpdateProjectInputModel inputModel);
    void Delete(Guid Id);
    void Start(Guid Id);
    void Finish(Guid Id);


    void CreateComment(CreateCommentInputModel inputModel);
}
