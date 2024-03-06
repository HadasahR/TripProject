using AutoMapper;
using DAL;
using DTO.Classes;

namespace DTO
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            //בלי שינויים DTO למשתנה הDAL המרה דו כיוונית ממשתנה ה
            //CreateMap<DAL.Models.Customer,CustomerDTO>().ReverseMap();
            CreateMap<DAL.Models.Customer,CustomerDTO>();
            CreateMap<CustomerDTO, DAL.Models.Customer>().ForMember(dest => dest.CustId, opt => opt.Ignore());

            CreateMap<DAL.Models.Type,TypeDTO>();
            CreateMap<TypeDTO, DAL.Models.Type>().ForMember(dest => dest.TypeId, opt => opt.Ignore());

            //המרה עם שינויים בשדות 
            //באוביקט לקוח 
            CreateMap<DAL.Models.OrderTicket, OrderTicketDTO>().
                //הוספת שם פרטי ושם משפחה של הלקוח 
                ForMember(dest => dest.customerFullName,
                   opt => opt.MapFrom(src => src.Cust.CustFname + " " + src.Cust.CustLname))
                //הוספת תאריך לטיול
                .ForMember(dest => dest.TripDate, opt => opt.MapFrom(src => src.Trip.Date))
                //הוספת יעד לטיול 
                .ForMember(dest => dest.Destination, opt => opt.MapFrom(src => src.Trip.Destination))
                ;
            CreateMap<OrderTicketDTO, DAL.Models.OrderTicket>().ForMember(dest=>dest.OrdId,opt=>opt.Ignore());

            //CreateMap<OrderTicketDTO, DAL.Models.OrderTicket>();
            ////באוביקט טיול 
            CreateMap<DAL.Models.Trip, TripDTO>().
                //הוספת שם סוג הטיול 
                ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.TypeName));
            //   . ForMember(dest=>dest.IsFirstAid,opt=>opt.)
            //CreateMap<TripDTO, DAL.Models.Trip>().Include;
            CreateMap<TripDTO, DAL.Models.Trip>().ForMember(dest => dest.TripId,opt => opt.Ignore());

            ////הוספה האם יש צורך בתעודת עזרה ראשונה 
            //??????????????????????????????
        }
    }
}