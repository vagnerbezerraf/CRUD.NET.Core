using CRUD.Net.Core.Business.Interfaces;
using CRUD.Net.Core.DataLayer.Context;

namespace CRUD.Net.Core.Business.Services
{
    public abstract class Service : IServiceScoped
    {
        protected readonly CRUDContext context;

        public List<string> Errors { get; private set; }

        public List<string> Messages { get; private set; }

        public bool HasErrors { get => Errors.Any(); }

        protected Service(CRUDContext context)
        {
            this.context = context;
            Errors = new List<string>();
            Messages = new List<string>();
        }

    }
}
