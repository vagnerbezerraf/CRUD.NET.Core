using CRUD.Net.Core.Business.DTOs.Requests;
using CRUD.Net.Core.Business.Notifications;
using CRUD.Net.Core.DataLayer.Context;
using CRUD.Net.Core.Domain.Models;
using Microsoft.Extensions.Logging;

namespace CRUD.Net.Core.Business.Services
{
    public class EventoService : Service
    {
        private readonly ILogger _logger;

        public EventoService(CRUDContext context, ILogger<EventoService> logger) : base(context)
        {
            _logger = logger;
            Messages.Clear();
            Errors.Clear();
        }

        public async Task<List<Evento>> GetAll()
        {
            List<Evento> entityList = new List<Evento>();
            try
            {
                _logger.LogInformation("List Eventos");

                entityList = context.Evento.ToList();

                _logger.LogInformation("Returns data");

                return entityList;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);

                return entityList;
            }
        }

        public async Task<Evento?> Create(EventoRequest request)
        {
            try
            {
                _logger.LogInformation("Create Evento");

                await context.Evento.AddAsync(request);

                await context.SaveChangesAsync();

                _logger.LogInformation("Save Evento Ended");
                return request;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
                return null;
            }
        }

        public async Task<Evento?> GetById(int id)
        {
            try
            {
                _logger.LogInformation("Get Evento by Id");



                var entity = context.Evento.FirstOrDefault(x => x.Id == id);

                _logger.LogInformation("Returns Evento");

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);

                return null;
            }
        }

        public async Task<Result> Update(EventoRequest request)
        {
            try
            {
                Messages.Add("Update Evento");

                context.Evento.Update(request);
                await context.SaveChangesAsync();

                Messages.Add("Update Event ended");
                _logger.LogInformation("Update Event ended");

                return Result.Sucesso(Messages);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error: " + ex.Message);

                Errors.Add(ex.Message);
                return Result.Falha(Errors);

            }
        }

        public async Task<Result> Delete(int id)
        {
            try
            {
                Messages.Add("Delete Evento");
                _logger.LogInformation("Delete Evento");

                var entity = context.Evento.FirstOrDefault(ai => ai.Id == id);

                if (entity == null)
                    throw new Exception("Evento Not found");

                Messages.Add("Init Delete");
                _logger.LogInformation("Initi Delete");

                context.Evento.Remove(entity);
                await context.SaveChangesAsync();

                Messages.Add("Evento Deleted");
                _logger.LogInformation("Evento Deleted");

                return Result.Sucesso(Messages);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);

                Errors.Add(ex.Message);
                return Result.Falha(Errors);

            }
        }

    }
}
