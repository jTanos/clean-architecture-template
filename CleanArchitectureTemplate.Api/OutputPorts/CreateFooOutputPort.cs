using CleanArchitectureTemplate.Core.Contracts.UseCases;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.Create;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.FooCrudUseCases.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureTemplate.Api.OutputPorts
{
    public class CreateFooOutputPort : ICreateFooOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void HandleSuccess(CreateEntityUseCaseResponse createEntityUseCaseResponse)
        {
            ActionResult = new OkObjectResult(createEntityUseCaseResponse.Id);
        }

        public void HandleError(IUseCaseError useCaseError)
        {
            switch (useCaseError.Code)
            {
                case 1:
                    ActionResult = new StatusCodeResult(StatusCodes.Status400BadRequest);
                    break;
                case 2:
                    ActionResult = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                    break;
                default:
                    ActionResult = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                    break;
            }
        }
    }
}
