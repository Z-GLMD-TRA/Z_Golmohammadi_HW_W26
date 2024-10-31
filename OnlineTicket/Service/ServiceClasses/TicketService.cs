using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject.DTOClasses;
using Infrastructure.RepositoryInterfaces;
using Mapster;
using Model.Entities;
using Service.ServiceInterfaces;

namespace Service.ServiceClasses
{
    public class TicketService : ITicketService
    {
        private readonly IBaseRepository<Ticket, Guid> _repository;

        public TicketService(IBaseRepository<Ticket, Guid> repository)
        {
            _repository = repository;
        }
        public TicketDTO TranslateToDTO(Ticket entity)
        {
            return entity.Adapt<TicketDTO>();
        }

        public Ticket TranslateToEntity(TicketDTO dto)
        {
            return dto.Adapt<Ticket>();
        }

        public async Task<bool> CreateTicket(TicketDTO ticketDTO)
        {
            var entity = TranslateToEntity(ticketDTO);
            var result = await _repository.CreateDataAsync(entity);
            return result != null;

        }

        public async Task<List<TicketDTO>> GetAllTickets()
        {
            var tickets = await _repository.GetAllAsync();
            var ticketsDTO = tickets.ProjectToType<TicketDTO>().ToList();
            return ticketsDTO;
        }
    }
}
