namespace TicketSystem
{
    using Models;
    using Data.Models;
    using AutoMapper;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Ticket, TicketModel>();
            CreateMap<TicketModel, Ticket>();

            CreateMap<Comment, CommentModel>();
            CreateMap<CommentModel, Comment>();
        }
    }
}
