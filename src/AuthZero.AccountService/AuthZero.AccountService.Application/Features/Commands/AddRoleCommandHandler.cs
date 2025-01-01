
using AuthZero.AccountService.Domain.AggregatesModel;

namespace AuthZero.AccountService.Application.Features.Commands;

public class AddRoleCommandHandler(
    IRoleRepository _roleRepository
) : IRequestHandler<AddRoleCommand, Guid>
{
    public async Task<Guid> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {


        var role = await _roleRepository.AddAsync(new Role(request.Name, request.Description));
        
        await _roleRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return role.Id;
    }
}