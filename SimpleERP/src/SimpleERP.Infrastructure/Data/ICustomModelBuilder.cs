using Microsoft.EntityFrameworkCore;

namespace SimpleERP.Infrastructure.Data
{
    public interface ICustomModelBuilder
    {
		void Build(ModelBuilder builder);
    }
}
