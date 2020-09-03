using AGAT.LocoDispatcher.Business.Models;
using AGAT.LocoDispatcher.Business.Models.RailModels;
using AGAT.LocoDispatcher.Common.Models;
using AutoMapper;
using System.Linq;
using Carriage = AGAT.LocoDispatcher.Common.Models.Carriage;

namespace AGAT.LocoDispatcher.Business
{
    public class Mapper
    {
        private static IMapper _mapper;
        static Mapper()
        {
            MapperConfiguration config = new MapperConfiguration(
            cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<AsusDb.Models.Route,Route>().ReverseMap();
                cfg.CreateMap<Data.Events.LocoShiftEvent, Locomotive>().ReverseMap();

                cfg.CreateMap<RailData.Models.Coord, Common.Models.Coords>()
                .ForMember(e => e.X, e => e.MapFrom(_e => _e.X))
                .ForMember(e => e.Y, e => e.MapFrom(_e => _e.Y)).ReverseMap();

                // Mapping classes from DataLayer to Business

                cfg.CreateMap<RailData.Models.Rail, Common.Models.Rail>()
                .ForMember(e => e.id, dto => dto.MapFrom(e => e.Id))
                .ForMember(e => e.railCode, dto => dto.MapFrom(e => e.RailCode))
                .ForMember(e => e.Coords, dto => dto.MapFrom(e => e.Coords.Where(w => w.StartFlag == false).ToList()))
                .ForMember(e => e.startX, dto => dto.MapFrom(e => e.Coords.Where(w => w.StartFlag == true).Select(w => w.X).FirstOrDefault()))
                .ForMember(e => e.startY, dto => dto.MapFrom(e => e.Coords.Where(w => w.StartFlag == true).Select(w => w.Y).FirstOrDefault()))
                .ForMember(e => e.Carriage, dto => dto.MapFrom(e => e.Carriage))
                .ForMember(e => e.Label, dto => dto.MapFrom(e => e.RoutePlate));

                cfg.CreateMap<RailData.Models.Carriage, Carriage>()
                .ForMember(e => e.Id, e => e.MapFrom(_e => _e.Id))
                .ForMember(e => e.Angle, e => e.MapFrom(_e => _e.Angle));

                cfg.CreateMap<RailData.Models.RoutePlate, Common.Models.RoutePlate>()
                .ForMember(e => e.Id, e => e.MapFrom(_e => _e.Id))
                .ForMember(e => e.Angle, e => e.MapFrom(_e => _e.Angle))
                .ForMember(e => e.X, e => e.MapFrom(_e => _e.X))
                .ForMember(e => e.Y, e => e.MapFrom(_e => _e.Y))
                .ForMember(e => e.Name, e => e.MapFrom(_e => _e.Name));

                cfg.CreateMap<RailData.Models.Park, Park>()
                .ForMember(e => e.Id, e => e.MapFrom(_e => _e.Id))
                .ForMember(e => e.Name, e => e.MapFrom(_e => _e.Name))
                .ForMember(e => e.ParkId, e => e.MapFrom(_e => _e.ParkId))
                .ForMember(e => e.Rails, e => e.MapFrom(_e => _e.Rails))
                .ForMember(e => e.Code, e => e.MapFrom(_e => _e.Code));

                cfg.CreateMap<RailData.Models.Point, Point>()
                .ForMember(e => e.Id, e => e.MapFrom(_e => _e.Id))
                .ForMember(e => e.Code, e => e.MapFrom(_e => _e.Code))
                .ForMember(e => e.Angle, e => e.MapFrom(_e => _e.Angle))
                .ForMember(e => e.Coord, e => e.MapFrom(_e => GetCoord(_e)));

                cfg.CreateMap<AsusDb.Models.CarriageInfo, Business.Models.RouteModels.CarriageInfo>()
                .ForMember(e => e.Id, e => e.MapFrom(_e => _e.Id))
                .ForMember(e => e.RouteId, e => e.MapFrom(_e => _e.RouteId))
                .ForMember(e => e.OwnerCode, e => e.MapFrom(_e => _e.OwnerCode))
                .ForMember(e => e.LoadWeight, e => e.MapFrom(_e => _e.LoadWeight))
                .ForMember(e => e.Order, e => e.MapFrom(_e => _e.Order))
                .ForMember(e => e.DestinationCode, e => e.MapFrom(_e => _e.DestinationCode))
                .ForMember(e => e.Description, e => e.MapFrom(_e => _e.Description));

                cfg.CreateMap<AsusDb.Models.Assignment, Assignment>().ReverseMap();


                //Mapping data from Business layer to DataLayer 
                cfg.CreateMap<Common.Models.Rail, RailData.Models.Rail>()
                .ForMember(dto => dto.Id, _e => _e.Ignore())
                .ForMember(dto => dto.RailCode, e => e.MapFrom(_e => _e.railCode))
                .ForMember(dto => dto.Coords, e => e.MapFrom(_e => _e.Coords))
                .ForMember(dto => dto.Carriage, e => e.MapFrom(_e => _e.Carriage))
                .ForMember(dto => dto.RoutePlate, e => e.MapFrom(_e => _e.Label))
                .AfterMap((orig, dest) =>
                {
                    RailData.Models.Coord startCoord = new RailData.Models.Coord
                    {
                        X = orig.startX,
                        Y = orig.startY,
                        StartFlag = true
                    };
                    dest.Coords.Add(startCoord);
                });

                cfg.CreateMap<Carriage, RailData.Models.Carriage>()
                .ForMember(e => e.Id, e => e.Ignore())
                .ForMember(e => e.Angle, e => e.MapFrom(_e => _e.Angle));

                cfg.CreateMap<Common.Models.RoutePlate, RailData.Models.RoutePlate>()
                .ForMember(e => e.Id, e => e.Ignore())
                .ForMember(e => e.Angle, e => e.MapFrom(_e => _e.Angle))
                .ForMember(e => e.X, e => e.MapFrom(_e => _e.X))
                .ForMember(e => e.Y, e => e.MapFrom(_e => _e.Y))
                .ForMember(e => e.Name, e => e.MapFrom(_e => _e.Name));

                cfg.CreateMap<Park, RailData.Models.Park>()
                .ForMember(e => e.Id, e => e.Ignore())
                .ForMember(e => e.Name, e => e.MapFrom(_e => _e.Name))
                .ForMember(e => e.ParkId, e => e.MapFrom(_e => _e.ParkId))
                .ForMember(e => e.Rails, e => e.MapFrom(_e => _e.Rails))
                .ForMember(e => e.Code, e => e.MapFrom(_e => _e.Code));

                cfg.CreateMap<Point, RailData.Models.Point>()
                .ForMember(e => e.Id, e => e.Ignore())
                .ForMember(e => e.Code, e => e.MapFrom(_e => _e.Code))
                .ForMember(e => e.Angle, e => e.MapFrom(_e => _e.Angle))
                .ForMember(e => e.X, e => e.MapFrom(_e => _e.Coord.X))
                .ForMember(e => e.Y, e => e.MapFrom(_e => _e.Coord.Y));

            });
            _mapper = config.CreateMapper();
        }

        public static IMapper GetMapperInstance()
        {
            return _mapper;
        }

        private static Common.Models.Coords GetCoord(RailData.Models.Point point)
        {
            Common.Models.Coords coord = new Common.Models.Coords
            {
                X = point.X,
                Y = point.Y
            };
            return coord;
        }

    }
}
